using System;
using System.Collections.Generic;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{
    [Serializable]
    public partial class TExecuteStatementReq : TBase
    {
        private Dictionary<String, String> _confOverlay;
        private Boolean _runAsync;

        public TSessionHandle SessionHandle { get; set; }

        public String Statement { get; set; }

        public Dictionary<String, String> ConfOverlay
        {
            get
            {
                return _confOverlay;
            }
            set
            {
                __isset.confOverlay = true;
                _confOverlay = value;
            }
        }

        public Boolean RunAsync
        {
            get
            {
                return _runAsync;
            }
            set
            {
                __isset.runAsync = true;
                _runAsync = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean confOverlay;
            public Boolean runAsync;
        }

        public TExecuteStatementReq()
        {
            _runAsync = false;
            __isset.runAsync = true;
        }

        public TExecuteStatementReq(TSessionHandle sessionHandle, String statement) : this()
        {
            SessionHandle = sessionHandle;
            Statement = statement;
        }

        public void Read(TProtocol iprot)
        {
            var isset_sessionHandle = false;
            var isset_statement = false;
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
                            Statement = iprot.ReadString();
                            isset_statement = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.Map)
                        {
                            {
                                ConfOverlay = new Dictionary<String, String>();
                                var _map81 = iprot.ReadMapBegin();
                                for (var _i82 = 0; _i82 < _map81.Count; ++_i82)
                                {
                                    String _key83;
                                    String _val84;
                                    _key83 = iprot.ReadString();
                                    _val84 = iprot.ReadString();
                                    ConfOverlay[_key83] = _val84;
                                }
                                iprot.ReadMapEnd();
                            }
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 4:
                        if (field.Type == TType.Bool)
                        {
                            RunAsync = iprot.ReadBool();
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
            if (!isset_statement)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TExecuteStatementReq");
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
            field.Name = "statement";
            field.Type = TType.String;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            oprot.WriteString(Statement);
            oprot.WriteFieldEnd();
            if (ConfOverlay != null && __isset.confOverlay)
            {
                field.Name = "confOverlay";
                field.Type = TType.Map;
                field.ID = 3;
                oprot.WriteFieldBegin(field);
                {
                    oprot.WriteMapBegin(new TMap(TType.String, TType.String, ConfOverlay.Count));
                    foreach (var _iter85 in ConfOverlay.Keys)
                    {
                        oprot.WriteString(_iter85);
                        oprot.WriteString(ConfOverlay[_iter85]);
                    }
                    oprot.WriteMapEnd();
                }
                oprot.WriteFieldEnd();
            }
            if (__isset.runAsync)
            {
                field.Name = "runAsync";
                field.Type = TType.Bool;
                field.ID = 4;
                oprot.WriteFieldBegin(field);
                oprot.WriteBool(RunAsync);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TExecuteStatementReq(");
            sb.Append("SessionHandle: ");
            sb.Append(SessionHandle == null ? "<null>" : SessionHandle.ToString());
            sb.Append(",Statement: ");
            sb.Append(Statement);
            sb.Append(",ConfOverlay: ");
            sb.Append(ConfOverlay);
            sb.Append(",RunAsync: ");
            sb.Append(RunAsync);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
