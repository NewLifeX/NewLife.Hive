using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{
    [Serializable]
    public partial class TArrayTypeEntry : TBase
    {
        public Int32 ObjectTypePtr { get; set; }

        public TArrayTypeEntry()
        {
        }

        public TArrayTypeEntry(Int32 objectTypePtr) : this()
        {
            ObjectTypePtr = objectTypePtr;
        }

        public void Read(TProtocol iprot)
        {
            var isset_objectTypePtr = false;
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
                        if (field.Type == TType.I32)
                        {
                            ObjectTypePtr = iprot.ReadI32();
                            isset_objectTypePtr = true;
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
            if (!isset_objectTypePtr)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TArrayTypeEntry");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "objectTypePtr",
                Type = TType.I32,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            oprot.WriteI32(ObjectTypePtr);
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TArrayTypeEntry(");
            sb.Append("ObjectTypePtr: ");
            sb.Append(ObjectTypePtr);
            sb.Append(")");
            return sb.ToString();
        }
    }
}