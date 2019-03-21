using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Transport;

namespace Thrift.Protocol
{
    public class TCompactProtocol : TProtocol
    {
        private const byte PROTOCOL_ID = 130;

        private const byte VERSION = 1;

        private const byte VERSION_MASK = 31;

        private const byte TYPE_MASK = 224;

        private const int TYPE_SHIFT_AMOUNT = 5;

        private static TStruct ANONYMOUS_STRUCT;

        private static TField TSTOP;

        private static byte[] ttypeToCompactType;

        private Stack<short> lastField_ = new Stack<short>(15);

        private short lastFieldId_;

        private TField? booleanField_;

        private bool? boolValue_;

        private byte[] byteDirectBuffer = new byte[1];

        private byte[] i32buf = new byte[5];

        private byte[] varint64out = new byte[10];

        private byte[] byteRawBuf = new byte[1];

        static TCompactProtocol()
        {
            ANONYMOUS_STRUCT = new TStruct("");
            TSTOP = new TField("", TType.Stop, 0);
            ttypeToCompactType = new byte[16];
        }

        public TCompactProtocol(TTransport trans) : base(trans)
        {
            ttypeToCompactType[0] = 0;
            ttypeToCompactType[2] = 1;
            ttypeToCompactType[3] = 3;
            ttypeToCompactType[6] = 4;
            ttypeToCompactType[8] = 5;
            ttypeToCompactType[10] = 6;
            ttypeToCompactType[4] = 7;
            ttypeToCompactType[11] = 8;
            ttypeToCompactType[15] = 9;
            ttypeToCompactType[14] = 10;
            ttypeToCompactType[13] = 11;
            ttypeToCompactType[12] = 12;
        }

        private long bytesToLong(byte[] bytes)
        {
            return (long)(((ulong)bytes[7] & (long)255) << 56 | ((ulong)bytes[6] & (long)255) << 48 | ((ulong)bytes[5] & (long)255) << 40 | ((ulong)bytes[4] & (long)255) << 32 | ((ulong)bytes[3] & (long)255) << 24 | ((ulong)bytes[2] & (long)255) << 16 | ((ulong)bytes[1] & (long)255) << 8 | (ulong)bytes[0] & (long)255);
        }

        private void fixedLongToBytes(long n, byte[] buf, int off)
        {
            buf[off] = (byte)(n & (long)255);
            buf[off + 1] = (byte)(n >> 8 & (long)255);
            buf[off + 2] = (byte)(n >> 16 & (long)255);
            buf[off + 3] = (byte)(n >> 24 & (long)255);
            buf[off + 4] = (byte)(n >> 32 & (long)255);
            buf[off + 5] = (byte)(n >> 40 & (long)255);
            buf[off + 6] = (byte)(n >> 48 & (long)255);
            buf[off + 7] = (byte)(n >> 56 & (long)255);
        }

        private byte getCompactType(TType ttype)
        {
            return ttypeToCompactType[(int)ttype];
        }

        private TType getTType(byte type)
        {
            switch ((byte)(type & 15))
            {
                case 0:
                    {
                        return TType.Stop;
                    }
                case 1:
                case 2:
                    {
                        return TType.Bool;
                    }
                case 3:
                    {
                        return TType.Byte;
                    }
                case 4:
                    {
                        return TType.I16;
                    }
                case 5:
                    {
                        return TType.I32;
                    }
                case 6:
                    {
                        return TType.I64;
                    }
                case 7:
                    {
                        return TType.Double;
                    }
                case 8:
                    {
                        return TType.String;
                    }
                case 9:
                    {
                        return TType.List;
                    }
                case 10:
                    {
                        return TType.Set;
                    }
                case 11:
                    {
                        return TType.Map;
                    }
                case 12:
                    {
                        return TType.Struct;
                    }
            }
            throw new TProtocolException(string.Concat("don't know what type: ", (byte)(type & 15)));
        }

        private uint intToZigZag(int n)
        {
            return (uint)(n << 1 ^ n >> 31);
        }

        private bool isBoolType(byte b)
        {
            int num = b & 15;
            if (num == 1)
            {
                return true;
            }
            return num == 2;
        }

        private ulong longToZigzag(long n)
        {
            return (ulong)(n << 1 ^ n >> 63);
        }

        public override byte[] ReadBinary()
        {
            int num = (int)ReadVarint32();
            if (num == 0)
            {
                return new byte[0];
            }
            byte[] numArray = new byte[num];
            trans.ReadAll(numArray, 0, num);
            return numArray;
        }

        private byte[] ReadBinary(int length)
        {
            if (length == 0)
            {
                return new byte[0];
            }
            byte[] numArray = new byte[length];
            trans.ReadAll(numArray, 0, length);
            return numArray;
        }

        public override bool ReadBool()
        {
            if (!boolValue_.HasValue)
            {
                return ReadByte() == 1;
            }
            bool value = boolValue_.Value;
            boolValue_ = null;
            return value;
        }

        public override sbyte ReadByte()
        {
            trans.ReadAll(byteRawBuf, 0, 1);
            return (sbyte)byteRawBuf[0];
        }

