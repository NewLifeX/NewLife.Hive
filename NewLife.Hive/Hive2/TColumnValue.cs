using System;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{
    [Serializable]
    public partial class TColumnValue : TBase
    {
        private TBoolValue _boolVal;
        private TByteValue _byteVal;
        private TI16Value _i16Val;
        private TI32Value _i32Val;
        private TI64Value _i64Val;
        private TDoubleValue _doubleVal;
        private TStringValue _stringVal;

        public TBoolValue BoolVal
        {
            get
            {
                return _boolVal;
            }
            set
            {
                __isset.boolVal = true;
                _boolVal = value;
            }
        }

        public TByteValue ByteVal
        {
            get
            {
                return _byteVal;
            }
            set
            {
                __isset.byteVal = true;
                _byteVal = value;
            }
        }

        public TI16Value I16Val
        {
            get
            {
                return _i16Val;
            }
            set
            {
                __isset.i16Val = true;
                _i16Val = value;
            }
        }

        public TI32Value I32Val
        {
            get
            {
                return _i32Val;
            }
            set
            {
                __isset.i32Val = true;
                _i32Val = value;
            }
        }

        public TI64Value I64Val
        {
            get
            {
                return _i64Val;
            }
            set
            {
                __isset.i64Val = true;
                _i64Val = value;
            }
        }

        public TDoubleValue DoubleVal
        {
            get
            {
                return _doubleVal;
            }
            set
            {
                __isset.doubleVal = true;
                _doubleVal = value;
            }
        }

        public TStringValue StringVal
        {
            get
            {
                return _stringVal;
            }
            set
            {
                __isset.stringVal = true;
                _stringVal = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean boolVal;
            public Boolean byteVal;
            public Boolean i16Val;
            public Boolean i32Val;
            public Boolean i64Val;
            public Boolean doubleVal;
            public Boolean stringVal;
        }

        public TColumnValue()
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
                        if (field.Type == TType.Struct)
                        {
                            BoolVal = new TBoolValue();
                            BoolVal.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.Struct)
                        {
                            ByteVal = new TByteValue();
                            ByteVal.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.Struct)
                        {
                            I16Val = new TI16Value();
                            I16Val.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 4:
                        if (field.Type == TType.Struct)
                        {
                            I32Val = new TI32Value();
                            I32Val.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 5:
                        if (field.Type == TType.Struct)
                        {
                            I64Val = new TI64Value();
                            I64Val.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 6:
                        if (field.Type == TType.Struct)
                        {
                            DoubleVal = new TDoubleValue();
                            DoubleVal.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 7:
                        if (field.Type == TType.Struct)
                        {
                            StringVal = new TStringValue();
                            StringVal.Read(iprot);
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
            var struc = new TStruct("TColumnValue");
            oprot.WriteStructBegin(struc);
            var field = new TField();
            if (BoolVal != null && __isset.boolVal)
            {
                field.Name = "boolVal";
                field.Type = TType.Struct;
                field.ID = 1;
                oprot.WriteFieldBegin(field);
                BoolVal.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (ByteVal != null && __isset.byteVal)
            {
                field.Name = "byteVal";
                field.Type = TType.Struct;
                field.ID = 2;
                oprot.WriteFieldBegin(field);
                ByteVal.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (I16Val != null && __isset.i16Val)
            {
                field.Name = "i16Val";
                field.Type = TType.Struct;
                field.ID = 3;
                oprot.WriteFieldBegin(field);
                I16Val.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (I32Val != null && __isset.i32Val)
            {
                field.Name = "i32Val";
                field.Type = TType.Struct;
                field.ID = 4;
                oprot.WriteFieldBegin(field);
                I32Val.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (I64Val != null && __isset.i64Val)
            {
                field.Name = "i64Val";
                field.Type = TType.Struct;
                field.ID = 5;
                oprot.WriteFieldBegin(field);
                I64Val.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (DoubleVal != null && __isset.doubleVal)
            {
                field.Name = "doubleVal";
                field.Type = TType.Struct;
                field.ID = 6;
                oprot.WriteFieldBegin(field);
                DoubleVal.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (StringVal != null && __isset.stringVal)
            {
                field.Name = "stringVal";
                field.Type = TType.Struct;
                field.ID = 7;
                oprot.WriteFieldBegin(field);
                StringVal.Write(oprot);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TColumnValue(");
            sb.Append("BoolVal: ");
            sb.Append(BoolVal == null ? "<null>" : BoolVal.ToString());
            sb.Append(",ByteVal: ");
            sb.Append(ByteVal == null ? "<null>" : ByteVal.ToString());
            sb.Append(",I16Val: ");
            sb.Append(I16Val == null ? "<null>" : I16Val.ToString());
            sb.Append(",I32Val: ");
            sb.Append(I32Val == null ? "<null>" : I32Val.ToString());
            sb.Append(",I64Val: ");
            sb.Append(I64Val == null ? "<null>" : I64Val.ToString());
            sb.Append(",DoubleVal: ");
            sb.Append(DoubleVal == null ? "<null>" : DoubleVal.ToString());
            sb.Append(",StringVal: ");
            sb.Append(StringVal == null ? "<null>" : StringVal.ToString());
            sb.Append(")");
            return sb.ToString();
        }

    }

}
