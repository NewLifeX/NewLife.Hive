using System;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TGetInfoValue : TBase
    {
        private String _stringValue;
        private Int16 _smallIntValue;
        private Int32 _integerBitmask;
        private Int32 _integerFlag;
        private Int32 _binaryValue;
        private Int64 _lenValue;

        public String StringValue
        {
            get
            {
                return _stringValue;
            }
            set
            {
                __isset.stringValue = true;
                _stringValue = value;
            }
        }

        public Int16 SmallIntValue
        {
            get
            {
                return _smallIntValue;
            }
            set
            {
                __isset.smallIntValue = true;
                _smallIntValue = value;
            }
        }

        public Int32 IntegerBitmask
        {
            get
            {
                return _integerBitmask;
            }
            set
            {
                __isset.integerBitmask = true;
                _integerBitmask = value;
            }
        }

        public Int32 IntegerFlag
        {
            get
            {
                return _integerFlag;
            }
            set
            {
                __isset.integerFlag = true;
                _integerFlag = value;
            }
        }

        public Int32 BinaryValue
        {
            get
            {
                return _binaryValue;
            }
            set
            {
                __isset.binaryValue = true;
                _binaryValue = value;
            }
        }

        public Int64 LenValue
        {
            get
            {
                return _lenValue;
            }
            set
            {
                __isset.lenValue = true;
                _lenValue = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean stringValue;
            public Boolean smallIntValue;
            public Boolean integerBitmask;
            public Boolean integerFlag;
            public Boolean binaryValue;
            public Boolean lenValue;
        }

        public TGetInfoValue()
        {
        }

        public void Read(TProtocol iprot)
        {
            TField field;
            iprot.ReadStructBegin();
            while (true)
            {
                field = iprot.ReadFieldBegin();
                if (field.Type == TType.Stop)
                {
                    break;
                }
                switch (field.ID)
                {
                    case 1:
                        if (field.Type == TType.String)
                        {
                            StringValue = iprot.ReadString();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.I16)
                        {
                            SmallIntValue = iprot.ReadI16();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.I32)
                        {
                            IntegerBitmask = iprot.ReadI32();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 4:
                        if (field.Type == TType.I32)
                        {
                            IntegerFlag = iprot.ReadI32();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 5:
                        if (field.Type == TType.I32)
                        {
                            BinaryValue = iprot.ReadI32();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 6:
                        if (field.Type == TType.I64)
                        {
                            LenValue = iprot.ReadI64();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    default:
                        TProtocolUtil.Skip(iprot, field.Type);
                        break;
                }
                iprot.ReadFieldEnd();
            }
            iprot.ReadStructEnd();
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TGetInfoValue");
            oprot.WriteStructBegin(struc);
            var field = new TField();
            if (StringValue != null && __isset.stringValue)
            {
                field.Name = "stringValue";
                field.Type = TType.String;
                field.ID = 1;
                oprot.WriteFieldBegin(field);
                oprot.WriteString(StringValue);
                oprot.WriteFieldEnd();
            }
            if (__isset.smallIntValue)
            {
                field.Name = "smallIntValue";
                field.Type = TType.I16;
                field.ID = 2;
                oprot.WriteFieldBegin(field);
                oprot.WriteI16(SmallIntValue);
                oprot.WriteFieldEnd();
            }
            if (__isset.integerBitmask)
            {
                field.Name = "integerBitmask";
                field.Type = TType.I32;
                field.ID = 3;
                oprot.WriteFieldBegin(field);
                oprot.WriteI32(IntegerBitmask);
                oprot.WriteFieldEnd();
            }
            if (__isset.integerFlag)
            {
                field.Name = "integerFlag";
                field.Type = TType.I32;
                field.ID = 4;
                oprot.WriteFieldBegin(field);
                oprot.WriteI32(IntegerFlag);
                oprot.WriteFieldEnd();
            }
            if (__isset.binaryValue)
            {
                field.Name = "binaryValue";
                field.Type = TType.I32;
                field.ID = 5;
                oprot.WriteFieldBegin(field);
                oprot.WriteI32(BinaryValue);
                oprot.WriteFieldEnd();
            }
            if (__isset.lenValue)
            {
                field.Name = "lenValue";
                field.Type = TType.I64;
                field.ID = 6;
                oprot.WriteFieldBegin(field);
                oprot.WriteI64(LenValue);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TGetInfoValue(");
            sb.Append("StringValue: ");
            sb.Append(StringValue);
            sb.Append(",SmallIntValue: ");
            sb.Append(SmallIntValue);
            sb.Append(",IntegerBitmask: ");
            sb.Append(IntegerBitmask);
            sb.Append(",IntegerFlag: ");
            sb.Append(IntegerFlag);
            sb.Append(",BinaryValue: ");
            sb.Append(BinaryValue);
            sb.Append(",LenValue: ");
            sb.Append(LenValue);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
