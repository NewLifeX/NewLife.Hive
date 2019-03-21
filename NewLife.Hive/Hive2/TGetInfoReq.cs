using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TGetInfoReq : TBase
    {

        public TSessionHandle SessionHandle { get; set; }

        /// <summary>
        /// 
        /// <seealso cref="TGetInfoType"/>
        /// </summary>
        public TGetInfoType InfoType { get; set; }

        public TGetInfoReq()
        {
        }

        public TGetInfoReq(TSessionHandle sessionHandle, TGetInfoType infoType) : this()
        {
            SessionHandle = sessionHandle;
            InfoType = infoType;
        }

        public void Read(TProtocol iprot)
        {
            var isset_sessionHandle = false;
            var isset_infoType = false;
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
                        if (field.Type == TType.I32)
                        {
                            InfoType = (TGetInfoType)iprot.ReadI32();
                            isset_infoType = true;
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
            if (!isset_infoType)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TGetInfoReq");
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
            field.Name = "infoType";
            field.Type = TType.I32;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            oprot.WriteI32((Int32)InfoType);
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TGetInfoReq(");
            sb.Append("SessionHandle: ");
            sb.Append(SessionHandle == null ? "<null>" : SessionHandle.ToString());
            sb.Append(",InfoType: ");
            sb.Append(InfoType);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
