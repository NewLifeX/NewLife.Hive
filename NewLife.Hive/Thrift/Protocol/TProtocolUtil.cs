using System;

namespace Thrift.Protocol
{
	public static class TProtocolUtil
	{
		public static void Skip(TProtocol prot, TType type)
		{
			switch (type)
			{
				case TType.Bool:
				{
					prot.ReadBool();
					return;
				}
				case TType.Byte:
				{
					prot.ReadByte();
					return;
				}
				case TType.Double:
				{
					prot.ReadDouble();
					return;
				}
				case TType.Void | TType.Double:
				case TType.Void | TType.Bool | TType.Byte | TType.Double | TType.I16:
				case TType.Void | TType.I32:
				{
					return;
				}
				case TType.I16:
				{
					prot.ReadI16();
					return;
				}
				case TType.I32:
				{
					prot.ReadI32();
					return;
				}
				case TType.I64:
				{
					prot.ReadI64();
					return;
				}
				case TType.String:
				{
					prot.ReadBinary();
					return;
				}
				case TType.Struct:
				{
					prot.ReadStructBegin();
					while (true)
					{
						TField tField = prot.ReadFieldBegin();
						if (tField.Type == TType.Stop)
						{
							break;
						}
						TProtocolUtil.Skip(prot, tField.Type);
						prot.ReadFieldEnd();
					}
					prot.ReadStructEnd();
					return;
				}
				case TType.Map:
				{
					TMap tMap = prot.ReadMapBegin();
					for (int i = 0; i < tMap.Count; i++)
					{
						TProtocolUtil.Skip(prot, tMap.KeyType);
						TProtocolUtil.Skip(prot, tMap.ValueType);
					}
					prot.ReadMapEnd();
					return;
				}
				case TType.Set:
				{
					TSet tSet = prot.ReadSetBegin();
					for (int j = 0; j < tSet.Count; j++)
					{
						TProtocolUtil.Skip(prot, tSet.ElementType);
					}
					prot.ReadSetEnd();
					return;
				}
				case TType.List:
				{
					TList tList = prot.ReadListBegin();
					for (int k = 0; k < tList.Count; k++)
					{
						TProtocolUtil.Skip(prot, tList.ElementType);
					}
					prot.ReadListEnd();
					return;
				}
				default:
				{
					return;
				}
			}
		}
	}
}