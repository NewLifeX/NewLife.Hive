using System;
using System.IO;

namespace Thrift.Transport
{
    public class TStreamTransport : TTransport
    {
        protected Stream inputStream;

        protected Stream outputStream;

        private Boolean _IsDisposed;

        public Stream InputStream => inputStream;

        public override Boolean IsOpen => true;

        public Stream OutputStream => outputStream;

        public TStreamTransport() { }

        public TStreamTransport(Stream inputStream, Stream outputStream)
        {
            this.inputStream = inputStream;
            this.outputStream = outputStream;
        }

        public override void Close()
        {
            if (inputStream != null)
            {
                inputStream.Dispose();
                inputStream = null;
            }
            if (outputStream != null)
            {
                outputStream.Dispose();
                outputStream = null;
            }
        }

        protected override void Dispose(Boolean disposing)
        {
            if (!_IsDisposed && disposing)
            {
                if (InputStream != null) InputStream.Dispose();
                if (OutputStream != null) OutputStream.Dispose();
            }
            _IsDisposed = true;
        }

        public override void Flush()
        {
            if (outputStream == null)
                throw new TTransportException(TTransportException.ExceptionType.NotOpen, "Cannot flush null outputstream");

            outputStream.Flush();
        }

        public override void Open() { }

        public override Int32 Read(Byte[] buf, Int32 off, Int32 len)
        {
            if (inputStream == null)
                throw new TTransportException(TTransportException.ExceptionType.NotOpen, "Cannot read from null inputstream");

            return inputStream.Read(buf, off, len);
        }

        public override void Write(Byte[] buf, Int32 off, Int32 len)
        {
            if (outputStream == null)
                throw new TTransportException(TTransportException.ExceptionType.NotOpen, "Cannot write to null outputstream");

            outputStream.Write(buf, off, len);
        }
    }
}