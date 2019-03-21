using System;

namespace Thrift.Protocol
{
	public struct TMessage
	{
		private string name;

		private TMessageType type;

		private int seqID;

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

		public int SeqID
		{
			get
			{
				return seqID;
			}
			set
			{
				seqID = value;
			}
		}

		public TMessageType Type
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

		public TMessage(string name, TMessageType type, int seqid)
		{
			this = new TMessage()
			{
				name = name,
				type = type,
				seqID = seqid
			};
		}
	}
}