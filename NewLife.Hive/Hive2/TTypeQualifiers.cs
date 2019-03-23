using System;
using System.Collections.Generic;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TTypeQualifiers : TBase
    {

        public Dictionary<String, TTypeQualifierValue> Qualifiers { get; set; }

        public TTypeQualifiers()
        {
        }

        public TTypeQualifiers(Dictionary<String, TTypeQualifierValue> qualifiers) : this()
        {
            Qualifiers = qualifiers;
        }

        public void Read(TProtocol iprot)
        {
            var isset_qualifiers = false;
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
                        if (field.Type == TType.Map)
                        {
                            {
                                Qualifiers = new Dictionary<String, TTypeQualifierValue>();
                                var _map0 = iprot.ReadMapBegin();
                                for (var _i1 = 0; _i1 < _map0.Count; ++_i1)
                                {
                                    String _key2;
                                    TTypeQualifierValue _val3;
                                    _key2 = iprot.ReadString();
                                    _val3 = new TTypeQualifierValue();
                                    _val3.Read(iprot);
                                    Qualifiers[_key2] = _val3;
                                }
                                iprot.ReadMapEnd();
                            }
                            isset_qualifiers = true;
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
            if (!isset_qualifiers)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TTypeQualifiers");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "qualifiers",
                Type = TType.Map,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            {
                oprot.WriteMapBegin(new TMap(TType.String, TType.Struct, Qualifiers.Count));
                foreach (var _iter4 in Qualifiers.Keys)
                {
                    oprot.WriteString(_iter4);
                    Qualifiers[_iter4].Write(oprot);
                }
                oprot.WriteMapEnd();
            }
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TTypeQualifiers(");
            sb.Append("Qualifiers: ");
            sb.Append(Qualifiers);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
