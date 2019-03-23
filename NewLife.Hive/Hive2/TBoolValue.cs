using System;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{
    [Serializable]
    public partial class TBoolValue : TBase
    {
        private Boolean _value;

        public Boolean Value
        {
            get
            {
                return _value;
            }
            set
            {
                __isset.value = true;
                _value = value;
            }
        }


        public Isset __isset;
        [Serializable]
        public struct Isset
        {
            public Boolean value;
        }

        public TBoolValue()
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
                        if (field.Type == TType.Bool)
                        {
                            Value = iprot.ReadBool();
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
            var struc = new TStruct("TBoolValue");
            oprot.WriteStructBegin(struc);
            var field = new TField();
            if (__isset.value)
            {
                field.Name = "value";
                field.Type = TType.Bool;
                field.ID = 1;
                oprot.WriteFieldBegin(field);
                oprot.WriteBool(Value);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TBoolValue(");
            sb.Append("Value: ");
            sb.Append(Value);
            sb.Append(")");
            return sb.ToString();
        }
    }
}