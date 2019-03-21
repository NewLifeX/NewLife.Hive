using System;
using System.Text;
using Thrift.Transport;

namespace Thrift.Protocol
{
    public class TBinaryProtocol : TProtocol
    {
        protected const UInt32 VERSION_MASK = 4294901760;

        protected const UInt32 VERSION_1 = 2147549184;

        protected Boolean strictRead_;

        protected Boolean strictWrite_ = true;

        private readonly Byte[] bout = new Byte[1];

        private readonly Byte[] i16out = new Byte[2];

        private readonly Byte[] i32out = new Byte[4];

        private readonly Byte[] i64out = new Byte[8];

        private readonly Byte[] bin = new Byte[1];

        private readonly Byte[] i16in = new Byte[2];

        private readonly Byte[] i32in = new Byte[4];

        private readonly Byte[] i64in = new Byte[8];

        public TBinaryProtocol(TTransport trans) : this(trans, false, true)
        {
        }

        public TBinaryProtocol(TTransport trans, Boolean strictRead, Boolean strictWrite) : base(trans)
        {
            strictRead_ = strictRead;
            strictWrite_ = strictWrite;
        }

        private Int32 ReadAll(Byte[] buf, Int32 off, Int32 len)
        {
            return trans.ReadAll(buf, off, len);
        }

        public override Byte[] ReadBinary()
        {
            var num = ReadI32();
            var numArray = new Byte[num];
            trans.ReadAll(numArray, 0, num);
            return numArray;
        }

        public override Boolean ReadBool()
        {
            return ReadByte() == 1;
        }

        public override SByte ReadByte()
        {
            ReadAll(bin, 0, 1);
            return (SByte)bin[0];
        }

        public override Double ReadDouble()
        {
            return BitConverter.Int64BitsToDouble(ReadI64());
        }

        public override TField ReadFieldBegin()
        {
            var tField = new TField()
            {
                Type = (TType)((Byte)ReadByte())
            };
            if (tField.Type != TType.Stop)
            {
                tField.ID = ReadI16();
            }
            return tField;
        }

        public override void ReadFieldEnd()
        {
        }

        public override Int16 ReadI16()
        {
            ReadAll(i16in, 0, 2);
            return (Int16)((i16in[0] & 255) << 8 | i16in[1] & 255);
        }

        public override Int32 ReadI32()
        {
            ReadAll(i32in, 0, 4);
            return (i32in[0] & 255) << 24 | (i32in[1] & 255) << 16 | (i32in[2] & 255) << 8 | i32in[3] & 255;
        }

        public override Int64 ReadI64()
        {
            ReadAll(i64in, 0, 8);
            return (Int64)(i64in[0] & 255) << 56 | (Int64)(i64in[1] & 255) << 48 | (Int64)(i64in[2] & 255) << 40 | (Int64)(i64in[3] & 255) << 32 | (Int64)(i64in[4] & 255) << 24 | (Int64)(i64in[5] & 255) << 16 | (Int64)(i64in[6] & 255) << 8 | i64in[7] & 255;
        }

        public override TList ReadListBegin()
        {
            var tList = new TList()
            {
                ElementType = (TType)((Byte)ReadByte()),
                Count = ReadI32()
            };
            return tList;
        }

        public override void ReadListEnd()
        {
        }

        public override TMap ReadMapBegin()
        {
            var tMap = new TMap()
            {
                KeyType = (TType)((Byte)ReadByte()),
                ValueType = (TType)((Byte)ReadByte()),
                Count = ReadI32()
            };
            return tMap;
        }

        public override void ReadMapEnd()
        {
        }

        public override TMessage ReadMessageBegin()
        {
            var tMessage = new TMessage();
            var num = ReadI32();
            if (num >= 0)
            {
                if (strictRead_)
                {
                    throw new TProtocolException(4, "Missing version in readMessageBegin, old client?");
                }
                tMessage.Name = ReadStringBody(num);
                tMessage.Type = (TMessageType)ReadByte();
                tMessage.SeqID = ReadI32();
            }
            else
            {
                var num1 = (UInt32)(num & -65536);
                if (Convert.ToBase64String(BitConverter.GetBytes(num1)) != Convert.ToBase64String(BitConverter.GetBytes(-2147418112)))
                {
                    throw new TProtocolException(4, String.Concat("Bad version in ReadMessageBegin: ", num1));
                }
                tMessage.Type = (TMessageType)(num & 255);
                tMessage.Name = ReadString();
                tMessage.SeqID = ReadI32();
            }
            return tMessage;
        }

        public override void ReadMessageEnd()
        {
        }

        public override TSet ReadSetBegin()
        {
            var tSet = new TSet()
            {
                ElementType = (TType)((Byte)ReadByte()),
                Count = ReadI32()
            };
            return tSet;
        }

        public override void ReadSetEnd()
        {
        }

