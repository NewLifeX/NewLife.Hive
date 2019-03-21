using System;

namespace Thrift.Protocol
{
	public struct TStruct
	{
		private string name;

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public TStruct(string name)
		{
			this = new TStruct()
			{
				name = name
			};
		}
	}
}