using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TTypeQualifierValue : TBase
    {
        private Int32 _i32Value;
        private String _stringValue;

        public Int32 I32Value
        {
            get
            {
                return _i32Value;
            }
            set
            {
                __isset.i32Value = true;
                _i32Value = value;
            }
        }

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


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean i32Value;
            public Boolean stringValue;
        }

        public TTypeQualifierValue()
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
                        if (field.Type == TType.I32)
                        {
                            I32Value = iprot.ReadI32();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.String)
                        {
                            StringValue = iprot.ReadString();
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
            var struc = new TStruct("TTypeQualifierValue");
            oprot.WriteStructBegin(struc);
            var field = new TField();
            if (__isset.i32Value)
            {
                field.Name = "i32Value";
                field.Type = TType.I32;
                field.ID = 1;
                oprot.WriteFieldBegin(field);
                oprot.WriteI32(I32Value);
                oprot.WriteFieldEnd();
            }
            if (StringValue != null && __isset.stringValue)
            {
                field.Name = "stringValue";
                field.Type = TType.String;
                field.ID = 2;
                oprot.WriteFieldBegin(field);
                oprot.WriteString(StringValue);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TTypeQualifierValue(");
            sb.Append("I32Value: ");
            sb.Append(I32Value);
            sb.Append(",StringValue: ");
            sb.Append(StringValue);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
