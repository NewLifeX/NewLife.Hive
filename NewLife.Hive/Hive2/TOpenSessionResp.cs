using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TOpenSessionResp : TBase
    {
        private TSessionHandle _sessionHandle;
        private Dictionary<String, String> _configuration;

        public TStatus Status { get; set; }

        /// <summary>
        /// 
        /// <seealso cref="TProtocolVersion"/>
        /// </summary>
        public TProtocolVersion ServerProtocolVersion { get; set; }

        public TSessionHandle SessionHandle
        {
            get
            {
                return _sessionHandle;
            }
            set
            {
                __isset.sessionHandle = true;
                _sessionHandle = value;
            }
        }

        public Dictionary<String, String> Configuration
        {
            get
            {
                return _configuration;
            }
            set
            {
                __isset.configuration = true;
                _configuration = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean sessionHandle;
            public Boolean configuration;
        }

        public TOpenSessionResp()
        {
            ServerProtocolVersion = TProtocolVersion.V6;
        }

        public TOpenSessionResp(TStatus status, TProtocolVersion serverProtocolVersion) : this()
        {
            Status = status;
            ServerProtocolVersion = serverProtocolVersion;
        }

        public void Read(TProtocol iprot)
        {
            var isset_status = false;
            var isset_serverProtocolVersion = false;
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
                        if (field.Type == TType.I32)
                        {
                            ServerProtocolVersion = (TProtocolVersion)iprot.ReadI32();
                            isset_serverProtocolVersion = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.Struct)
                        {
                            SessionHandle = new TSessionHandle();
                            SessionHandle.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 4:
                        if (field.Type == TType.Map)
                        {
                            {
                                Configuration = new Dictionary<String, String>();
                                var _map76 = iprot.ReadMapBegin();
                                for (var _i77 = 0; _i77 < _map76.Count; ++_i77)
                                {
                                    String _key78;
                                    String _val79;
                                    _key78 = iprot.ReadString();
                                    _val79 = iprot.ReadString();
                                    Configuration[_key78] = _val79;
                                }
                                iprot.ReadMapEnd();
                            }
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
            if (!isset_serverProtocolVersion)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TOpenSessionResp");
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
            field.Name = "serverProtocolVersion";
            field.Type = TType.I32;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            oprot.WriteI32((Int32)ServerProtocolVersion);
            oprot.WriteFieldEnd();
            if (SessionHandle != null && __isset.sessionHandle)
            {
                field.Name = "sessionHandle";
                field.Type = TType.Struct;
                field.ID = 3;
                oprot.WriteFieldBegin(field);
                SessionHandle.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (Configuration != null && __isset.configuration)
            {
                field.Name = "configuration";
                field.Type = TType.Map;
                field.ID = 4;
                oprot.WriteFieldBegin(field);
                {
                    oprot.WriteMapBegin(new TMap(TType.String, TType.String, Configuration.Count));
                    foreach (var _iter80 in Configuration.Keys)
                    {
                        oprot.WriteString(_iter80);
                        oprot.WriteString(Configuration[_iter80]);
                    }
                    oprot.WriteMapEnd();
                }
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TOpenSessionResp(");
            sb.Append("Status: ");
            sb.Append(Status == null ? "<null>" : Status.ToString());
            sb.Append(",ServerProtocolVersion: ");
            sb.Append(ServerProtocolVersion);
            sb.Append(",SessionHandle: ");
            sb.Append(SessionHandle == null ? "<null>" : SessionHandle.ToString());
            sb.Append(",Configuration: ");
            sb.Append(Configuration);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
