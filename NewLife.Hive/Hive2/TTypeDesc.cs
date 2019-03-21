using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TTypeDesc : TBase
    {

        public List<TTypeEntry> Types { get; set; }

        public TTypeDesc()
        {
        }

        public TTypeDesc(List<TTypeEntry> types) : this()
        {
            Types = types;
        }

        public void Read(TProtocol iprot)
        {
            var isset_types = false;
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
                                Types = new List<TTypeEntry>();
                                var _list15 = iprot.ReadListBegin();
                                for (var _i16 = 0; _i16 < _list15.Count; ++_i16)
                                {
                                    var _elem17 = new TTypeEntry();
                                    _elem17 = new TTypeEntry();
                                    _elem17.Read(iprot);
                                    Types.Add(_elem17);
                                }
                                iprot.ReadListEnd();
                            }
                            isset_types = true;
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
            if (!isset_types)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TTypeDesc");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "types",
                Type = TType.List,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            {
                oprot.WriteListBegin(new TList(TType.Struct, Types.Count));
                foreach (var _iter18 in Types)
                {
                    _iter18.Write(oprot);
                }
                oprot.WriteListEnd();
            }
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TTypeDesc(");
            sb.Append("Types: ");
            sb.Append(Types);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
