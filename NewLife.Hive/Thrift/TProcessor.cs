using System;
using Thrift.Protocol;

namespace Thrift
{
	public interface TProcessor
	{
		bool Process(TProtocol iprot, TProtocol oprot);
	}
}