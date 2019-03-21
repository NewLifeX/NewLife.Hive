using System;
using System.Collections.Generic;
using System.Text;

namespace Thrift.Transport
{
    public class TSaslClientTransport : TTransport, IDisposable
    {
        protected SASLClient _sasl;
        protected TSocket _socket;
        protected static Int32 STATUS_BYTES = 1;
        protected static Int32 PAYLOAD_LENGTH_BYTES = 4;
        protected List<Byte> statusBytes = new List<Byte>() { 0x01, 0x02, 0x03, 0x04, 0x05 };
        private Boolean _IsOpen = false;
        private Byte[] _MessageHeader = new Byte[STATUS_BYTES + PAYLOAD_LENGTH_BYTES];
        private ByteArrayOutputStream _WriteBuffer = new ByteArrayOutputStream();

        public TSaslClientTransport(TSocket socket, String userName, String password)
        {
            _sasl = new SASLClient(socket.Host, new PlainMechanism(userName, password));
            _socket = socket;
        }

        public void Dispose()
        {
            _socket.Close();
            _socket = null;
            _sasl.Dispose();
        }

        public override void Close()
        {
            _socket.Close();
            _sasl.Dispose();
        }

        public override Boolean IsOpen
        {
            get { return _IsOpen; }
        }

        public override void Open()
        {
            if (!IsOpen)
            {
                _socket.Open();
                Send_Sasl_Msg(SaslStatus.START, _sasl.Mechanism);
                Send_Sasl_Msg(SaslStatus.OK, _sasl.process(null));

                while (true)
                {
                    var result = Recv_Sasl_Msg();
                    if (result.Status == SaslStatus.COMPLETE)
                    {
                        _IsOpen = true;
                        break;
                    }
                    else if (result.Status == SaslStatus.OK)
                    {
                        Send_Sasl_Msg(SaslStatus.OK, _sasl.process(Encoding.UTF8.GetBytes(result.Body)));
                    }
                    else
                    {
                        _socket.Close();
                        throw new Exception(String.Format("Bad SASL negotiation status: {0} ({1})", result.Status, result.Body));
                    }
                }
            }
        }

        public void Send_Sasl_Msg(SaslStatus status, String body)
        {
            Send_Sasl_Msg(status, Encoding.UTF8.GetBytes(body));
        }

        public void Send_Sasl_Msg(SaslStatus status, Byte[] body)
        {
            _MessageHeader[0] = statusBytes[(Int32)status - 1];
            EncodingUtils.encodeBigEndian(body.Length, _MessageHeader, STATUS_BYTES);
            _socket.Write(_MessageHeader);
            _socket.Write(body);
            _socket.Flush();
        }

        public class Sasl_Msg
        {
            public SaslStatus Status { get; set; }
            public String Body { get; set; }
            public Sasl_Msg(SaslStatus status, String body)
            {
                Status = status;
                Body = body;
            }

            public Sasl_Msg()
            {
            }
        }

        public Sasl_Msg Recv_Sasl_Msg()
        {
            var result = new Sasl_Msg();
            _socket.ReadAll(_MessageHeader, 0, _MessageHeader.Length);
            result.Status = (SaslStatus)(statusBytes.IndexOf(_MessageHeader[0]) + 1);
            var body = new Byte[EncodingUtils.decodeBigEndian(_MessageHeader, STATUS_BYTES)];
            _socket.ReadAll(body, 0, body.Length);

            result.Body = Encoding.UTF8.GetString(body);
            return result;
        }

        public Int32 ReadLength()
        {
            var lenBuf = new Byte[4];
            _socket.ReadAll(lenBuf, 0, lenBuf.Length);
            return EncodingUtils.decodeBigEndian(lenBuf);
        }

        public void WriteLength(Int32 length)
        {
            var lenBuf = new Byte[4];
            EncodingUtils.encodeFrameSize(length, lenBuf);
            _socket.Write(lenBuf);
        }

        TMemoryInputTransport readBuffer = new TMemoryInputTransport();
        public override Int32 Read(Byte[] buf, Int32 off, Int32 len)
        {
            var length = readBuffer.Read(buf, off, len);
            if (length > 0)
                return length;

            ReadFrame();
            var i = readBuffer.Read(buf, off, len);
            return i;
        }

        private void ReadFrame()
        {
            var dataLength = ReadLength();
            if (dataLength < 0)
                throw new TTransportException("Read a negative frame size (" + dataLength + ")!");

            var buff = new Byte[dataLength];
            _socket.ReadAll(buff, 0, dataLength);
            //string s = Encoding.UTF8.GetString(buff);
            readBuffer.Reset(buff);
        }


        public override void Write(Byte[] buf, Int32 off, Int32 len)
        {
            _WriteBuffer.Write(buf, off, len);
        }

        public override void Flush()
        {
            var buff = _WriteBuffer.GetBytes();
            _WriteBuffer.Reset();
            WriteLength(buff.Length);
            _socket.Write(buff, 0, buff.Length);
            _socket.Flush();
        }

        protected override void Dispose(Boolean disposing)
        {
            Dispose();
        }
    }
}