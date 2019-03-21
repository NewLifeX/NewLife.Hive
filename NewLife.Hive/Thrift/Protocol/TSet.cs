using System;

namespace Thrift.Protocol
{
	public struct TSet
	{
		private TType elementType;

		private int count;

		public int Count
		{
			get
			{
				return count;
			}
			set
			{
				count = value;
			}
		}

		public TType ElementType
		{
			get
			{
				return elementType;
			}
			set
			{
				elementType = value;
			}
		}

		public TSet(TType elementType, int count)
		{
			this = new TSet()
			{
				elementType = elementType,
				count = count
			};
		}

		public TSet(TList list) : this(list.ElementType, list.Count)
		{
		}
	}
}