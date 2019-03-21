using System;

namespace Thrift
{
	public class TException : Exception
	{
		public TException()
		{
		}

		public TException(string message) : base(message)
		{
		}
	}
}