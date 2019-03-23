using System;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class THandleIdentifier : TBase
    {

        public Byte[] Guid { get; set; }

        public Byte[] Secret { get; set; }

        public THandleIdentifier()
        {
        }

        public THandleIdentifier(Byte[] guid, Byte[] secret) : this()
        {
            Guid = guid;
            Secret = secret;
        }

        public void Read(TProtocol iprot)
        {
            var isset_guid = false;
            var isset_secret = false;
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
                            Guid = iprot.ReadBinary();
                            isset_guid = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.String)
                        {
                            Secret = iprot.ReadBinary();
                            isset_secret = true;
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
            if (!isset_guid)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_secret)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("THandleIdentifier");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "guid",
                Type = TType.String,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            oprot.WriteBinary(Guid);
            oprot.WriteFieldEnd();
            field.Name = "secret";
            field.Type = TType.String;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            oprot.WriteBinary(Secret);
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("THandleIdentifier(");
            sb.Append("Guid: ");
            sb.Append(Guid);
            sb.Append(",Secret: ");
            sb.Append(Secret);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
