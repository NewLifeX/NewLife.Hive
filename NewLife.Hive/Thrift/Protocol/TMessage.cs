using System;

namespace Thrift.Protocol
{
    public struct TMessage
    {
        public String Name { get; set; }

        public Int32 SeqID { get; set; }

        public TMessageType Type { get; set; }

        public TMessage(String name, TMessageType type, Int32 seqid)
        {
            this = new TMessage()
            {
                Name = name,
                Type = type,
                SeqID = seqid
            };
        }
    }
}