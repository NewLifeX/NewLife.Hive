using System;

namespace Thrift.Protocol
{
	public abstract class TProtocolDecorator : TProtocol
	{
		private TProtocol WrappedProtocol;

		public TProtocolDecorator(TProtocol protocol) : base(protocol.Transport)
		{
			WrappedProtocol = protocol;
		}

		public override byte[] ReadBinary()
		{
			return WrappedProtocol.ReadBinary();
		}

		public override bool ReadBool()
		{
			return WrappedProtocol.ReadBool();
		}

		public override sbyte ReadByte()
		{
			return WrappedProtocol.ReadByte();
		}

		public override double ReadDouble()
		{
			return WrappedProtocol.ReadDouble();
		}

		public override TField ReadFieldBegin()
		{
			return WrappedProtocol.ReadFieldBegin();
		}

		public override void ReadFieldEnd()
		{
			WrappedProtocol.ReadFieldEnd();
		}

		public override short ReadI16()
		{
			return WrappedProtocol.ReadI16();
		}

		public override int ReadI32()
		{
			return WrappedProtocol.ReadI32();
		}

		public override long ReadI64()
		{
			return WrappedProtocol.ReadI64();
		}

		public override TList ReadListBegin()
		{
			return WrappedProtocol.ReadListBegin();
		}

		public override void ReadListEnd()
		{
			WrappedProtocol.ReadListEnd();
		}

		public override TMap ReadMapBegin()
		{
			return WrappedProtocol.ReadMapBegin();
		}

		public override void ReadMapEnd()
		{
			WrappedProtocol.ReadMapEnd();
		}

		public override TMessage ReadMessageBegin()
		{
			return WrappedProtocol.ReadMessageBegin();
		}

		public override void ReadMessageEnd()
		{
			WrappedProtocol.ReadMessageEnd();
		}

		public override TSet ReadSetBegin()
		{
			return WrappedProtocol.ReadSetBegin();
		}

		public override void ReadSetEnd()
		{
			WrappedProtocol.ReadSetEnd();
		}

		public override string ReadString()
		{
			return WrappedProtocol.ReadString();
		}

		public override TStruct ReadStructBegin()
		{
			return WrappedProtocol.ReadStructBegin();
		}

		public override void ReadStructEnd()
		{
			WrappedProtocol.ReadStructEnd();
		}

		public override void WriteBinary(byte[] bytes)
		{
			WrappedProtocol.WriteBinary(bytes);
		}

		public override void WriteBool(bool b)
		{
			WrappedProtocol.WriteBool(b);
		}

		public override void WriteByte(sbyte b)
		{
			WrappedProtocol.WriteByte(b);
		}

		public override void WriteDouble(double v)
		{
			WrappedProtocol.WriteDouble(v);
		}

		public override void WriteFieldBegin(TField tField)
		{
			WrappedProtocol.WriteFieldBegin(tField);
		}

		public override void WriteFieldEnd()
		{
			WrappedProtocol.WriteFieldEnd();
		}

		public override void WriteFieldStop()
		{
			WrappedProtocol.WriteFieldStop();
		}

		public override void WriteI16(short i)
		{
			WrappedProtocol.WriteI16(i);
		}

		public override void WriteI32(int i)
		{
			WrappedProtocol.WriteI32(i);
		}

		public override void WriteI64(long l)
		{
			WrappedProtocol.WriteI64(l);
		}

		public override void WriteListBegin(TList tList)
		{
			WrappedProtocol.WriteListBegin(tList);
		}

		public override void WriteListEnd()
		{
			WrappedProtocol.WriteListEnd();
		}

		public override void WriteMapBegin(TMap tMap)
		{
			WrappedProtocol.WriteMapBegin(tMap);
		}

		public override void WriteMapEnd()
		{
			WrappedProtocol.WriteMapEnd();
		}

		public override void WriteMessageBegin(TMessage tMessage)
		{
			WrappedProtocol.WriteMessageBegin(tMessage);
		}

		public override void WriteMessageEnd()
		{
			WrappedProtocol.WriteMessageEnd();
		}

		public override void WriteSetBegin(TSet tSet)
		{
			WrappedProtocol.WriteSetBegin(tSet);
		}

		public override void WriteSetEnd()
		{
			WrappedProtocol.WriteSetEnd();
		}

		public override void WriteString(string s)
		{
			WrappedProtocol.WriteString(s);
		}

		public override void WriteStructBegin(TStruct tStruct)
		{
			WrappedProtocol.WriteStructBegin(tStruct);
		}

		public override void WriteStructEnd()
		{
			WrappedProtocol.WriteStructEnd();
		}
	}
}