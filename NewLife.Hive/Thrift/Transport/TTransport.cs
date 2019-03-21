using System;

namespace Thrift.Transport
{
    public abstract class TTransport : IDisposable
    {
        public abstract Boolean IsOpen { get; }

        protected TTransport() { }

        public virtual IAsyncResult BeginFlush(AsyncCallback callback, Object state) => null;

        public abstract void Close();

        protected abstract void Dispose(Boolean disposing);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void EndFlush(IAsyncResult asyncResult) { }

        public virtual void Flush() { }

        public abstract void Open();

        public Boolean Peek() => IsOpen;

        public abstract Int32 Read(Byte[] buf, Int32 off, Int32 len);

        public Int32 ReadAll(Byte[] buf, Int32 off, Int32 len)
        {
            var num = 0;
            var num1 = 0;
            while (num < len)
            {
                num1 = Read(buf, off + num, len - num);
                if (num1 <= 0)
                {
                    throw new TTransportException(TTransportException.ExceptionType.EndOfFile, "Cannot read, Remote side has closed");
                }
                num = num + num1;
            }
            return num;
        }

        public virtual void Write(Byte[] buf) => Write(buf, 0, buf.Length);

        public abstract void Write(Byte[] buf, Int32 off, Int32 len);
    }
}