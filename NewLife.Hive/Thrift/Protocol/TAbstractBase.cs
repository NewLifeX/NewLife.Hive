using System;

namespace Thrift.Protocol
{
	public interface TAbstractBase
	{
		void Write(TProtocol tProtocol);
	}
}