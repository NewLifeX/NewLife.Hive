using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TFetchResultsReq : TBase
    {

        public TOperationHandle OperationHandle { get; set; }

        /// <summary>
        /// 
        /// <seealso cref="TFetchOrientation"/>
        /// </summary>
        public TFetchOrientation Orientation { get; set; }

        public Int64 MaxRows { get; set; }

        public TFetchResultsReq()
        {
            Orientation = TFetchOrientation.FETCH_NEXT;
        }

        public TFetchResultsReq(TOperationHandle operationHandle, TFetchOrientation orientation, Int64 maxRows) : this()
        {
            OperationHandle = operationHandle;
            Orientation = orientation;
            MaxRows = maxRows;
        }

        public void Read(TProtocol iprot)
        {
            var isset_operationHandle = false;
            var isset_orientation = false;
            var isset_maxRows = false;
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
                            OperationHandle = new TOperationHandle();
                            OperationHandle.Read(iprot);
                            isset_operationHandle = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.I32)
                        {
                            Orientation = (TFetchOrientation)iprot.ReadI32();
                            isset_orientation = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.I64)
                        {
                            MaxRows = iprot.ReadI64();
                            isset_maxRows = true;
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
            if (!isset_operationHandle)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_orientation)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_maxRows)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TFetchResultsReq");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "operationHandle",
                Type = TType.Struct,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            OperationHandle.Write(oprot);
            oprot.WriteFieldEnd();
            field.Name = "orientation";
            field.Type = TType.I32;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            oprot.WriteI32((Int32)Orientation);
            oprot.WriteFieldEnd();
            field.Name = "maxRows";
            field.Type = TType.I64;
            field.ID = 3;
            oprot.WriteFieldBegin(field);
            oprot.WriteI64(MaxRows);
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TFetchResultsReq(");
            sb.Append("OperationHandle: ");
            sb.Append(OperationHandle == null ? "<null>" : OperationHandle.ToString());
            sb.Append(",Orientation: ");
            sb.Append(Orientation);
            sb.Append(",MaxRows: ");
            sb.Append(MaxRows);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
