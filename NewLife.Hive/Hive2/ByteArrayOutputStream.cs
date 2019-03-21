using System;

namespace Thrift.Transport
{
    public class ByteArrayOutputStream
    {
        protected Byte[] _buf;
        protected Int32 Count { get; private set; }
        public ByteArrayOutputStream()
            : this(32)
        { }

        public ByteArrayOutputStream(Int32 size)
        {
            if (size > 0)
            {
                _buf = new Byte[size];
            }
            else
                throw new ArgumentException();
        }

        public void Write(Byte[] b, Int32 off, Int32 len)
        {
            if ((off < 0) || (off > b.Length) || (len < 0) || ((off + len) > b.Length) || ((off + len) < 0))
            {
                throw new IndexOutOfRangeException();
            }
            else if (len == 0) { return; }

            var newCount = Count + len;
            if (newCount > _buf.Length)
            {
                var newBuf = new Byte[Math.Max(_buf.Length << 1, newCount)];
                Array.Copy(_buf, 0, newBuf, 0, Count);
                _buf = newBuf;
            }
            Array.Copy(b, off, _buf, Count, len);
            Count = newCount;
        }

        public void Reset()
        {
            Count = 0;
        }

        public Byte[] GetBytes()
        {
            var newBuf = new Byte[Count];
            Array.Copy(_buf, 0, newBuf, 0, Count);
            return newBuf;
        }
    }

}