using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TGetOperationStatusResp : TBase
    {
        private TOperationState _operationState;
        private String _sqlState;
        private Int32 _errorCode;
        private String _errorMessage;

        public TStatus Status { get; set; }

        /// <summary>
        /// 
        /// <seealso cref="TOperationState"/>
        /// </summary>
        public TOperationState OperationState
        {
            get
            {
                return _operationState;
            }
            set
            {
                __isset.operationState = true;
                _operationState = value;
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
            public Boolean operationState;
            public Boolean sqlState;
            public Boolean errorCode;
            public Boolean errorMessage;
        }

        public TGetOperationStatusResp()
        {
        }

        public TGetOperationStatusResp(TStatus status) : this()
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
                    case 2:
                        if (field.Type == TType.I32)
                        {
                            OperationState = (TOperationState)iprot.ReadI32();
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
            if (!isset_status)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TGetOperationStatusResp");
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
            if (__isset.operationState)
            {
                field.Name = "operationState";
                field.Type = TType.I32;
                field.ID = 2;
                oprot.WriteFieldBegin(field);
                oprot.WriteI32((Int32)OperationState);
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
            var sb = new StringBuilder("TGetOperationStatusResp(");
            sb.Append("Status: ");
            sb.Append(Status == null ? "<null>" : Status.ToString());
            sb.Append(",OperationState: ");
            sb.Append(OperationState);
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
