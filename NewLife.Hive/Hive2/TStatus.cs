using System;
using System.Collections.Generic;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TStatus : TBase
    {
        private List<String> _infoMessages;
        private String _sqlState;
        private Int32 _errorCode;
        private String _errorMessage;

        /// <summary>
        /// 
        /// <seealso cref="TStatusCode"/>
        /// </summary>
        public TStatusCode StatusCode { get; set; }

        public List<String> InfoMessages
        {
            get
            {
                return _infoMessages;
            }
            set
            {
                __isset.infoMessages = true;
                _infoMessages = value;
            }
        }

        public String SqlState
        {
            get
            {
                return _sqlState;
            }
            set
            {
                __isset.sqlState = true;
                _sqlState = value;
            }
        }

        public Int32 ErrorCode
        {
            get
            {
                return _errorCode;
            }
            set
            {
                __isset.errorCode = true;
                _errorCode = value;
            }
        }

        public String ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                __isset.errorMessage = true;
                _errorMessage = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean infoMessages;
            public Boolean sqlState;
            public Boolean errorCode;
            public Boolean errorMessage;
        }

        public TStatus()
        {
        }

        public TStatus(TStatusCode statusCode) : this()
        {
            StatusCode = statusCode;
        }

        public void Read(TProtocol iprot)
        {
            var isset_statusCode = false;
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
                            StatusCode = (TStatusCode)iprot.ReadI32();
                            isset_statusCode = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.List)
                        {
                            {
                                InfoMessages = new List<String>();
                                var _list67 = iprot.ReadListBegin();
                                for (var _i68 = 0; _i68 < _list67.Count; ++_i68)
                                {
                                    String _elem69 = null;
                                    _elem69 = iprot.ReadString();
                                    InfoMessages.Add(_elem69);
                                }
                                iprot.ReadListEnd();
                            }
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.String)
                        {
                            SqlState = iprot.ReadString();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 4:
                        if (field.Type == TType.I32)
                        {
                            ErrorCode = iprot.ReadI32();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 5:
                        if (field.Type == TType.String)
                        {
                            ErrorMessage = iprot.ReadString();
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
            if (!isset_statusCode)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TStatus");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "statusCode",
                Type = TType.I32,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            oprot.WriteI32((Int32)StatusCode);
            oprot.WriteFieldEnd();
            if (InfoMessages != null && __isset.infoMessages)
            {
                field.Name = "infoMessages";
                field.Type = TType.List;
                field.ID = 2;
                oprot.WriteFieldBegin(field);
                {
                    oprot.WriteListBegin(new TList(TType.String, InfoMessages.Count));
                    foreach (var _iter70 in InfoMessages)
                    {
                        oprot.WriteString(_iter70);
                    }
                    oprot.WriteListEnd();
                }
                oprot.WriteFieldEnd();
            }
            if (SqlState != null && __isset.sqlState)
            {
                field.Name = "sqlState";
                field.Type = TType.String;
                field.ID = 3;
                oprot.WriteFieldBegin(field);
                oprot.WriteString(SqlState);
                oprot.WriteFieldEnd();
            }
            if (__isset.errorCode)
            {
                field.Name = "errorCode";
                field.Type = TType.I32;
                field.ID = 4;
                oprot.WriteFieldBegin(field);
                oprot.WriteI32(ErrorCode);
                oprot.WriteFieldEnd();
            }
            if (ErrorMessage != null && __isset.errorMessage)
            {
                field.Name = "errorMessage";
                field.Type = TType.String;
                field.ID = 5;
                oprot.WriteFieldBegin(field);
                oprot.WriteString(ErrorMessage);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TStatus(");
            sb.Append("StatusCode: ");
            sb.Append(StatusCode);
            sb.Append(",InfoMessages: ");
            sb.Append(InfoMessages);
            sb.Append(",SqlState: ");
            sb.Append(SqlState);
            sb.Append(",ErrorCode: ");
            sb.Append(ErrorCode);
            sb.Append(",ErrorMessage: ");
            sb.Append(ErrorMessage);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
