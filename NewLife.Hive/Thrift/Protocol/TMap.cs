using System;

namespace Thrift.Protocol
{
    public struct TMap
    {
        public Int32 Count { get; set; }

        public TType KeyType { get; set; }

        public TType ValueType { get; set; }

        public TMap(TType keyType, TType valueType, Int32 count)
        {
            this = new TMap()
            {
                KeyType = keyType,
                ValueType = valueType,
                Count = count
            };
        }
    }
}