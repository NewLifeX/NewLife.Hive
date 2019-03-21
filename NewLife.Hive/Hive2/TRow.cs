using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TRow : TBase
    {

        public List<TColumnValue> ColVals { get; set; }

        public TRow()
        {
        }

        public TRow(List<TColumnValue> colVals) : this()
        {
            ColVals = colVals;
        }

        public void Read(TProtocol iprot)
        {
            var isset_colVals = false;
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
                                ColVals = new List<TColumnValue>();
                                var _list23 = iprot.ReadListBegin();
                                for (var _i24 = 0; _i24 < _list23.Count; ++_i24)
                                {
                                    var _elem25 = new TColumnValue();
                                    _elem25 = new TColumnValue();
                                    _elem25.Read(iprot);
                                    ColVals.Add(_elem25);
                                }
                                iprot.ReadListEnd();
                            }
                            isset_colVals = true;
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
            if (!isset_colVals)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TRow");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "colVals",
                Type = TType.List,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            {
                oprot.WriteListBegin(new TList(TType.Struct, ColVals.Count));
                foreach (var _iter26 in ColVals)
                {
                    _iter26.Write(oprot);
                }
                oprot.WriteListEnd();
            }
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TRow(");
            sb.Append("ColVals: ");
            sb.Append(ColVals);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
