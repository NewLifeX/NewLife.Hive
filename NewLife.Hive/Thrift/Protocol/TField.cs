using System;

namespace Thrift.Protocol
{
	public struct TField
	{
		private string name;

		private TType type;

		private short id;

		public short ID
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

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

		public TType Type
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
			}
		}

		public TField(string name, TType type, short id)
		{
			this = new TField()
			{
				name = name,
				type = type,
				id = id
			};
		}
	}
}