using System;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{
    [Serializable]
    public partial class TCancelOperationResp : TBase
    {
        public TStatus Status { get; set; }

        public TCancelOperationResp()
        {
        }

        public TCancelOperationResp(TStatus status) : this()
        {
            Status = status;
        }

        public void Read(TProtocol iprot)
        {
            var isset_status = false;
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
                    default:
                        TProtocolUtil.Skip(iprot, field.Type);
                        break;
                }
                iprot.ReadFieldEnd();
            }
            iprot.ReadStructEnd();
            if (!isset_status)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TCancelOperationResp");
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
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TCancelOperationResp(");
            sb.Append("Status: ");
            sb.Append(Status == null ? "<null>" : Status.ToString());
            sb.Append(")");
            return sb.ToString();
        }
    }
}