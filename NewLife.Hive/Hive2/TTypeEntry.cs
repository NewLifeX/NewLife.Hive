using System;
using System.Text;
using NewLife.Thrift.Protocol;

namespace NewLife.Hive2
{

#if !SILVERLIGHT
    [Serializable]
#endif
    public partial class TTypeEntry : TBase
    {
        private TPrimitiveTypeEntry _primitiveEntry;
        private TArrayTypeEntry _arrayEntry;
        private TMapTypeEntry _mapEntry;
        private TStructTypeEntry _structEntry;
        private TUnionTypeEntry _unionEntry;
        private TUserDefinedTypeEntry _userDefinedTypeEntry;

        public TPrimitiveTypeEntry PrimitiveEntry
        {
            get
            {
                return _primitiveEntry;
            }
            set
            {
                __isset.primitiveEntry = true;
                _primitiveEntry = value;
            }
        }

        public TArrayTypeEntry ArrayEntry
        {
            get
            {
                return _arrayEntry;
            }
            set
            {
                __isset.arrayEntry = true;
                _arrayEntry = value;
            }
        }

        public TMapTypeEntry MapEntry
        {
            get
            {
                return _mapEntry;
            }
            set
            {
                __isset.mapEntry = true;
                _mapEntry = value;
            }
        }

        public TStructTypeEntry StructEntry
        {
            get
            {
                return _structEntry;
            }
            set
            {
                __isset.structEntry = true;
                _structEntry = value;
            }
        }

        public TUnionTypeEntry UnionEntry
        {
            get
            {
                return _unionEntry;
            }
            set
            {
                __isset.unionEntry = true;
                _unionEntry = value;
            }
        }

        public TUserDefinedTypeEntry UserDefinedTypeEntry
        {
            get
            {
                return _userDefinedTypeEntry;
            }
            set
            {
                __isset.userDefinedTypeEntry = true;
                _userDefinedTypeEntry = value;
            }
        }


        public Isset __isset;
#if !SILVERLIGHT
        [Serializable]
#endif
        public struct Isset
        {
            public Boolean primitiveEntry;
            public Boolean arrayEntry;
            public Boolean mapEntry;
            public Boolean structEntry;
            public Boolean unionEntry;
            public Boolean userDefinedTypeEntry;
        }

        public TTypeEntry()
        {
        }

        public void Read(TProtocol iprot)
        {
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
                        if (field.Type == TType.Struct)
                        {
                            PrimitiveEntry = new TPrimitiveTypeEntry();
                            PrimitiveEntry.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.Struct)
                        {
                            ArrayEntry = new TArrayTypeEntry();
                            ArrayEntry.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.Struct)
                        {
                            MapEntry = new TMapTypeEntry();
                            MapEntry.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 4:
                        if (field.Type == TType.Struct)
                        {
                            StructEntry = new TStructTypeEntry();
                            StructEntry.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 5:
                        if (field.Type == TType.Struct)
                        {
                            UnionEntry = new TUnionTypeEntry();
                            UnionEntry.Read(iprot);
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 6:
                        if (field.Type == TType.Struct)
                        {
                            UserDefinedTypeEntry = new TUserDefinedTypeEntry();
                            UserDefinedTypeEntry.Read(iprot);
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
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TTypeEntry");
            oprot.WriteStructBegin(struc);
            var field = new TField();
            if (PrimitiveEntry != null && __isset.primitiveEntry)
            {
                field.Name = "primitiveEntry";
                field.Type = TType.Struct;
                field.ID = 1;
                oprot.WriteFieldBegin(field);
                PrimitiveEntry.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (ArrayEntry != null && __isset.arrayEntry)
            {
                field.Name = "arrayEntry";
                field.Type = TType.Struct;
                field.ID = 2;
                oprot.WriteFieldBegin(field);
                ArrayEntry.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (MapEntry != null && __isset.mapEntry)
            {
                field.Name = "mapEntry";
                field.Type = TType.Struct;
                field.ID = 3;
                oprot.WriteFieldBegin(field);
                MapEntry.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (StructEntry != null && __isset.structEntry)
            {
                field.Name = "structEntry";
                field.Type = TType.Struct;
                field.ID = 4;
                oprot.WriteFieldBegin(field);
                StructEntry.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (UnionEntry != null && __isset.unionEntry)
            {
                field.Name = "unionEntry";
                field.Type = TType.Struct;
                field.ID = 5;
                oprot.WriteFieldBegin(field);
                UnionEntry.Write(oprot);
                oprot.WriteFieldEnd();
            }
            if (UserDefinedTypeEntry != null && __isset.userDefinedTypeEntry)
            {
                field.Name = "userDefinedTypeEntry";
                field.Type = TType.Struct;
                field.ID = 6;
                oprot.WriteFieldBegin(field);
                UserDefinedTypeEntry.Write(oprot);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TTypeEntry(");
            sb.Append("PrimitiveEntry: ");
            sb.Append(PrimitiveEntry == null ? "<null>" : PrimitiveEntry.ToString());
            sb.Append(",ArrayEntry: ");
            sb.Append(ArrayEntry == null ? "<null>" : ArrayEntry.ToString());
            sb.Append(",MapEntry: ");
            sb.Append(MapEntry == null ? "<null>" : MapEntry.ToString());
            sb.Append(",StructEntry: ");
            sb.Append(StructEntry == null ? "<null>" : StructEntry.ToString());
            sb.Append(",UnionEntry: ");
            sb.Append(UnionEntry == null ? "<null>" : UnionEntry.ToString());
            sb.Append(",UserDefinedTypeEntry: ");
            sb.Append(UserDefinedTypeEntry == null ? "<null>" : UserDefinedTypeEntry.ToString());
            sb.Append(")");
            return sb.ToString();
        }

    }

}