        public override double ReadDouble()
        {
            byte[] numArray = new byte[8];
            trans.ReadAll(numArray, 0, 8);
            return BitConverter.Int64BitsToDouble(bytesToLong(numArray));
        }

        public override TField ReadFieldBegin()
        {
            short num;
            byte num1 = (byte)ReadByte();
            if (num1 == 0)
            {
                return TSTOP;
            }
            short num2 = (short)((num1 & 240) >> 4);
            num = (num2 != 0 ? (short)(lastFieldId_ + num2) : ReadI16());
            TField tField = new TField("", getTType((byte)(num1 & 15)), num);
            if (isBoolType(num1))
            {
                boolValue_ = new bool?(((byte)(num1 & 15) == 1 ? true : false));
            }
            lastFieldId_ = tField.ID;
            return tField;
        }

        public override void ReadFieldEnd()
        {
        }

        public override short ReadI16()
        {
            return (short)zigzagToInt(ReadVarint32());
        }

        public override int ReadI32()
        {
            return zigzagToInt(ReadVarint32());
        }

        public override long ReadI64()
        {
            return zigzagToLong(ReadVarint64());
        }

        public override TList ReadListBegin()
        {
            byte num = (byte)ReadByte();
            int num1 = num >> 4 & 15;
            if (num1 == 15)
            {
                num1 = (int)ReadVarint32();
            }
            return new TList(getTType(num), num1);
        }

        public override void ReadListEnd()
        {
        }

        public override TMap ReadMapBegin()
        {
            byte num;
            int num1 = (int)ReadVarint32();
            if (num1 == 0)
            {
                num = 0;
            }
            else
            {
                num = (byte)ReadByte();
            }
            byte num2 = num;
            return new TMap(getTType((byte)(num2 >> 4)), getTType((byte)(num2 & 15)), num1);
        }

        public override void ReadMapEnd()
        {
        }

        public override TMessage ReadMessageBegin()
        {
            byte num = (byte)ReadByte();
            if (num != 130)
            {
                byte num1 = 130;
                throw new TProtocolException(string.Concat("Expected protocol id ", num1.ToString("X"), " but got ", num.ToString("X")));
            }
            byte num2 = (byte)ReadByte();
            byte num3 = (byte)(num2 & 31);
            if (num3 != 1)
            {
                object[] objArray = new object[] { "Expected version ", (byte)1, " but got ", num3 };
                throw new TProtocolException(string.Concat(objArray));
            }
            byte num4 = (byte)(num2 >> 5 & 3);
            int num5 = (int)ReadVarint32();
            return new TMessage(ReadString(), (TMessageType)num4, num5);
        }

        public override void ReadMessageEnd()
        {
        }

        public override TSet ReadSetBegin()
        {
            return new TSet(ReadListBegin());
        }

        public override void ReadSetEnd()
        {
        }

        public override string ReadString()
        {
            int num = (int)ReadVarint32();
            if (num == 0)
            {
                return "";
            }
            return Encoding.UTF8.GetString(ReadBinary(num));
        }

        public override TStruct ReadStructBegin()
        {
            lastField_.Push(lastFieldId_);
            lastFieldId_ = 0;
            return ANONYMOUS_STRUCT;
        }

        public override void ReadStructEnd()
        {
            lastFieldId_ = lastField_.Pop();
        }

        private uint ReadVarint32()
        {
            uint num = 0;
            int num1 = 0;
            while (true)
            {
                byte num2 = (byte)ReadByte();
                unchecked
                {
                    num = num | (uint)((num2 & 127) << (num1 & 31));
                }
                if ((num2 & 128) != 128)
                {
                    break;
                }
                num1 = num1 + 7;
            }
            return num;
        }

        private ulong ReadVarint64()
        {
            int num = 0;
            ulong num1 = (ulong)0;
            while (true)
            {
                byte num2 = (byte)ReadByte();
                unchecked
                {
                    num1 = num1 | (ulong)(num2 & 127) << (num & 63);
                }
                if ((num2 & 128) != 128)
                {
                    break;
                }
                num = num + 7;
            }
            return num1;
        }

        public void reset()
        {
            lastField_.Clear();
            lastFieldId_ = 0;
        }

        public override void WriteBinary(byte[] bin)
        {
            WriteBinary(bin, 0, (int)bin.Length);
        }

        private void WriteBinary(byte[] buf, int offset, int length)
        {
            WriteVarint32((uint)length);
            trans.Write(buf, offset, length);
        }

        public override void WriteBool(bool b)
        {
            if (!booleanField_.HasValue)
            {
                WriteByteDirect((byte)((b ? 1 : 2)));
                return;
            }
            WriteFieldBeginInternal(booleanField_.Value, (byte)((b ? 1 : 2)));
            booleanField_ = null;
        }

        public override void WriteByte(sbyte b)
        {
            WriteByteDirect((byte)b);
        }

        private void WriteByteDirect(byte b)
        {
            byteDirectBuffer[0] = b;
            trans.Write(byteDirectBuffer);
        }

