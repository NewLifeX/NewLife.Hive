using System;

namespace Thrift.Transport
{
    class TMemoryInputTransport : TTransport
    {
        private Byte[] buf_;
        private Int32 pos_;
        private Int32 endPos_;

        public TMemoryInputTransport()
        {
        }

        public TMemoryInputTransport(Byte[] buf)
        {
            Reset(buf);
        }

        public TMemoryInputTransport(Byte[] buf, Int32 offset, Int32 length)
        {
            Reset(buf, offset, length);
        }

        public void Reset(Byte[] buf)
        {
            Reset(buf, 0, buf.Length);
        }

        public void Reset(Byte[] buf, Int32 offset, Int32 length)
        {
            buf_ = buf;
            pos_ = offset;
            endPos_ = offset + length;
        }

        public void Clear()
        {
            buf_ = null;
        }

        public override void Close()
        {
        }

        public override Boolean IsOpen
        {
            get { return true; }
        }

        public override void Open()
        {
        }

        public override Int32 Read(Byte[] buf, Int32 off, Int32 len)
        {
            var bytesRemaining = GetBytesRemainingInBuffer;
            var amtToRead = (len > bytesRemaining ? bytesRemaining : len);
            if (amtToRead > 0)
            {
                Array.Copy(buf_, pos_, buf, off, amtToRead);
                ConsumeBuffer(amtToRead);
            }
            return amtToRead;
        }

        public override void Write(Byte[] buf, Int32 off, Int32 len)
        {
        }

        public Byte[] GetBuffer()
        {
            return buf_;
        }

        public Int32 GetBufferPosition
        {
            get { return pos_; }
        }

        public Int32 GetBytesRemainingInBuffer
        {
            get { return endPos_ - pos_; }
        }

        public void ConsumeBuffer(Int32 len)
        {
            pos_ += len;
        }

        protected override void Dispose(Boolean disposing)
        {
            Dispose();
        }
    }
}