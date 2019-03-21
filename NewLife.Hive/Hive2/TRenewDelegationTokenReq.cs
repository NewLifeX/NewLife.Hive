using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TRenewDelegationTokenReq : TBase
    {

        public TSessionHandle SessionHandle { get; set; }

        public String DelegationToken { get; set; }

        public TRenewDelegationTokenReq()
        {
        }

        public TRenewDelegationTokenReq(TSessionHandle sessionHandle, String delegationToken) : this()
        {
            SessionHandle = sessionHandle;
            DelegationToken = delegationToken;
        }

        public void Read(TProtocol iprot)
        {
            var isset_sessionHandle = false;
            var isset_delegationToken = false;
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
                            DelegationToken = iprot.ReadString();
                            isset_delegationToken = true;
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
            if (!isset_delegationToken)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TRenewDelegationTokenReq");
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
            field.Name = "delegationToken";
            field.Type = TType.String;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            oprot.WriteString(DelegationToken);
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TRenewDelegationTokenReq(");
            sb.Append("SessionHandle: ");
            sb.Append(SessionHandle == null ? "<null>" : SessionHandle.ToString());
            sb.Append(",DelegationToken: ");
            sb.Append(DelegationToken);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
