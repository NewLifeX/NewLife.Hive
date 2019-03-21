using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TGetInfoResp : TBase
    {

        public TStatus Status { get; set; }

        public TGetInfoValue InfoValue { get; set; }

        public TGetInfoResp()
        {
        }

        public TGetInfoResp(TStatus status, TGetInfoValue infoValue) : this()
        {
            Status = status;
            InfoValue = infoValue;
        }

        public void Read(TProtocol iprot)
        {
            var isset_status = false;
            var isset_infoValue = false;
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
                            Status = new TStatus();
                            Status.Read(iprot);
                            isset_status = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.Struct)
                        {
                            InfoValue = new TGetInfoValue();
                            InfoValue.Read(iprot);
                            isset_infoValue = true;
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
            if (!isset_status)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_infoValue)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TGetInfoResp");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "status",
                Type = TType.Struct,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            Status.Write(oprot);
            oprot.WriteFieldEnd();
            field.Name = "infoValue";
            field.Type = TType.Struct;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            InfoValue.Write(oprot);
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TGetInfoResp(");
            sb.Append("Status: ");
            sb.Append(Status == null ? "<null>" : Status.ToString());
            sb.Append(",InfoValue: ");
            sb.Append(InfoValue == null ? "<null>" : InfoValue.ToString());
            sb.Append(")");
            return sb.ToString();
        }

    }

}
