using System;
using System.Collections.Generic;
using System.IO;
using Thrift;
using Thrift.Transport;

namespace Thrift.Protocol
{
	public class TMultiplexedProcessor : TProcessor
	{
		private Dictionary<string, TProcessor> ServiceProcessorMap = new Dictionary<string, TProcessor>();

		public TMultiplexedProcessor()
		{
		}

		private void Fail(TProtocol oprot, TMessage message, TApplicationException.ExceptionType extype, string etxt)
		{
			TApplicationException tApplicationException = new TApplicationException(extype, etxt);
			TMessage tMessage = new TMessage(message.Name, TMessageType.Exception, message.SeqID);
			oprot.WriteMessageBegin(tMessage);
			tApplicationException.Write(oprot);
			oprot.WriteMessageEnd();
			oprot.Transport.Flush();
		}

		public bool Process(TProtocol iprot, TProtocol oprot)
		{
			TProcessor tProcessor;
			bool flag;
			try
			{
				TMessage tMessage = iprot.ReadMessageBegin();
				if (tMessage.Type == TMessageType.Call || tMessage.Type == TMessageType.Oneway)
				{
					int num = tMessage.Name.IndexOf(TMultiplexedProtocol.SEPARATOR);
					if (num >= 0)
					{
						string str = tMessage.Name.Substring(0, num);
						if (ServiceProcessorMap.TryGetValue(str, out tProcessor))
						{
							TMessage tMessage1 = new TMessage(tMessage.Name.Substring(str.Length + TMultiplexedProtocol.SEPARATOR.Length), tMessage.Type, tMessage.SeqID);
							flag = tProcessor.Process(new TMultiplexedProcessor.StoredMessageProtocol(iprot, tMessage1), oprot);
						}
						else
						{
							Fail(oprot, tMessage, TApplicationException.ExceptionType.InternalError, string.Concat("Service name not found: ", str, ". Did you forget to call RegisterProcessor()?"));
							flag = false;
						}
					}
					else
					{
						Fail(oprot, tMessage, TApplicationException.ExceptionType.InvalidProtocol, string.Concat("Service name not found in message name: ", tMessage.Name, ". Did you forget to use a TMultiplexProtocol in your client?"));
						flag = false;
					}
				}
				else
				{
					Fail(oprot, tMessage, TApplicationException.ExceptionType.InvalidMessageType, "Message type CALL or ONEWAY expected");
					flag = false;
				}
			}
			catch (IOException oException)
			{
				flag = false;
			}
			return flag;
		}

		public void RegisterProcessor(string serviceName, TProcessor processor)
		{
			ServiceProcessorMap.Add(serviceName, processor);
		}

		private class StoredMessageProtocol : TProtocolDecorator
		{
			private TMessage MsgBegin;

			public StoredMessageProtocol(TProtocol protocol, TMessage messageBegin) : base(protocol)
			{
				MsgBegin = messageBegin;
			}

			public override TMessage ReadMessageBegin()
			{
				return MsgBegin;
			}
		}
	}
}