        private void WriteByteDirect(int n)
        {
            WriteByteDirect((byte)n);
        }

        protected void WriteCollectionBegin(TType elemType, int size)
        {
            if (size <= 14)
            {
                WriteByteDirect(size << 4 | getCompactType(elemType));
                return;
            }
            WriteByteDirect(240 | getCompactType(elemType));
            WriteVarint32((uint)size);
        }

        public override void WriteDouble(double dub)
        {
            byte[] numArray = new byte[8];
            fixedLongToBytes(BitConverter.DoubleToInt64Bits(dub), numArray, 0);
            trans.Write(numArray);
        }

        public override void WriteFieldBegin(TField field)
        {
            if (field.Type == TType.Bool)
            {
                booleanField_ = new TField?(field);
                return;
            }
            WriteFieldBeginInternal(field, 255);
        }

        private void WriteFieldBeginInternal(TField field, byte typeOverride)
        {
            byte num = (typeOverride == 255 ? getCompactType(field.Type) : typeOverride);
            if (field.ID <= lastFieldId_ || field.ID - lastFieldId_ > 15)
            {
                WriteByteDirect(num);
                WriteI16(field.ID);
            }
            else
            {
                WriteByteDirect(field.ID - lastFieldId_ << 4 | num);
            }
            lastFieldId_ = field.ID;
        }

        public override void WriteFieldEnd()
        {
        }

        public override void WriteFieldStop()
        {
            WriteByteDirect((byte)0);
        }

        public override void WriteI16(short i16)
        {
            WriteVarint32(intToZigZag(i16));
        }

        public override void WriteI32(int i32)
        {
            WriteVarint32(intToZigZag(i32));
        }

        public override void WriteI64(long i64)
        {
            WriteVarint64(longToZigzag(i64));
        }

        public override void WriteListBegin(TList list)
        {
            WriteCollectionBegin(list.ElementType, list.Count);
        }

        public override void WriteListEnd()
        {
        }

        public override void WriteMapBegin(TMap map)
        {
            if (map.Count == 0)
            {
                WriteByteDirect(0);
                return;
            }
            WriteVarint32((uint)map.Count);
            WriteByteDirect(getCompactType(map.KeyType) << 4 | getCompactType(map.ValueType));
        }

        public override void WriteMapEnd()
        {
        }

        public override void WriteMessageBegin(TMessage message)
        {
            WriteByteDirect((byte)130);
            WriteByteDirect((byte)((int)TMessageType.Call | (int)message.Type << (int)(TMessageType.Call | TMessageType.Oneway) & 224));
            WriteVarint32((uint)message.SeqID);
            WriteString(message.Name);
        }

        public override void WriteMessageEnd()
        {
        }

        public override void WriteSetBegin(TSet set)
        {
            WriteCollectionBegin(set.ElementType, set.Count);
        }

        public override void WriteSetEnd()
        {
        }

        public override void WriteString(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            WriteBinary(bytes, 0, (int)bytes.Length);
        }

        public override void WriteStructBegin(TStruct strct)
        {
            lastField_.Push(lastFieldId_);
            lastFieldId_ = 0;
        }

        public override void WriteStructEnd()
        {
            lastFieldId_ = lastField_.Pop();
        }

        private void WriteVarint32(uint n)
        {
            int num = 0;
            unchecked
            {
                while (((ulong)n & (ulong)-128) != (long)0)
                {
                    int num1 = num;
                    num = num1 + 1;
                    i32buf[num1] = (byte)(n & 127 | 128);
                    n = n >> 7;
                }
            }
            int num2 = num;
            num = num2 + 1;
            i32buf[num2] = (byte)n;
            trans.Write(i32buf, 0, num);
        }

        private void WriteVarint64(ulong n)
        {
            int num = 0;
            unchecked
            {
                while ((n & (ulong)-128) != (long)0)
                {
                    int num1 = num;
                    num = num1 + 1;
                    varint64out[num1] = (byte)(n & (long)127 | (long)128);
                    n = n >> 7;
                }
            }
            int num2 = num;
            num = num2 + 1;
            varint64out[num2] = (byte)n;
            trans.Write(varint64out, 0, num);
        }

        private int zigzagToInt(uint n)
        {
            return (int)(n >> 1 ^ -(n & 1));
        }

        private long zigzagToLong(ulong n)
        {
            return ((long)n >> 1 ^ -((long)n & (long)1));
        }

        public class Factory : TProtocolFactory
        {
            public Factory()
            {
            }

            public TProtocol GetProtocol(TTransport trans)
            {
                return new TCompactProtocol(trans);
            }
        }

        private static class Types
        {
            public const byte STOP = 0;

            public const byte BOOLEAN_TRUE = 1;

            public const byte BOOLEAN_FALSE = 2;

            public const byte BYTE = 3;

            public const byte I16 = 4;

            public const byte I32 = 5;

            public const byte I64 = 6;

            public const byte DOUBLE = 7;

            public const byte BINARY = 8;

            public const byte LIST = 9;

            public const byte SET = 10;

            public const byte MAP = 11;

            public const byte STRUCT = 12;
        }
    }
}