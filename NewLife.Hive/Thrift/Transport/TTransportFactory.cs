using System;

namespace Thrift.Transport
{
	public class TTransportFactory
	{
		public TTransportFactory()
		{
		}

		public virtual TTransport GetTransport(TTransport trans)
		{
			return trans;
		}
	}
}