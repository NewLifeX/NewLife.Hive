using System;

namespace NewLife.Thrift.Transport
{
    public class SASLClient : IDisposable
    {
        PlainMechanism _chose_mechanism;

        public SASLClient(String host, PlainMechanism mechanism)
        {
            Mechanism = mechanism.Name;
            _chose_mechanism = mechanism;

        }

        public String Mechanism
        {
            get;
            private set;
        }

        public Byte[] process(Byte[] challenge)
        {
            return _chose_mechanism.process(challenge);
        }

        public void Dispose()
        {
            _chose_mechanism = null;
        }
    }

}