        private String ReadStringBody(Int32 size)
        {
            var numArray = new Byte[size];
            trans.ReadAll(numArray, 0, size);
            return Encoding.UTF8.GetString(numArray, 0, numArray.Length);
        }

        public override TStruct ReadStructBegin()
        {
            return new TStruct();
        }

        public override void ReadStructEnd()
        {
        }

        public override void WriteBinary(Byte[] b)
        {
            WriteI32(b.Length);
            trans.Write(b, 0, b.Length);
        }

        private delegate void temp(Boolean b);

        public override void WriteBool(Boolean b)
        {
            //var dm = new DynamicMethod("tempWriteBool", null, new Type[] { typeof(bool) });
            //var il = dm.GetILGenerator();
            //var IL_0007 = new Label();
            //var IL_0008 = new Label();
            //il.Emit(OpCodes.Ldarg_0);
            //il.Emit(OpCodes.Brtrue_S, IL_0007);
            //il.Emit(OpCodes.Ldc_I4_0);
            //il.Emit(OpCodes.Br_S, IL_0008);
            //il.MarkLabel(IL_0007);
            //il.Emit(OpCodes.Ldc_I4_1);
            //il.MarkLabel(IL_0008);
            //il.EmitCall(OpCodes.Callvirt, typeof(TBinaryProtocol).GetMethod("WriteByte"), new Type[] { typeof(sbyte) });
            //il.Emit(OpCodes.Ret);
            //var tm = (temp)(dm.CreateDelegate(typeof(TBinaryProtocol)));
            //tm(b);
            WriteByte((b ? (SByte)1 : (SByte)0));
        }

        public override void WriteByte(SByte b)
        {
            bout[0] = (Byte)b;
            trans.Write(bout, 0, 1);
        }

        public override void WriteDouble(Double d)
        {
            WriteI64(BitConverter.DoubleToInt64Bits(d));
        }

        public override void WriteFieldBegin(TField field)
        {
            WriteByte((SByte)field.Type);
            WriteI16(field.ID);
        }

        public override void WriteFieldEnd()
        {
        }

        public override void WriteFieldStop()
        {
            WriteByte(0);
        }

        public override void WriteI16(Int16 s)
        {
            i16out[0] = (Byte)(255 & s >> 8);
            i16out[1] = (Byte)(255 & s);
            trans.Write(i16out, 0, 2);
        }

        public override void WriteI32(Int32 i32)
        {
            i32out[0] = (Byte)(255 & i32 >> 24);
            i32out[1] = (Byte)(255 & i32 >> 16);
            i32out[2] = (Byte)(255 & i32 >> 8);
            i32out[3] = (Byte)(255 & i32);
            trans.Write(i32out, 0, 4);
        }

        public override void WriteI64(Int64 i64)
        {
            i64out[0] = (Byte)(255 & i64 >> 56);
            i64out[1] = (Byte)(255 & i64 >> 48);
            i64out[2] = (Byte)(255 & i64 >> 40);
            i64out[3] = (Byte)(255 & i64 >> 32);
            i64out[4] = (Byte)(255 & i64 >> 24);
            i64out[5] = (Byte)(255 & i64 >> 16);
            i64out[6] = (Byte)(255 & i64 >> 8);
            i64out[7] = (Byte)(255 & i64);
            trans.Write(i64out, 0, 8);
        }

        public override void WriteListBegin(TList list)
        {
            WriteByte((SByte)list.ElementType);
            WriteI32(list.Count);
        }

        public override void WriteListEnd()
        {
        }

        public override void WriteMapBegin(TMap map)
        {
            WriteByte((SByte)map.KeyType);
            WriteByte((SByte)map.ValueType);
            WriteI32(map.Count);
        }

        public override void WriteMapEnd()
        {
        }

        public override void WriteMessageBegin(TMessage message)
        {
            if (!strictWrite_)
            {
                WriteString(message.Name);
                WriteByte((SByte)message.Type);
                WriteI32(message.SeqID);
                return;
            }
            WriteI32(-2147418112 | (Int32)message.Type);
            WriteString(message.Name);
            WriteI32(message.SeqID);
        }

        public override void WriteMessageEnd()
        {
        }

        public override void WriteSetBegin(TSet set)
        {
            WriteByte((SByte)set.ElementType);
            WriteI32(set.Count);
        }

        public override void WriteSetEnd()
        {
        }

        public override void WriteStructBegin(TStruct struc)
        {
        }

        public override void WriteStructEnd()
        {
        }

        public class Factory : TProtocolFactory
        {
            protected Boolean strictRead_;

            protected Boolean strictWrite_;

            public Factory() : this(false, true)
            {
            }

            public Factory(Boolean strictRead, Boolean strictWrite)
            {
                strictRead_ = strictRead;
                strictWrite_ = strictWrite;
            }

            public TProtocol GetProtocol(TTransport trans) => new TBinaryProtocol(trans, strictRead_, strictWrite_);
        }
    }
}