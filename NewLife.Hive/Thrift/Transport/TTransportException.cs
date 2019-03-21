using System;
using Thrift;

namespace Thrift.Transport
{
	public class TTransportException : TException
	{
		protected TTransportException.ExceptionType type;

		public TTransportException.ExceptionType Type
		{
			get
			{
				return type;
			}
		}

		public TTransportException()
		{
		}

		public TTransportException(TTransportException.ExceptionType type) : this()
		{
			this.type = type;
		}

		public TTransportException(TTransportException.ExceptionType type, string message) : base(message)
		{
			this.type = type;
		}

		public TTransportException(string message) : base(message)
		{
		}

		public enum ExceptionType
		{
			Unknown,
			NotOpen,
			AlreadyOpen,
			TimedOut,
			EndOfFile
		}
	}
}