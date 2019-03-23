using System;
using System.Collections.Generic;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{
    [Serializable]
    public partial class TRowSet : TBase
    {
        private List<TColumn> _columns;

        public Int64 StartRowOffset { get; set; }

        public List<TRow> Rows { get; set; }

        public List<TColumn> Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                __isset.columns = true;
                _columns = value;
            }
        }


        public Isset __isset;
        [Serializable]
        public struct Isset
        {
            public Boolean columns;
        }

        public TRowSet() { }

        public TRowSet(Int64 startRowOffset, List<TRow> rows) : this()
        {
            StartRowOffset = startRowOffset;
            Rows = rows;
        }

        public void Read(TProtocol iprot)
        {
            var isset_startRowOffset = false;
            var isset_rows = false;
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
                        if (field.Type == TType.I64)
                        {
                            StartRowOffset = iprot.ReadI64();
                            isset_startRowOffset = true;
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
                                Rows = new List<TRow>();
                                var _list59 = iprot.ReadListBegin();
                                for (var _i60 = 0; _i60 < _list59.Count; ++_i60)
                                {
                                    var _elem61 = new TRow();
                                    _elem61 = new TRow();
                                    _elem61.Read(iprot);
                                    Rows.Add(_elem61);
                                }
                                iprot.ReadListEnd();
                            }
                            isset_rows = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.List)
                        {
                            {
                                Columns = new List<TColumn>();
                                var _list62 = iprot.ReadListBegin();
                                for (var _i63 = 0; _i63 < _list62.Count; ++_i63)
                                {
                                    var _elem64 = new TColumn();
                                    _elem64 = new TColumn();
                                    _elem64.Read(iprot);
                                    Columns.Add(_elem64);
                                }
                                iprot.ReadListEnd();
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
            if (!isset_startRowOffset)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_rows)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TRowSet");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "startRowOffset",
                Type = TType.I64,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            oprot.WriteI64(StartRowOffset);
            oprot.WriteFieldEnd();
            field.Name = "rows";
            field.Type = TType.List;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            {
                oprot.WriteListBegin(new TList(TType.Struct, Rows.Count));
                foreach (var _iter65 in Rows)
                {
                    _iter65.Write(oprot);
                }
                oprot.WriteListEnd();
            }
            oprot.WriteFieldEnd();
            if (Columns != null && __isset.columns)
            {
                field.Name = "columns";
                field.Type = TType.List;
                field.ID = 3;
                oprot.WriteFieldBegin(field);
                {
                    oprot.WriteListBegin(new TList(TType.Struct, Columns.Count));
                    foreach (var _iter66 in Columns)
                    {
                        _iter66.Write(oprot);
                    }
                    oprot.WriteListEnd();
                }
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TRowSet(");
            sb.Append("StartRowOffset: ");
            sb.Append(StartRowOffset);
            sb.Append(",Rows: ");
            sb.Append(Rows);
            sb.Append(",Columns: ");
            sb.Append(Columns);
            sb.Append(")");
            return sb.ToString();
        }
    }
}