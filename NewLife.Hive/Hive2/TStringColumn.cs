using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TStringColumn : TBase
    {

        public List<String> Values { get; set; }

        public Byte[] Nulls { get; set; }

        public TStringColumn()
        {
        }

        public TStringColumn(List<String> values, Byte[] nulls) : this()
        {
            Values = values;
            Nulls = nulls;
        }

        public void Read(TProtocol iprot)
        {
            var isset_values = false;
            var isset_nulls = false;
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
                                Values = new List<String>();
                                var _list51 = iprot.ReadListBegin();
                                for (var _i52 = 0; _i52 < _list51.Count; ++_i52)
                                {
                                    String _elem53 = null;
                                    _elem53 = iprot.ReadString();
                                    Values.Add(_elem53);
                                }
                                iprot.ReadListEnd();
                            }
                            isset_values = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.String)
                        {
                            Nulls = iprot.ReadBinary();
                            isset_nulls = true;
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
            if (!isset_values)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_nulls)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TStringColumn");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "values",
                Type = TType.List,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            {
                oprot.WriteListBegin(new TList(TType.String, Values.Count));
                foreach (var _iter54 in Values)
                {
                    oprot.WriteString(_iter54);
                }
                oprot.WriteListEnd();
            }
            oprot.WriteFieldEnd();
            field.Name = "nulls";
            field.Type = TType.String;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            oprot.WriteBinary(Nulls);
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TStringColumn(");
            sb.Append("Values: ");
            sb.Append(Values);
            sb.Append(",Nulls: ");
            sb.Append(Nulls);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
