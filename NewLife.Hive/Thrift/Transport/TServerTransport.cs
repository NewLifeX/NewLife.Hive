using System;

namespace Thrift.Transport
{
	public abstract class TServerTransport
	{
		protected TServerTransport()
		{
		}

		public TTransport Accept()
		{
			TTransport tTransport = AcceptImpl();
			if (tTransport == null)
			{
				throw new TTransportException("accept() may not return NULL");
			}
			return tTransport;
		}

		protected abstract TTransport AcceptImpl();

		public abstract void Close();

		public abstract void Listen();
	}
}