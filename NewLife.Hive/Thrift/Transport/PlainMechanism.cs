using System;
using System.Collections.Generic;
using System.Text;

namespace Thrift.Transport
{
    public class PlainMechanism
    {
        public String Name { get { return "PLAIN"; } }
        protected String _userName;
        protected String _password;
        private readonly Byte _sign = 0x00;
        public PlainMechanism(String userName, String password)
        {
            _userName = userName;
            _password = password;
        }

        public Byte[] process(Byte[] challenge)
        {
            var result = new List<Byte>
            {
                _sign
            };
            result.AddRange(Encoding.UTF8.GetBytes(_userName));
            result.Add(_sign);
            result.AddRange(Encoding.UTF8.GetBytes(_password));

            return result.ToArray();
        }
    }
}