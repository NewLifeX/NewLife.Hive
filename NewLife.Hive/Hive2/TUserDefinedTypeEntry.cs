using System;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TUserDefinedTypeEntry : TBase
    {

        public String TypeClassName { get; set; }

        public TUserDefinedTypeEntry()
        {
        }

        public TUserDefinedTypeEntry(String typeClassName) : this()
        {
            TypeClassName = typeClassName;
        }

        public void Read(TProtocol iprot)
        {
            var isset_typeClassName = false;
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
                            TypeClassName = iprot.ReadString();
                            isset_typeClassName = true;
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
            if (!isset_typeClassName)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TUserDefinedTypeEntry");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "typeClassName",
                Type = TType.String,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            oprot.WriteString(TypeClassName);
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TUserDefinedTypeEntry(");
            sb.Append("TypeClassName: ");
            sb.Append(TypeClassName);
            sb.Append(")");
            return sb.ToString();
        }
    }
}