using System;

namespace Thrift.Protocol
{
    public struct TField
    {
        public Int16 ID { get; set; }

        public String Name { get; set; }

        public TType Type { get; set; }

        public TField(String name, TType type, Int16 id)
        {
            this = new TField()
            {
                Name = name,
                Type = type,
                ID = id
            };
        }
    }
}