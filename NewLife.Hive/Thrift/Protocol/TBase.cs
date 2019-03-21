using System;

namespace Thrift.Protocol
{
	public interface TBase : TAbstractBase
	{
		void Read(TProtocol tProtocol);
	}
}