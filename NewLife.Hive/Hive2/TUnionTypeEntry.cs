using System;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TUnionTypeEntry : TBase
    {

        public Dictionary<String, Int32> NameToTypePtr { get; set; }

        public TUnionTypeEntry()
        {
        }

        public TUnionTypeEntry(Dictionary<String, Int32> nameToTypePtr) : this()
        {
            NameToTypePtr = nameToTypePtr;
        }

        public void Read(TProtocol iprot)
        {
            var isset_nameToTypePtr = false;
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
                                NameToTypePtr = new Dictionary<String, Int32>();
                                var _map10 = iprot.ReadMapBegin();
                                for (var _i11 = 0; _i11 < _map10.Count; ++_i11)
                                {
                                    String _key12;
                                    Int32 _val13;
                                    _key12 = iprot.ReadString();
                                    _val13 = iprot.ReadI32();
                                    NameToTypePtr[_key12] = _val13;
                                }
                                iprot.ReadMapEnd();
                            }
                            isset_nameToTypePtr = true;
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
            if (!isset_nameToTypePtr)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TUnionTypeEntry");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "nameToTypePtr",
                Type = TType.Map,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            {
                oprot.WriteMapBegin(new TMap(TType.String, TType.I32, NameToTypePtr.Count));
                foreach (var _iter14 in NameToTypePtr.Keys)
                {
                    oprot.WriteString(_iter14);
                    oprot.WriteI32(NameToTypePtr[_iter14]);
                }
                oprot.WriteMapEnd();
            }
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TUnionTypeEntry(");
            sb.Append("NameToTypePtr: ");
            sb.Append(NameToTypePtr);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
