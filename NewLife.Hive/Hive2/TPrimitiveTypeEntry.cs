using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TPrimitiveTypeEntry : TBase
    {
        private TTypeQualifiers _typeQualifiers;

        /// <summary>
        /// 
        /// <seealso cref="TTypeId"/>
        /// </summary>
        public TTypeId Type { get; set; }

        public TTypeQualifiers TypeQualifiers
        {
            get
            {
                return _typeQualifiers;
            }
            set
            {
                __isset.typeQualifiers = true;
                _typeQualifiers = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean typeQualifiers;
        }

        public TPrimitiveTypeEntry()
        {
        }

        public TPrimitiveTypeEntry(TTypeId type) : this()
        {
            Type = type;
        }

        public void Read(TProtocol iprot)
        {
            var isset_type = false;
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
                            Type = (TTypeId)iprot.ReadI32();
                            isset_type = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.Struct)
                        {
                            TypeQualifiers = new TTypeQualifiers();
                            TypeQualifiers.Read(iprot);
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
            if (!isset_type)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TPrimitiveTypeEntry");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "type",
                Type = TType.I32,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            oprot.WriteI32((Int32)Type);
            oprot.WriteFieldEnd();
            if (TypeQualifiers != null && __isset.typeQualifiers)
            {
                field.Name = "typeQualifiers";
                field.Type = TType.Struct;
                field.ID = 2;
                oprot.WriteFieldBegin(field);
                TypeQualifiers.Write(oprot);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TPrimitiveTypeEntry(");
            sb.Append("Type: ");
            sb.Append(Type);
            sb.Append(",TypeQualifiers: ");
            sb.Append(TypeQualifiers == null ? "<null>" : TypeQualifiers.ToString());
            sb.Append(")");
            return sb.ToString();
        }

    }

}
