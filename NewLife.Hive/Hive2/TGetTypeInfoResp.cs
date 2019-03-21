using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TGetTypeInfoResp : TBase
    {
        private TOperationHandle _operationHandle;

        public TStatus Status { get; set; }

        public TOperationHandle OperationHandle
        {
            get
            {
                return _operationHandle;
            }
            set
            {
                __isset.operationHandle = true;
                _operationHandle = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean operationHandle;
        }

        public TGetTypeInfoResp()
        {
        }

        public TGetTypeInfoResp(TStatus status) : this()
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
                        if (field.Type == TType.Struct)
                        {
                            OperationHandle = new TOperationHandle();
                            OperationHandle.Read(iprot);
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
            var struc = new TStruct("TGetTypeInfoResp");
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
            if (OperationHandle != null && __isset.operationHandle)
            {
                field.Name = "operationHandle";
                field.Type = TType.Struct;
                field.ID = 2;
                oprot.WriteFieldBegin(field);
                OperationHandle.Write(oprot);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TGetTypeInfoResp(");
            sb.Append("Status: ");
            sb.Append(Status == null ? "<null>" : Status.ToString());
            sb.Append(",OperationHandle: ");
            sb.Append(OperationHandle == null ? "<null>" : OperationHandle.ToString());
            sb.Append(")");
            return sb.ToString();
        }

    }

}
