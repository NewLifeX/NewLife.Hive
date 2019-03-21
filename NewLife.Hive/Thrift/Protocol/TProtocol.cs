using System;
using System.Text;
using Thrift.Transport;

namespace Thrift.Protocol
{
    public abstract class TProtocol : IDisposable
    {
        protected TTransport trans;

        private Boolean _IsDisposed;

        public TTransport Transport => trans;

        protected TProtocol(TTransport trans)
        {
            this.trans = trans;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (!_IsDisposed && disposing && trans != null)
            {
                ((IDisposable)trans).Dispose();
            }
            _IsDisposed = true;
        }

        public abstract Byte[] ReadBinary();

        public abstract Boolean ReadBool();

        public abstract SByte ReadByte();

        public abstract Double ReadDouble();

        public abstract TField ReadFieldBegin();

        public abstract void ReadFieldEnd();

        public abstract Int16 ReadI16();

        public abstract Int32 ReadI32();

        public abstract Int64 ReadI64();

        public abstract TList ReadListBegin();

        public abstract void ReadListEnd();

        public abstract TMap ReadMapBegin();

        public abstract void ReadMapEnd();

        public abstract TMessage ReadMessageBegin();

        public abstract void ReadMessageEnd();

        public abstract TSet ReadSetBegin();

        public abstract void ReadSetEnd();

        public virtual String ReadString()
        {
            var numArray = ReadBinary();
            return Encoding.UTF8.GetString(numArray, 0, numArray.Length);
        }

        public abstract TStruct ReadStructBegin();

        public abstract void ReadStructEnd();

        public abstract void WriteBinary(Byte[] b);

        public abstract void WriteBool(Boolean b);

        public abstract void WriteByte(SByte b);

        public abstract void WriteDouble(Double d);

        public abstract void WriteFieldBegin(TField field);

        public abstract void WriteFieldEnd();

        public abstract void WriteFieldStop();

        public abstract void WriteI16(Int16 i16);

        public abstract void WriteI32(Int32 i32);

        public abstract void WriteI64(Int64 i64);

        public abstract void WriteListBegin(TList list);

        public abstract void WriteListEnd();

        public abstract void WriteMapBegin(TMap map);

        public abstract void WriteMapEnd();

        public abstract void WriteMessageBegin(TMessage message);

        public abstract void WriteMessageEnd();

        public abstract void WriteSetBegin(TSet set);

        public abstract void WriteSetEnd();

        public virtual void WriteString(String s)
        {
            WriteBinary(Encoding.UTF8.GetBytes(s));
        }

        public abstract void WriteStructBegin(TStruct struc);

        public abstract void WriteStructEnd();
    }
}