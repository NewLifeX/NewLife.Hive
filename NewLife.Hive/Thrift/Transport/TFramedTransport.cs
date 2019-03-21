using System;
using System.IO;

namespace Thrift.Transport
{
    public class TFramedTransport : TTransport, IDisposable
    {
        private const int header_size = 4;

        protected TTransport transport;

        protected MemoryStream writeBuffer;

        protected MemoryStream readBuffer;

        private static byte[] header_dummy;

        private bool _IsDisposed;

        public override bool IsOpen
        {
            get
            {
                return transport.IsOpen;
            }
        }

        static TFramedTransport()
        {
            TFramedTransport.header_dummy = new byte[4];
        }

        public TFramedTransport()
        {
            InitWriteBuffer();
        }

        public TFramedTransport(TTransport transport) : this()
        {
            this.transport = transport;
        }

        public override void Close()
        {
            transport.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (!_IsDisposed && disposing && readBuffer != null)
            {
                readBuffer.Dispose();
            }
            _IsDisposed = true;
        }

        public override void Flush()
        {
            ArraySegment<byte> buffer;
            writeBuffer.TryGetBuffer(out buffer);
            int length = (int)writeBuffer.Length;
            int num = length - 4;
            if (num < 0)
            {
                throw new InvalidOperationException();
            }
            InitWriteBuffer();
            buffer.Array[0] = (byte)(255 & num >> 24);
            buffer.Array[1] = (byte)(255 & num >> 16);
            buffer.Array[2] = (byte)(255 & num >> 8);
            buffer.Array[3] = (byte)(255 & num);
            transport.Write(buffer.Array, 0, length);
            transport.Flush();
        }

        private void InitWriteBuffer()
        {
            writeBuffer = new MemoryStream(1024);
            writeBuffer.Write(TFramedTransport.header_dummy, 0, 4);
        }

        public override void Open()
        {
            transport.Open();
        }

        public override int Read(byte[] buf, int off, int len)
        {
            if (readBuffer != null)
            {
                int num = readBuffer.Read(buf, off, len);
                if (num > 0)
                {
                    return num;
                }
            }
            ReadFrame();
            return readBuffer.Read(buf, off, len);
        }

        private void ReadFrame()
        {
            byte[] numArray = new byte[4];
            transport.ReadAll(numArray, 0, 4);
            int num = (numArray[0] & 255) << 24 | (numArray[1] & 255) << 16 | (numArray[2] & 255) << 8 | numArray[3] & 255;
            byte[] numArray1 = new byte[num];
            transport.ReadAll(numArray1, 0, num);
            readBuffer = new MemoryStream(numArray1);
        }

        public override void Write(byte[] buf, int off, int len)
        {
            writeBuffer.Write(buf, off, len);
        }

        public class Factory : TTransportFactory
        {
            public Factory()
            {
            }

            public override TTransport GetTransport(TTransport trans)
            {
                return new TFramedTransport(trans);
            }
        }
    }
}