using System;
using Thrift.Protocol;

namespace Thrift
{
	public class TApplicationException : TException
	{
		protected TApplicationException.ExceptionType type;

		public TApplicationException()
		{
		}

		public TApplicationException(TApplicationException.ExceptionType type)
		{
			this.type = type;
		}

		public TApplicationException(TApplicationException.ExceptionType type, string message) : base(message)
		{
			this.type = type;
		}

		public static TApplicationException Read(TProtocol iprot)
		{
			string str = null;
			TApplicationException.ExceptionType exceptionType = TApplicationException.ExceptionType.Unknown;
			iprot.ReadStructBegin();
			while (true)
			{
				TField tField = iprot.ReadFieldBegin();
				if (tField.Type == TType.Stop)
				{
					break;
				}
				switch (tField.ID)
				{
					case 1:
					{
						if (tField.Type != TType.String)
						{
							TProtocolUtil.Skip(iprot, tField.Type);
							break;
						}
						else
						{
							str = iprot.ReadString();
							break;
						}
					}
					case 2:
					{
						if (tField.Type != TType.I32)
						{
							TProtocolUtil.Skip(iprot, tField.Type);
							break;
						}
						else
						{
							exceptionType = (TApplicationException.ExceptionType)iprot.ReadI32();
							break;
						}
					}
					default:
					{
						TProtocolUtil.Skip(iprot, tField.Type);
						break;
					}
				}
				iprot.ReadFieldEnd();
			}
			iprot.ReadStructEnd();
			return new TApplicationException(exceptionType, str);
		}

		public void Write(TProtocol oprot)
		{
			TStruct tStruct = new TStruct("TApplicationException");
			TField tField = new TField();
			oprot.WriteStructBegin(tStruct);
			if (!string.IsNullOrEmpty(Message))
			{
				tField.Name = "message";
				tField.Type = TType.String;
				tField.ID = 1;
				oprot.WriteFieldBegin(tField);
				oprot.WriteString(Message);
				oprot.WriteFieldEnd();
			}
			tField.Name = "type";
			tField.Type = TType.I32;
			tField.ID = 2;
			oprot.WriteFieldBegin(tField);
			oprot.WriteI32((int)type);
			oprot.WriteFieldEnd();
			oprot.WriteFieldStop();
			oprot.WriteStructEnd();
		}

		public enum ExceptionType
		{
			Unknown,
			UnknownMethod,
			InvalidMessageType,
			WrongMethodName,
			BadSequenceID,
			MissingResult,
			InternalError,
			ProtocolError,
			InvalidTransform,
			InvalidProtocol,
			UnsupportedClientType
		}
	}
}