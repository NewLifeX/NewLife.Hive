using System;
using System.IO;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport;

namespace Thrift.Server
{
	public abstract class TServer
	{
		protected TProcessor processor;

		protected TServerTransport serverTransport;

		protected TTransportFactory inputTransportFactory;

		protected TTransportFactory outputTransportFactory;

		protected TProtocolFactory inputProtocolFactory;

		protected TProtocolFactory outputProtocolFactory;

		protected TServer.LogDelegate logDelegate;

		public TServer(TProcessor processor, TServerTransport serverTransport) : this(processor, serverTransport, new TTransportFactory(), new TTransportFactory(), new TBinaryProtocol.Factory(), new TBinaryProtocol.Factory(), new TServer.LogDelegate(TServer.DefaultLogDelegate))
		{
		}

		public TServer(TProcessor processor, TServerTransport serverTransport, TServer.LogDelegate logDelegate) : this(processor, serverTransport, new TTransportFactory(), new TTransportFactory(), new TBinaryProtocol.Factory(), new TBinaryProtocol.Factory(), new TServer.LogDelegate(TServer.DefaultLogDelegate))
		{
		}

		public TServer(TProcessor processor, TServerTransport serverTransport, TTransportFactory transportFactory) : this(processor, serverTransport, transportFactory, transportFactory, new TBinaryProtocol.Factory(), new TBinaryProtocol.Factory(), new TServer.LogDelegate(TServer.DefaultLogDelegate))
		{
		}

		public TServer(TProcessor processor, TServerTransport serverTransport, TTransportFactory transportFactory, TProtocolFactory protocolFactory) : this(processor, serverTransport, transportFactory, transportFactory, protocolFactory, protocolFactory, new TServer.LogDelegate(TServer.DefaultLogDelegate))
		{
		}

		public TServer(TProcessor processor, TServerTransport serverTransport, TTransportFactory inputTransportFactory, TTransportFactory outputTransportFactory, TProtocolFactory inputProtocolFactory, TProtocolFactory outputProtocolFactory, TServer.LogDelegate logDelegate)
		{
			this.processor = processor;
			this.serverTransport = serverTransport;
			this.inputTransportFactory = inputTransportFactory;
			this.outputTransportFactory = outputTransportFactory;
			this.inputProtocolFactory = inputProtocolFactory;
			this.outputProtocolFactory = outputProtocolFactory;
			this.logDelegate = logDelegate;
		}

		protected static void DefaultLogDelegate(string s)
		{
			Console.Error.WriteLine(s);
		}

		public abstract void Serve();

		public abstract void Stop();

		public delegate void LogDelegate(string str);
	}
}