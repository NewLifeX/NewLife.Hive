using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TTableSchema : TBase
    {

        public List<TColumnDesc> Columns { get; set; }

        public TTableSchema()
        {
        }

        public TTableSchema(List<TColumnDesc> columns) : this()
        {
            Columns = columns;
        }

        public void Read(TProtocol iprot)
        {
            var isset_columns = false;
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
                        if (field.Type == TType.List)
                        {
                            {
                                Columns = new List<TColumnDesc>();
                                var _list19 = iprot.ReadListBegin();
                                for (var _i20 = 0; _i20 < _list19.Count; ++_i20)
                                {
                                    var _elem21 = new TColumnDesc();
                                    _elem21 = new TColumnDesc();
                                    _elem21.Read(iprot);
                                    Columns.Add(_elem21);
                                }
                                iprot.ReadListEnd();
                            }
                            isset_columns = true;
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
            if (!isset_columns)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TTableSchema");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "columns",
                Type = TType.List,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            {
                oprot.WriteListBegin(new TList(TType.Struct, Columns.Count));
                foreach (var _iter22 in Columns)
                {
                    _iter22.Write(oprot);
                }
                oprot.WriteListEnd();
            }
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TTableSchema(");
            sb.Append("Columns: ");
            sb.Append(Columns);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
