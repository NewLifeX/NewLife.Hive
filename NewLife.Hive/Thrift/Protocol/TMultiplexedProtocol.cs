using System;

namespace Thrift.Protocol
{
	public class TMultiplexedProtocol : TProtocolDecorator
	{
		public static string SEPARATOR;

		private string ServiceName;

		static TMultiplexedProtocol()
		{
			TMultiplexedProtocol.SEPARATOR = ":";
		}

		public TMultiplexedProtocol(TProtocol protocol, string serviceName) : base(protocol)
		{
			ServiceName = serviceName;
		}

		public override void WriteMessageBegin(TMessage tMessage)
		{
			TMessageType type = tMessage.Type;
			if (type != TMessageType.Call && type != TMessageType.Oneway)
			{
				base.WriteMessageBegin(tMessage);
				return;
			}
			base.WriteMessageBegin(new TMessage(string.Concat(ServiceName, TMultiplexedProtocol.SEPARATOR, tMessage.Name), tMessage.Type, tMessage.SeqID));
		}
	}
}