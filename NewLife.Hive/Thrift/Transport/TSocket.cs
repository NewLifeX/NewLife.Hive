using System;
using System.Net.Sockets;

namespace Thrift.Transport
{
    public class TSocket : TStreamTransport
    {
        private Int32 _Timeout;

        private Boolean _IsDisposed;

        public String Host { get; private set; }

        public override Boolean IsOpen
        {
            get
            {
                if (Client == null)
                {
                    return false;
                }
                return Client.Connected;
            }
        }

        public Int32 Port { get; private set; }

        public TcpClient Client { get; private set; }

        public TSocket(TcpClient client)
        {
            Client = client;
            if (IsOpen)
            {
                inputStream = client.GetStream();
                outputStream = client.GetStream();
            }
        }

        public TSocket(String host, Int32 port) : this(host, port, 0)
        {
        }

        public TSocket(String host, Int32 port, Int32 timeout)
        {
            Host = host;
            Port = port;
            this._Timeout = timeout;
            InitSocket();
        }

        public override void Close()
        {
            base.Close();
            if (Client != null)
            {
                Client.Dispose();
                Client = null;
            }
        }

        private static void ConnectCallback(IAsyncResult asyncres)
        {
            var asyncState = asyncres.AsyncState as ConnectHelper;
            lock (asyncState.Mutex)
            {
                asyncState.CallbackDone = true;
                try
                {
                    if (asyncState.Client.Client != null)
                    {
                        asyncState.Client.Dispose();
                    }
                }
                catch (SocketException)
                {
                }
                if (asyncState.DoCleanup)
                {
                    asyncres.AsyncWaitHandle.Dispose();
                    if (asyncState.Client != null)
                    {
                        ((IDisposable)asyncState.Client).Dispose();
                    }
                    asyncState.Client = null;
                }
            }
        }

        protected override void Dispose(Boolean disposing)
        {
            if (!_IsDisposed && disposing)
            {
                if (Client != null)
                {
                    ((IDisposable)Client).Dispose();
                }
                base.Dispose(disposing);
            }
            _IsDisposed = true;
        }

        private void InitSocket()
        {
            var tc = Client = new TcpClient();
            tc.SendTimeout = _Timeout;
            tc.ReceiveTimeout = _Timeout;
            tc.Client.NoDelay = true;
        }

        public override void Open()
        {
            if (IsOpen)
            {
                throw new TTransportException(TTransportException.ExceptionType.AlreadyOpen, "Socket already connected");
            }
            if (String.IsNullOrEmpty(Host))
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen, "Cannot open null host");
            }
            if (Port <= 0)
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen, "Cannot open without port");
            }
            if (Client == null)
            {
                InitSocket();
            }
            if (_Timeout != 0)
            {
                var connectHelper = new ConnectHelper(Client);
                var t = Client.ConnectAsync(Host, Port);
                t.Wait();
                //, new AsyncCallback(TSocket.ConnectCallback), connectHelper);
                //if ((!asyncResult.AsyncWaitHandle.WaitOne(this.timeout) ? true : !this.client.Connected))
                //{
                //    lock (connectHelper.Mutex)
                //    {
                //        if (!connectHelper.CallbackDone)
                //        {
                //            connectHelper.DoCleanup = true;
                //            this.client = null;
                //        }
                //        else
                //        {
                //            asyncResult.AsyncWaitHandle.Dispose();
                //            this.client.Dispose();
                //        }
                //    }
                //    throw new TTransportException(TTransportException.ExceptionType.TimedOut, "Connect timed out");
                //}
            }
            else
            {
                Client.ConnectAsync(Host, Port).Wait();
            }
            inputStream = Client.GetStream();
            outputStream = Client.GetStream();
        }

        private class ConnectHelper
        {
            public Object Mutex;

            public Boolean DoCleanup;

            public Boolean CallbackDone;

            public TcpClient Client;

            public ConnectHelper(TcpClient client)
            {
                Client = client;
            }
        }
    }
}