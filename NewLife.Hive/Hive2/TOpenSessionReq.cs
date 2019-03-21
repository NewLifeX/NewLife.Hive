using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TOpenSessionReq : TBase
    {
        private String _username;
        private String _password;
        private Dictionary<String, String> _configuration;

        /// <summary>
        /// 
        /// <seealso cref="TProtocolVersion"/>
        /// </summary>
        public TProtocolVersion Client_protocol { get; set; }

        public String Username
        {
            get
            {
                return _username;
            }
            set
            {
                __isset.username = true;
                _username = value;
            }
        }

        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                __isset.password = true;
                _password = value;
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
            public Boolean username;
            public Boolean password;
            public Boolean configuration;
        }

        public TOpenSessionReq()
        {
            Client_protocol = TProtocolVersion.V6;
        }

        public TOpenSessionReq(TProtocolVersion client_protocol) : this()
        {
            Client_protocol = client_protocol;
        }

        public void Read(TProtocol iprot)
        {
            var isset_client_protocol = false;
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
                        if (field.Type == TType.I32)
                        {
                            Client_protocol = (TProtocolVersion)iprot.ReadI32();
                            isset_client_protocol = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.String)
                        {
                            Username = iprot.ReadString();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.String)
                        {
                            Password = iprot.ReadString();
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
                                var _map71 = iprot.ReadMapBegin();
                                for (var _i72 = 0; _i72 < _map71.Count; ++_i72)
                                {
                                    String _key73;
                                    String _val74;
                                    _key73 = iprot.ReadString();
                                    _val74 = iprot.ReadString();
                                    Configuration[_key73] = _val74;
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
            if (!isset_client_protocol)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TOpenSessionReq");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "client_protocol",
                Type = TType.I32,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            oprot.WriteI32((Int32)Client_protocol);
            oprot.WriteFieldEnd();
            if (Username != null && __isset.username)
            {
                field.Name = "username";
                field.Type = TType.String;
                field.ID = 2;
                oprot.WriteFieldBegin(field);
                oprot.WriteString(Username);
                oprot.WriteFieldEnd();
            }
            if (Password != null && __isset.password)
            {
                field.Name = "password";
                field.Type = TType.String;
                field.ID = 3;
                oprot.WriteFieldBegin(field);
                oprot.WriteString(Password);
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
                    foreach (var _iter75 in Configuration.Keys)
                    {
                        oprot.WriteString(_iter75);
                        oprot.WriteString(Configuration[_iter75]);
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
            var sb = new StringBuilder("TOpenSessionReq(");
            sb.Append("Client_protocol: ");
            sb.Append(Client_protocol);
            sb.Append(",Username: ");
            sb.Append(Username);
            sb.Append(",Password: ");
            sb.Append(Password);
            sb.Append(",Configuration: ");
            sb.Append(Configuration);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
