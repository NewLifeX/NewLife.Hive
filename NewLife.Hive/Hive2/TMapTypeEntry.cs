using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TMapTypeEntry : TBase
    {

        public Int32 KeyTypePtr { get; set; }

        public Int32 ValueTypePtr { get; set; }

        public TMapTypeEntry()
        {
        }

        public TMapTypeEntry(Int32 keyTypePtr, Int32 valueTypePtr) : this()
        {
            KeyTypePtr = keyTypePtr;
            ValueTypePtr = valueTypePtr;
        }

        public void Read(TProtocol iprot)
        {
            var isset_keyTypePtr = false;
            var isset_valueTypePtr = false;
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
                            KeyTypePtr = iprot.ReadI32();
                            isset_keyTypePtr = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.I32)
                        {
                            ValueTypePtr = iprot.ReadI32();
                            isset_valueTypePtr = true;
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
            if (!isset_keyTypePtr)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_valueTypePtr)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TMapTypeEntry");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "keyTypePtr",
                Type = TType.I32,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            oprot.WriteI32(KeyTypePtr);
            oprot.WriteFieldEnd();
            field.Name = "valueTypePtr";
            field.Type = TType.I32;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            oprot.WriteI32(ValueTypePtr);
            oprot.WriteFieldEnd();
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TMapTypeEntry(");
            sb.Append("KeyTypePtr: ");
            sb.Append(KeyTypePtr);
            sb.Append(",ValueTypePtr: ");
            sb.Append(ValueTypePtr);
            sb.Append(")");
            return sb.ToString();
        }

    }

}
