using System;
using System.Text;
using Thrift.Protocol;

namespace NewLife.Hive2
{
    [Serializable]
    public partial class TColumnDesc : TBase
    {
        private String _comment;

        public String ColumnName { get; set; }

        public TTypeDesc TypeDesc { get; set; }

        public Int32 Position { get; set; }

        public String Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                __isset.comment = true;
                _comment = value;
            }
        }


        public Isset __isset;
        [Serializable]
        public struct Isset
        {
            public Boolean comment;
        }

        public TColumnDesc()
        {
        }

        public TColumnDesc(String columnName, TTypeDesc typeDesc, Int32 position) : this()
        {
            ColumnName = columnName;
            TypeDesc = typeDesc;
            Position = position;
        }

        public void Read(TProtocol iprot)
        {
            var isset_columnName = false;
            var isset_typeDesc = false;
            var isset_position = false;
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
                        if (field.Type == TType.String)
                        {
                            ColumnName = iprot.ReadString();
                            isset_columnName = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 2:
                        if (field.Type == TType.Struct)
                        {
                            TypeDesc = new TTypeDesc();
                            TypeDesc.Read(iprot);
                            isset_typeDesc = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 3:
                        if (field.Type == TType.I32)
                        {
                            Position = iprot.ReadI32();
                            isset_position = true;
                        }
                        else
                        {
                            TProtocolUtil.Skip(iprot, field.Type);
                        }
                        break;
                    case 4:
                        if (field.Type == TType.String)
                        {
                            Comment = iprot.ReadString();
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
            if (!isset_columnName)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_typeDesc)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
            if (!isset_position)
                throw new TProtocolException(TProtocolException.INVALID_DATA);
        }

        public void Write(TProtocol oprot)
        {
            var struc = new TStruct("TColumnDesc");
            oprot.WriteStructBegin(struc);
            var field = new TField
            {
                Name = "columnName",
                Type = TType.String,
                ID = 1
            };
            oprot.WriteFieldBegin(field);
            oprot.WriteString(ColumnName);
            oprot.WriteFieldEnd();
            field.Name = "typeDesc";
            field.Type = TType.Struct;
            field.ID = 2;
            oprot.WriteFieldBegin(field);
            TypeDesc.Write(oprot);
            oprot.WriteFieldEnd();
            field.Name = "position";
            field.Type = TType.I32;
            field.ID = 3;
            oprot.WriteFieldBegin(field);
            oprot.WriteI32(Position);
            oprot.WriteFieldEnd();
            if (Comment != null && __isset.comment)
            {
                field.Name = "comment";
                field.Type = TType.String;
                field.ID = 4;
                oprot.WriteFieldBegin(field);
                oprot.WriteString(Comment);
                oprot.WriteFieldEnd();
            }
            oprot.WriteFieldStop();
            oprot.WriteStructEnd();
        }

        public override String ToString()
        {
            var sb = new StringBuilder("TColumnDesc(");
            sb.Append("ColumnName: ");
            sb.Append(ColumnName);
            sb.Append(",TypeDesc: ");
            sb.Append(TypeDesc == null ? "<null>" : TypeDesc.ToString());
            sb.Append(",Position: ");
            sb.Append(Position);
            sb.Append(",Comment: ");
            sb.Append(Comment);
            sb.Append(")");
            return sb.ToString();
        }
    }
}