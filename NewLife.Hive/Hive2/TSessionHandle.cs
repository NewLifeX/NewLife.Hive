using System;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{
    [Serializable]
    public partial class TSessionHandle : TBase
    {
        public THandleIdentifier SessionId { get; set; }

        public TSessionHandle() { }

        public TSessionHandle(THandleIdentifier sessionId) : this() => SessionId = sessionId;

        public void Read(TProtocol iprot)
        {
            var isset_sessionId = false;
            TField field;
            iprot.ReadStructBegin();
            while (true)
            {
                field = iprot.ReadFieldBegin();
                if (field.Type == TType.Stop) break;

                switch (field.ID)
                {
                    case 1:
                        if (field.Type == TType.Struct)
                        {
                            SessionId = new THandleIdentifier();
                            SessionId.Read(iprot);
                            isset_sessionId = true;
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
            if (!isset_sessionId)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TSessionHandle");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "sessionId",
                Type = TType.Struct,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            SessionId.Write(oprot);
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TSessionHandle(");
            sb.Append("SessionId: ");
            sb.Append(SessionId == null ? "<null>" : SessionId.ToString());
            sb.Append(")");
            return sb.ToString();
        }
    }
}