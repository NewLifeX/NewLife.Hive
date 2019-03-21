using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TGetDelegationTokenReq : TBase
    {

        public TSessionHandle SessionHandle { get; set; }

        public String Owner { get; set; }

        public String Renewer { get; set; }

        public TGetDelegationTokenReq()
        {
        }

        public TGetDelegationTokenReq(TSessionHandle sessionHandle, String owner, String renewer) : this()
        {
            SessionHandle = sessionHandle;
            Owner = owner;
            Renewer = renewer;
        }

        public void Read(TProtocol iprot)
        {
            var isset_sessionHandle = false;
            var isset_owner = false;
            var isset_renewer = false;
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
                            SessionHandle = new TSessionHandle();
                            SessionHandle.Read(iprot);
                            isset_sessionHandle = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.String)
                        {
                            Owner = iprot.ReadString();
                            isset_owner = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.String)
                        {
                            Renewer = iprot.ReadString();
                            isset_renewer = true;
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
            if (!isset_sessionHandle)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_owner)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_renewer)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TGetDelegationTokenReq");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "sessionHandle",
                Type = TType.Struct,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            SessionHandle.Write(oprot);
            oprot.WriteFieldEnd();
            field.Name = "owner";
            field.Type = TType.String;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            oprot.WriteString(Owner);
            oprot.WriteFieldEnd();
            field.Name = "renewer";
            field.Type = TType.String;
            field.ID = 3;
            oprot.WriteFieldBegin(field);
            oprot.WriteString(Renewer);
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TGetDelegationTokenReq(");
            sb.Append("SessionHandle: ");
            sb.Append(SessionHandle == null ? "<null>" : SessionHandle.ToString());
            sb.Append(",Owner: ");
            sb.Append(Owner);
            sb.Append(",Renewer: ");
            sb.Append(Renewer);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
