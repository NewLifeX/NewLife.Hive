using System;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{
    [Serializable]
    public partial class TColumn : TBase
    {
        private TBoolColumn _boolVal;
        private TByteColumn _byteVal;
        private TI16Column _i16Val;
        private TI32Column _i32Val;
        private TI64Column _i64Val;
        private TDoubleColumn _doubleVal;
        private TStringColumn _stringVal;
        private TBinaryColumn _binaryVal;

        public TBoolColumn BoolVal
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

        public TByteColumn ByteVal
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

        public TI16Column I16Val
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

        public TI32Column I32Val
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

        public TI64Column I64Val
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

        public TDoubleColumn DoubleVal
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

        public TStringColumn StringVal
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

        public TBinaryColumn BinaryVal
        {
            get
            {
                return _binaryVal;
            }
            set
            {
                __isset.binaryVal = true;
                _binaryVal = value;
            }
        }


        public Isset __isset;
        [Serializable]
        public struct Isset
        {
            public Boolean boolVal;
            public Boolean byteVal;
            public Boolean i16Val;
            public Boolean i32Val;
            public Boolean i64Val;
            public Boolean doubleVal;
            public Boolean stringVal;
            public Boolean binaryVal;
        }

        public TColumn()
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
                            BoolVal = new TBoolColumn();
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
                            ByteVal = new TByteColumn();
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
                            I16Val = new TI16Column();
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
                            I32Val = new TI32Column();
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
                            I64Val = new TI64Column();
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
                            DoubleVal = new TDoubleColumn();
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
                            StringVal = new TStringColumn();
                            StringVal.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 8:
                        if (field.Type == TType.Struct)
                        {
                            BinaryVal = new TBinaryColumn();
                            BinaryVal.Read(iprot);
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
            var struc = new TStruct("TColumn");
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
            if (BinaryVal != null && __isset.binaryVal)
            {
                field.Name = "binaryVal";
                field.Type = TType.Struct;
                field.ID = 8;
                oprot.WriteFieldBegin(field);
                BinaryVal.Write(oprot);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TColumn(");
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
            sb.Append(",BinaryVal: ");
            sb.Append(BinaryVal == null ? "<null>" : BinaryVal.ToString());
            sb.Append(")");
            return sb.ToString();
        }
    }
}