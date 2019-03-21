using System;
using System.Reflection;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;

namespace Thrift.Server
{
	public class TSimpleServer : TServer
	{
		private bool stop;

		public TSimpleServer(TProcessor processor, TServerTransport serverTransport) : base(processor, serverTransport, new TTransportFactory(), new TTransportFactory(), new TBinaryProtocol.Factory(), new TBinaryProtocol.Factory(), new TServer.LogDelegate(TServer.DefaultLogDelegate))
		{
		}

		public TSimpleServer(TProcessor processor, TServerTransport serverTransport, TServer.LogDelegate logDel) : base(processor, serverTransport, new TTransportFactory(), new TTransportFactory(), new TBinaryProtocol.Factory(), new TBinaryProtocol.Factory(), logDel)
		{
		}

		public TSimpleServer(TProcessor processor, TServerTransport serverTransport, TTransportFactory transportFactory) : base(processor, serverTransport, transportFactory, transportFactory, new TBinaryProtocol.Factory(), new TBinaryProtocol.Factory(), new TServer.LogDelegate(TServer.DefaultLogDelegate))
		{
		}

		public TSimpleServer(TProcessor processor, TServerTransport serverTransport, TTransportFactory transportFactory, TProtocolFactory protocolFactory) : base(processor, serverTransport, transportFactory, transportFactory, protocolFactory, protocolFactory, new TServer.LogDelegate(TServer.DefaultLogDelegate))
		{
		}

		public override void Serve()
		{
			try
			{
				serverTransport.Listen();
			}
			catch (TTransportException tTransportException)
			{
				logDelegate(tTransportException.ToString());
				return;
			}
			while (!stop)
			{
				TTransport tTransport = null;
				TTransport tTransport1 = null;
				TTransport tTransport2 = null;
				TProtocol protocol = null;
				TProtocol tProtocol = null;
				try
				{
					TTransport tTransport3 = serverTransport.Accept();
					tTransport = tTransport3;
					using (tTransport3)
					{
						if (tTransport != null)
						{
							TTransport transport = inputTransportFactory.GetTransport(tTransport);
							tTransport1 = transport;
							using (transport)
							{
								TTransport transport1 = outputTransportFactory.GetTransport(tTransport);
								tTransport2 = transport1;
								using (transport1)
								{
									protocol = inputProtocolFactory.GetProtocol(tTransport1);
									tProtocol = outputProtocolFactory.GetProtocol(tTransport2);
									while (processor.Process(protocol, tProtocol))
									{
									}
								}
							}
						}
					}
				}
				catch (TTransportException tTransportException2)
				{
					TTransportException tTransportException1 = tTransportException2;
					if (stop)
					{
						logDelegate(string.Concat("TSimpleServer was shutting down, caught ", tTransportException1.GetType().Name));
					}
				}
				catch (Exception exception)
				{
					logDelegate(exception.ToString());
				}
			}
			if (stop)
			{
				try
				{
					serverTransport.Close();
				}
				catch (TTransportException tTransportException3)
				{
					logDelegate(string.Concat("TServerTranport failed on close: ", tTransportException3.Message));
				}
				stop = false;
			}
		}

		public override void Stop()
		{
			stop = true;
			serverTransport.Close();
		}
	}
}