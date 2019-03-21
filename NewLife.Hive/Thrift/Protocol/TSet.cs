using System;

namespace Thrift.Protocol
{
    public struct TSet
    {
        public Int32 Count { get; set; }

        public TType ElementType { get; set; }

        public TSet(TType elementType, Int32 count)
        {
            this = new TSet()
            {
                ElementType = elementType,
                Count = count
            };
        }

        public TSet(TList list) : this(list.ElementType, list.Count)
        {
        }
    }
}