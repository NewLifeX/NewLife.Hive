using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Thrift.Transport;

namespace Thrift.Protocol
{
    public class TJSONProtocol : TProtocol
    {
        private const long VERSION = 1L;

        private const int DEF_STRING_SIZE = 16;

        private static byte[] COMMA;

        private static byte[] COLON;

        private static byte[] LBRACE;

        private static byte[] RBRACE;

        private static byte[] LBRACKET;

        private static byte[] RBRACKET;

        private static byte[] QUOTE;

        private static byte[] BACKSLASH;

        private static byte[] ZERO;

        private byte[] ESCSEQ = new byte[] { 92, 117, 48, 48 };

        private byte[] JSON_CHAR_TABLE = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 98, 116, 110, 0, 102, 114, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 34, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        private char[] ESCAPE_CHARS = "\"\\bfnrt".ToCharArray();

        private byte[] ESCAPE_CHAR_VALS = new byte[] { 34, 92, 8, 12, 10, 13, 9 };

        private static byte[] NAME_BOOL;

        private static byte[] NAME_BYTE;

        private static byte[] NAME_I16;

        private static byte[] NAME_I32;

        private static byte[] NAME_I64;

        private static byte[] NAME_DOUBLE;

        private static byte[] NAME_STRUCT;

        private static byte[] NAME_STRING;

        private static byte[] NAME_MAP;

        private static byte[] NAME_LIST;

        private static byte[] NAME_SET;

        protected Encoding utf8Encoding = Encoding.UTF8;

        protected Stack<TJSONProtocol.JSONBaseContext> contextStack = new Stack<TJSONProtocol.JSONBaseContext>();

        protected TJSONProtocol.JSONBaseContext context;

        protected TJSONProtocol.LookaheadReader reader;

        private byte[] tempBuffer = new byte[4];

        static TJSONProtocol()
        {
            COMMA = new byte[] { 44 };
            COLON = new byte[] { 58 };
            LBRACE = new byte[] { 123 };
            RBRACE = new byte[] { 125 };
            LBRACKET = new byte[] { 91 };
            RBRACKET = new byte[] { 93 };
            QUOTE = new byte[] { 34 };
            BACKSLASH = new byte[] { 92 };
            ZERO = new byte[] { 48 };
            NAME_BOOL = new byte[] { 116, 102 };
            NAME_BYTE = new byte[] { 105, 56 };
            NAME_I16 = new byte[] { 105, 49, 54 };
            NAME_I32 = new byte[] { 105, 51, 50 };
            NAME_I64 = new byte[] { 105, 54, 52 };
            NAME_DOUBLE = new byte[] { 100, 98, 108 };
            NAME_STRUCT = new byte[] { 114, 101, 99 };
            NAME_STRING = new byte[] { 115, 116, 114 };
            NAME_MAP = new byte[] { 109, 97, 112 };
            NAME_LIST = new byte[] { 108, 115, 116 };
            NAME_SET = new byte[] { 115, 101, 116 };
        }

        public TJSONProtocol(TTransport trans) : base(trans)
        {
            context = new TJSONProtocol.JSONBaseContext(this);
            reader = new TJSONProtocol.LookaheadReader(this);
        }

