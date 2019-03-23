using System;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TGetColumnsReq : TBase
    {
        private String _catalogName;
        private String _schemaName;
        private String _tableName;
        private String _columnName;

        public TSessionHandle SessionHandle { get; set; }

        public String CatalogName
        {
            get
            {
                return _catalogName;
            }
            set
            {
                __isset.catalogName = true;
                _catalogName = value;
            }
        }

        public String SchemaName
        {
            get
            {
                return _schemaName;
            }
            set
            {
                __isset.schemaName = true;
                _schemaName = value;
            }
        }

        public String TableName
        {
            get
            {
                return _tableName;
            }
            set
            {
                __isset.tableName = true;
                _tableName = value;
            }
        }

        public String ColumnName
        {
            get
            {
                return _columnName;
            }
            set
            {
                __isset.columnName = true;
                _columnName = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean catalogName;
            public Boolean schemaName;
            public Boolean tableName;
            public Boolean columnName;
        }

        public TGetColumnsReq()
        {
        }

        public TGetColumnsReq(TSessionHandle sessionHandle) : this()
        {
            SessionHandle = sessionHandle;
        }

        public void Read(TProtocol iprot)
        {
            var isset_sessionHandle = false;
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
                            CatalogName = iprot.ReadString();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.String)
                        {
                            SchemaName = iprot.ReadString();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 4:
                        if (field.Type == TType.String)
                        {
                            TableName = iprot.ReadString();
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 5:
                        if (field.Type == TType.String)
                        {
                            ColumnName = iprot.ReadString();
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
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TGetColumnsReq");
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
            if (CatalogName != null && __isset.catalogName)
            {
                field.Name = "catalogName";
                field.Type = TType.String;
                field.ID = 2;
                oprot.WriteFieldBegin(field);
                oprot.WriteString(CatalogName);
                oprot.WriteFieldEnd();
            }
            if (SchemaName != null && __isset.schemaName)
            {
                field.Name = "schemaName";
                field.Type = TType.String;
                field.ID = 3;
                oprot.WriteFieldBegin(field);
                oprot.WriteString(SchemaName);
                oprot.WriteFieldEnd();
            }
            if (TableName != null && __isset.tableName)
            {
                field.Name = "tableName";
                field.Type = TType.String;
                field.ID = 4;
                oprot.WriteFieldBegin(field);
                oprot.WriteString(TableName);
                oprot.WriteFieldEnd();
            }
            if (ColumnName != null && __isset.columnName)
            {
                field.Name = "columnName";
                field.Type = TType.String;
                field.ID = 5;
                oprot.WriteFieldBegin(field);
                oprot.WriteString(ColumnName);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TGetColumnsReq(");
            sb.Append("SessionHandle: ");
            sb.Append(SessionHandle == null ? "<null>" : SessionHandle.ToString());
            sb.Append(",CatalogName: ");
            sb.Append(CatalogName);
            sb.Append(",SchemaName: ");
            sb.Append(SchemaName);
            sb.Append(",TableName: ");
            sb.Append(TableName);
            sb.Append(",ColumnName: ");
            sb.Append(ColumnName);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
