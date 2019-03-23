using System;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{
    [Serializable]
    public partial class TFetchResultsResp : TBase
    {
        private Boolean _hasMoreRows;
        private TRowSet _results;

        public TStatus Status { get; set; }

        public Boolean HasMoreRows
        {
            get
            {
                return _hasMoreRows;
            }
            set
            {
                __isset.hasMoreRows = true;
                _hasMoreRows = value;
            }
        }

        public TRowSet Results
        {
            get
            {
                return _results;
            }
            set
            {
                __isset.results = true;
                _results = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean hasMoreRows;
            public Boolean results;
        }

        public TFetchResultsResp()
        {
        }

        public TFetchResultsResp(TStatus status) : this()
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
                        if (field.Type == TType.Bool)
                        {
                            HasMoreRows = iprot.ReadBool();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.Struct)
                        {
                            Results = new TRowSet();
                            Results.Read(iprot);
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
            var struc = new TStruct("TFetchResultsResp");
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
            if (__isset.hasMoreRows)
            {
                field.Name = "hasMoreRows";
                field.Type = TType.Bool;
                field.ID = 2;
                oprot.WriteFieldBegin(field);
                oprot.WriteBool(HasMoreRows);
                oprot.WriteFieldEnd();
            }
            if (Results != null && __isset.results)
            {
                field.Name = "results";
                field.Type = TType.Struct;
                field.ID = 3;
                oprot.WriteFieldBegin(field);
                Results.Write(oprot);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TFetchResultsResp(");
            sb.Append("Status: ");
            sb.Append(Status == null ? "<null>" : Status.ToString());
            sb.Append(",HasMoreRows: ");
            sb.Append(HasMoreRows);
            sb.Append(",Results: ");
            sb.Append(Results == null ? "<null>" : Results.ToString());
            sb.Append(")");
            return sb.ToString();
        }

    }

}