        private static TType GetTypeIDForTypeName(byte[] name)
        {
            TType tType = TType.Stop;
            if ((int)name.Length > 1)
            {
                byte num = name[0];
                if (num == 100)
                {
                    tType = TType.Double;
                }
                else
                {
                    switch (num)
                    {
                        case 105:
                            {
                                byte num1 = name[1];
                                switch (num1)
                                {
                                    case 49:
                                        {
                                            tType = TType.I16;
                                            break;
                                        }
                                    case 50:
                                        {
                                            break;
                                        }
                                    case 51:
                                        {
                                            tType = TType.I32;
                                            break;
                                        }
                                    default:
                                        {
                                            switch (num1)
                                            {
                                                case 54:
                                                    {
                                                        tType = TType.I64;
                                                        break;
                                                    }
                                                case 56:
                                                    {
                                                        tType = TType.Byte;
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                        case 106:
                        case 107:
                            {
                                break;
                            }
                        case 108:
                            {
                                tType = TType.List;
                                break;
                            }
                        case 109:
                            {
                                tType = TType.Map;
                                break;
                            }
                        default:
                            {
                                switch (num)
                                {
                                    case 114:
                                        {
                                            tType = TType.Struct;
                                            break;
                                        }
                                    case 115:
                                        {
                                            if (name[1] != 116)
                                            {
                                                if (name[1] != 101)
                                                {
                                                    if (tType == TType.Stop)
                                                    {
                                                        throw new TProtocolException(5, "Unrecognized type");
                                                    }
                                                    return tType;
                                                }
                                                tType = TType.Set;
                                            }
                                            else
                                            {
                                                tType = TType.String;
                                            }
                                            break;
                                        }
                                    case 116:
                                        {
                                            tType = TType.Bool;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }
            if (tType == TType.Stop)
            {
                throw new TProtocolException(5, "Unrecognized type");
            }
            return tType;
        }

        private static byte[] GetTypeNameForTypeID(TType typeID)
        {
            switch (typeID)
            {
                case TType.Bool:
                    {
                        return NAME_BOOL;
                    }
                case TType.Byte:
                    {
                        return NAME_BYTE;
                    }
                case TType.Double:
                    {
                        return NAME_DOUBLE;
                    }
                case TType.Void | TType.Double:
                case TType.Void | TType.Bool | TType.Byte | TType.Double | TType.I16:
                case TType.Void | TType.I32:
                    {
                        throw new TProtocolException(5, "Unrecognized type");
                    }
                case TType.I16:
                    {
                        return NAME_I16;
                    }
                case TType.I32:
                    {
                        return NAME_I32;
                    }
                case TType.I64:
                    {
                        return NAME_I64;
                    }
                case TType.String:
                    {
                        return NAME_STRING;
                    }
                case TType.Struct:
                    {
                        return NAME_STRUCT;
                    }
                case TType.Map:
                    {
                        return NAME_MAP;
                    }
                case TType.Set:
                    {
                        return NAME_SET;
                    }
                case TType.List:
                    {
                        return NAME_LIST;
                    }
                default:
                    {
                        throw new TProtocolException(5, "Unrecognized type");
                    }
            }
        }

        private static byte HexChar(byte val)
        {
            val = (byte)(val & 15);
            if (val < 10)
            {
                return (byte)(val + 48);
            }
            val = (byte)(val - 10);
            return (byte)(val + 97);
        }

        private static byte HexVal(byte ch)
        {
            if (ch >= 48 && ch <= 57)
            {
                return (byte)(ch - 48);
            }
            if (ch < 97 || ch > 102)
            {
                throw new TProtocolException(1, "Expected hex character");
            }
            ch = (byte)(ch + 10);
            return (byte)(ch - 97);
        }

        private bool IsJSONNumeric(byte b)
        {
            byte num = b;
            switch (num)
            {
                case 43:
                case 45:
                case 46:
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:
                case 69:
                    {
                        return true;
                    }
                case 44:
                case 47:
                case 58:
                case 59:
                case 60:
                case 61:
                case 62:
                case 63:
                case 64:
                case 65:
                case 66:
                case 67:
                case 68:
                    {
                        return false;
                    }
                default:
                    {
                        if (num != 101)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
            }
        }

        protected void PopContext()
        {
            context = contextStack.Pop();
        }

        protected void PushContext(TJSONProtocol.JSONBaseContext c)
        {
            contextStack.Push(context);
            context = c;
        }

        public override byte[] ReadBinary()
        {
            return ReadJSONBase64();
        }

        public override bool ReadBool()
        {
            if (ReadJSONInteger() != (long)0)
            {
                return true;
            }
            return false;
        }

        public override sbyte ReadByte()
        {
            return (sbyte)ReadJSONInteger();
        }

        public override double ReadDouble()
        {
            return ReadJSONDouble();
        }

        public override TField ReadFieldBegin()
        {
            TField typeIDForTypeName = new TField();
            if (reader.Peek() != RBRACE[0])
            {
                typeIDForTypeName.ID = (short)ReadJSONInteger();
                ReadJSONObjectStart();
                typeIDForTypeName.Type = GetTypeIDForTypeName(ReadJSONString(false));
            }
            else
            {
                typeIDForTypeName.Type = TType.Stop;
            }
            return typeIDForTypeName;
        }

        public override void ReadFieldEnd()
        {
            ReadJSONObjectEnd();
        }

        public override short ReadI16()
        {
            return (short)ReadJSONInteger();
        }

        public override int ReadI32()
        {
            return (int)ReadJSONInteger();
        }

        public override long ReadI64()
        {
            return ReadJSONInteger();
        }

        private void ReadJSONArrayEnd()
        {
            ReadJSONSyntaxChar(RBRACKET);
            PopContext();
        }

        private void ReadJSONArrayStart()
        {
            context.Read();
            ReadJSONSyntaxChar(LBRACKET);
            PushContext(new TJSONProtocol.JSONListContext(this));
        }

        private byte[] ReadJSONBase64()
        {
            byte[] numArray = ReadJSONString(false);
            int length = (int)numArray.Length;
            int num = 0;
            int num1 = 0;
            while (length >= 4)
            {
                TBase64Utils.decode(numArray, num, 4, numArray, num1);
                num = num + 4;
                length = length - 4;
                num1 = num1 + 3;
            }
            if (length > 1)
            {
                TBase64Utils.decode(numArray, num, length, numArray, num1);
                num1 = num1 + (length - 1);
            }
            byte[] numArray1 = new byte[num1];
            Array.Copy(numArray, 0, numArray1, 0, num1);
            return numArray1;
        }

        private double ReadJSONDouble()
        {
            double num;
            context.Read();
            if (reader.Peek() != QUOTE[0])
            {
                if (context.EscapeNumbers())
                {
                    ReadJSONSyntaxChar(QUOTE);
                }
                try
                {
                    num = double.Parse(ReadJSONNumericChars());
                }
                catch (FormatException formatException)
                {
                    throw new TProtocolException(1, "Bad data encounted in numeric data");
                }
                return num;
            }
            byte[] numArray = ReadJSONString(true);
            double num1 = double.Parse(utf8Encoding.GetString(numArray, 0, (int)numArray.Length), CultureInfo.InvariantCulture);
            if (!context.EscapeNumbers() && !double.IsNaN(num1) && !double.IsInfinity(num1))
            {
                throw new TProtocolException(1, "Numeric data unexpectedly quoted");
            }
            return num1;
        }

        private long ReadJSONInteger()
        {
            long num;
            context.Read();
            if (context.EscapeNumbers())
            {
                ReadJSONSyntaxChar(QUOTE);
            }
            string str = ReadJSONNumericChars();
            if (context.EscapeNumbers())
            {
                ReadJSONSyntaxChar(QUOTE);
            }
            try
            {
                num = long.Parse(str);
            }
            catch (FormatException formatException)
            {
                throw new TProtocolException(1, "Bad data encounted in numeric data");
            }
            return num;
        }

        private string ReadJSONNumericChars()
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (IsJSONNumeric(reader.Peek()))
            {
                stringBuilder.Append((char)reader.Read());
            }
            return stringBuilder.ToString();
        }

        private void ReadJSONObjectEnd()
        {
            ReadJSONSyntaxChar(RBRACE);
            PopContext();
        }

        private void ReadJSONObjectStart()
        {
            context.Read();
            ReadJSONSyntaxChar(LBRACE);
            PushContext(new TJSONProtocol.JSONPairContext(this));
        }

        private byte[] ReadJSONString(bool skipContext)
        {
            MemoryStream memoryStream = new MemoryStream();
            if (!skipContext)
            {
                context.Read();
            }
            ReadJSONSyntaxChar(QUOTE);
            while (true)
            {
                byte eSCAPECHARVALS = reader.Read();
                if (eSCAPECHARVALS == QUOTE[0])
                {
                    break;
                }
                if (eSCAPECHARVALS == ESCSEQ[0])
                {
                    eSCAPECHARVALS = reader.Read();
                    if (eSCAPECHARVALS != ESCSEQ[1])
                    {
                        int num = Array.IndexOf<char>(ESCAPE_CHARS, Convert.ToChar(eSCAPECHARVALS));
                        if (num == -1)
                        {
                            throw new TProtocolException(1, "Expected control char");
                        }
                        eSCAPECHARVALS = ESCAPE_CHAR_VALS[num];
                    }
                    else
                    {
                        ReadJSONSyntaxChar(ZERO);
                        ReadJSONSyntaxChar(ZERO);
                        trans.ReadAll(tempBuffer, 0, 2);
                        eSCAPECHARVALS = (byte)((HexVal(tempBuffer[0]) << 4) + HexVal(tempBuffer[1]));
                    }
                }
                memoryStream.Write(new byte[] { eSCAPECHARVALS }, 0, 1);
            }
            return memoryStream.ToArray();
        }

        protected void ReadJSONSyntaxChar(byte[] b)
        {
            byte num = reader.Read();
            if (num != b[0])
            {
                throw new TProtocolException(1, string.Concat("Unexpected character:", (char)num));
            }
        }

        public override TList ReadListBegin()
        {
            TList typeIDForTypeName = new TList();
            ReadJSONArrayStart();
            typeIDForTypeName.ElementType = GetTypeIDForTypeName(ReadJSONString(false));
            typeIDForTypeName.Count = (int)ReadJSONInteger();
            return typeIDForTypeName;
        }

        public override void ReadListEnd()
        {
            ReadJSONArrayEnd();
        }

        public override TMap ReadMapBegin()
        {
            TMap typeIDForTypeName = new TMap();
            ReadJSONArrayStart();
            typeIDForTypeName.KeyType = GetTypeIDForTypeName(ReadJSONString(false));
            typeIDForTypeName.ValueType = GetTypeIDForTypeName(ReadJSONString(false));
            typeIDForTypeName.Count = (int)ReadJSONInteger();
            ReadJSONObjectStart();
            return typeIDForTypeName;
        }

        public override void ReadMapEnd()
        {
            ReadJSONObjectEnd();
            ReadJSONArrayEnd();
        }

        public override TMessage ReadMessageBegin()
        {
            TMessage str = new TMessage();
            ReadJSONArrayStart();
            if (ReadJSONInteger() != (long)1)
            {
                throw new TProtocolException(4, "Message contained bad version.");
            }
            byte[] numArray = ReadJSONString(false);
            str.Name = utf8Encoding.GetString(numArray, 0, (int)numArray.Length);
            str.Type = (TMessageType)((int)ReadJSONInteger());
            str.SeqID = (int)ReadJSONInteger();
            return str;
        }

        public override void ReadMessageEnd()
        {
            ReadJSONArrayEnd();
        }

        public override TSet ReadSetBegin()
        {
            TSet typeIDForTypeName = new TSet();
            ReadJSONArrayStart();
            typeIDForTypeName.ElementType = GetTypeIDForTypeName(ReadJSONString(false));
            typeIDForTypeName.Count = (int)ReadJSONInteger();
            return typeIDForTypeName;
        }

        public override void ReadSetEnd()
        {
            ReadJSONArrayEnd();
        }

        public override string ReadString()
        {
            byte[] numArray = ReadJSONString(false);
            return utf8Encoding.GetString(numArray, 0, (int)numArray.Length);
        }

        public override TStruct ReadStructBegin()
        {
            ReadJSONObjectStart();
            return new TStruct();
        }

        public override void ReadStructEnd()
        {
            ReadJSONObjectEnd();
        }

        public override void WriteBinary(byte[] bin)
        {
            WriteJSONBase64(bin);
        }

        public override void WriteBool(bool b)
        {
            WriteJSONInteger((b ? (long)1 : (long)0));
        }

        public override void WriteByte(sbyte b)
        {
            WriteJSONInteger((long)b);
        }

        public override void WriteDouble(double dub)
        {
            WriteJSONDouble(dub);
        }

        public override void WriteFieldBegin(TField field)
        {
            WriteJSONInteger((long)field.ID);
            WriteJSONObjectStart();
            WriteJSONString(GetTypeNameForTypeID(field.Type));
        }

        public override void WriteFieldEnd()
        {
            WriteJSONObjectEnd();
        }

        public override void WriteFieldStop()
        {
        }

        public override void WriteI16(short i16)
        {
            WriteJSONInteger((long)i16);
        }

        public override void WriteI32(int i32)
        {
            WriteJSONInteger((long)i32);
        }

        public override void WriteI64(long i64)
        {
            WriteJSONInteger(i64);
        }

        private void WriteJSONArrayEnd()
        {
            PopContext();
            trans.Write(RBRACKET);
        }

        private void WriteJSONArrayStart()
        {
            context.Write();
            trans.Write(LBRACKET);
            PushContext(new TJSONProtocol.JSONListContext(this));
        }

        private void WriteJSONBase64(byte[] b)
        {
            context.Write();
            trans.Write(QUOTE);
            int length = (int)b.Length;
            int num = 0;
            while (length >= 3)
            {
                TBase64Utils.encode(b, num, 3, tempBuffer, 0);
                trans.Write(tempBuffer, 0, 4);
                num = num + 3;
                length = length - 3;
            }
            if (length > 0)
            {
                TBase64Utils.encode(b, num, length, tempBuffer, 0);
                trans.Write(tempBuffer, 0, length + 1);
            }
            trans.Write(QUOTE);
        }

        private void WriteJSONDouble(double num)
        {
            context.Write();
            string str = num.ToString(CultureInfo.InvariantCulture);
            bool flag = false;
            char chr = str[0];
            if (chr != '-')
            {
                if (chr == 'I' || chr == 'N')
                {
                    flag = true;
                }
            }
            else if (str[1] == 'I')
            {
                flag = true;
            }
            bool flag1 = (flag ? true : context.EscapeNumbers());
            if (flag1)
            {
                trans.Write(QUOTE);
            }
            trans.Write(utf8Encoding.GetBytes(str));
            if (flag1)
            {
                trans.Write(QUOTE);
            }
        }

        private void WriteJSONInteger(long num)
        {
            context.Write();
            string str = num.ToString();
            bool flag = context.EscapeNumbers();
            if (flag)
            {
                trans.Write(QUOTE);
            }
            trans.Write(utf8Encoding.GetBytes(str));
            if (flag)
            {
                trans.Write(QUOTE);
            }
        }

        private void WriteJSONObjectEnd()
        {
            PopContext();
            trans.Write(RBRACE);
        }

        private void WriteJSONObjectStart()
        {
            context.Write();
            trans.Write(LBRACE);
            PushContext(new TJSONProtocol.JSONPairContext(this));
        }

        private void WriteJSONString(byte[] b)
        {
            context.Write();
            trans.Write(QUOTE);
            int length = (int)b.Length;
            for (int i = 0; i < length; i++)
            {
                if ((b[i] & 255) < 48)
                {
                    tempBuffer[0] = JSON_CHAR_TABLE[b[i]];
                    if (tempBuffer[0] == 1)
                    {
                        trans.Write(b, i, 1);
                    }
                    else if (tempBuffer[0] <= 1)
                    {
                        trans.Write(ESCSEQ);
                        tempBuffer[0] = HexChar((byte)(b[i] >> 4));
                        tempBuffer[1] = HexChar(b[i]);
                        trans.Write(tempBuffer, 0, 2);
                    }
                    else
                    {
                        trans.Write(BACKSLASH);
                        trans.Write(tempBuffer, 0, 1);
                    }
                }
                else if (b[i] != BACKSLASH[0])
                {
                    trans.Write(b, i, 1);
                }
                else
                {
                    trans.Write(BACKSLASH);
                    trans.Write(BACKSLASH);
                }
            }
            trans.Write(QUOTE);
        }

        public override void WriteListBegin(TList list)
        {
            WriteJSONArrayStart();
            WriteJSONString(GetTypeNameForTypeID(list.ElementType));
            WriteJSONInteger((long)list.Count);
        }

        public override void WriteListEnd()
        {
            WriteJSONArrayEnd();
        }

        public override void WriteMapBegin(TMap map)
        {
            WriteJSONArrayStart();
            WriteJSONString(GetTypeNameForTypeID(map.KeyType));
            WriteJSONString(GetTypeNameForTypeID(map.ValueType));
            WriteJSONInteger((long)map.Count);
            WriteJSONObjectStart();
        }

        public override void WriteMapEnd()
        {
            WriteJSONObjectEnd();
            WriteJSONArrayEnd();
        }

        public override void WriteMessageBegin(TMessage message)
        {
            WriteJSONArrayStart();
            WriteJSONInteger((long)1);
            WriteJSONString(utf8Encoding.GetBytes(message.Name));
            WriteJSONInteger((long)message.Type);
            WriteJSONInteger((long)message.SeqID);
        }

        public override void WriteMessageEnd()
        {
            WriteJSONArrayEnd();
        }

        public override void WriteSetBegin(TSet set)
        {
            WriteJSONArrayStart();
            WriteJSONString(GetTypeNameForTypeID(set.ElementType));
            WriteJSONInteger((long)set.Count);
        }

        public override void WriteSetEnd()
        {
            WriteJSONArrayEnd();
        }

        public override void WriteString(string str)
        {
            WriteJSONString(utf8Encoding.GetBytes(str));
        }

        public override void WriteStructBegin(TStruct str)
        {
            WriteJSONObjectStart();
        }

        public override void WriteStructEnd()
        {
            WriteJSONObjectEnd();
        }

        public class Factory : TProtocolFactory
        {
            public Factory()
            {
            }

            public TProtocol GetProtocol(TTransport trans)
            {
                return new TJSONProtocol(trans);
            }
        }

        protected class JSONBaseContext
        {
            protected TJSONProtocol proto;

            public JSONBaseContext(TJSONProtocol proto)
            {
                this.proto = proto;
            }

            public virtual bool EscapeNumbers()
            {
                return false;
            }

            public virtual void Read()
            {
            }

            public virtual void Write()
            {
            }
        }

        protected class JSONListContext : TJSONProtocol.JSONBaseContext
        {
            private bool first;

            public JSONListContext(TJSONProtocol protocol) : base(protocol)
            {
            }

            public override void Read()
            {
                if (first)
                {
                    first = false;
                    return;
                }
                proto.ReadJSONSyntaxChar(COMMA);
            }

            public override void Write()
            {
                if (first)
                {
                    first = false;
                    return;
                }
                proto.trans.Write(COMMA);
            }
        }

        protected class JSONPairContext : TJSONProtocol.JSONBaseContext
        {
            private bool first;

            private bool colon;

            public JSONPairContext(TJSONProtocol proto) : base(proto)
            {
            }

            public override bool EscapeNumbers()
            {
                return colon;
            }

            public override void Read()
            {
                if (first)
                {
                    first = false;
                    colon = true;
                    return;
                }
                proto.ReadJSONSyntaxChar((colon ? COLON : COMMA));
                colon = !colon;
            }

            public override void Write()
            {
                if (first)
                {
                    first = false;
                    colon = true;
                    return;
                }
                proto.trans.Write((colon ? COLON : COMMA));
                colon = !colon;
            }
        }

        protected class LookaheadReader
        {
            protected TJSONProtocol proto;

            private bool hasData;

            private byte[] data;

            public LookaheadReader(TJSONProtocol proto)
            {
                this.proto = proto;
            }

            public byte Peek()
            {
                if (!hasData)
                {
                    proto.trans.ReadAll(data, 0, 1);
                }
                hasData = true;
                return data[0];
            }

            public byte Read()
            {
                if (!hasData)
                {
                    proto.trans.ReadAll(data, 0, 1);
                }
                else
                {
                    hasData = false;
                }
                return data[0];
            }
        }
    }
}