using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TOperationHandle : TBase
    {
        private Double _modifiedRowCount;

        public THandleIdentifier OperationId { get; set; }

        /// <summary>
        /// 
        /// <seealso cref="TOperationType"/>
        /// </summary>
        public TOperationType OperationType { get; set; }

        public Boolean HasResultSet { get; set; }

        public Double ModifiedRowCount
        {
            get
            {
                return _modifiedRowCount;
            }
            set
            {
                __isset.modifiedRowCount = true;
                _modifiedRowCount = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean modifiedRowCount;
        }

        public TOperationHandle()
        {
        }

        public TOperationHandle(THandleIdentifier operationId, TOperationType operationType, Boolean hasResultSet) : this()
        {
            OperationId = operationId;
            OperationType = operationType;
            HasResultSet = hasResultSet;
        }

        public void Read(TProtocol iprot)
        {
            var isset_operationId = false;
            var isset_operationType = false;
            var isset_hasResultSet = false;
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
                            OperationId = new THandleIdentifier();
                            OperationId.Read(iprot);
                            isset_operationId = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.I32)
                        {
                            OperationType = (TOperationType)iprot.ReadI32();
                            isset_operationType = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.Bool)
                        {
                            HasResultSet = iprot.ReadBool();
                            isset_hasResultSet = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 4:
                        if (field.Type == TType.Double)
                        {
                            ModifiedRowCount = iprot.ReadDouble();
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
            if (!isset_operationId)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_operationType)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_hasResultSet)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TOperationHandle");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "operationId",
                Type = TType.Struct,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            OperationId.Write(oprot);
            oprot.WriteFieldEnd();
            field.Name = "operationType";
            field.Type = TType.I32;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            oprot.WriteI32((Int32)OperationType);
            oprot.WriteFieldEnd();
            field.Name = "hasResultSet";
            field.Type = TType.Bool;
            field.ID = 3;
            oprot.WriteFieldBegin(field);
            oprot.WriteBool(HasResultSet);
            oprot.WriteFieldEnd();
            if (__isset.modifiedRowCount)
            {
                field.Name = "modifiedRowCount";
                field.Type = TType.Double;
                field.ID = 4;
                oprot.WriteFieldBegin(field);
                oprot.WriteDouble(ModifiedRowCount);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TOperationHandle(");
            sb.Append("OperationId: ");
            sb.Append(OperationId == null ? "<null>" : OperationId.ToString());
            sb.Append(",OperationType: ");
            sb.Append(OperationType);
            sb.Append(",HasResultSet: ");
            sb.Append(HasResultSet);
            sb.Append(",ModifiedRowCount: ");
            sb.Append(ModifiedRowCount);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
