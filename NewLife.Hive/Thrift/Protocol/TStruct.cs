using System;

namespace Thrift.Protocol
{
    public struct TStruct
    {
        public String Name { get; set; }

        public TStruct(String name)
        {
            this = new TStruct()
            {
                Name = name
            };
        }
    }
}