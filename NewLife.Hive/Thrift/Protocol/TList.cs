using System;

namespace Thrift.Protocol
{
    public struct TList
    {
        public Int32 Count { get; set; }

        public TType ElementType { get; set; }

        public TList(TType elementType, Int32 count)
        {
            this = new TList()
            {
                ElementType = elementType,
                Count = count
            };
        }
    }
}