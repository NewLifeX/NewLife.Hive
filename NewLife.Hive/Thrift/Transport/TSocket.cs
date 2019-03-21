using System;
using System.Net.Sockets;

namespace Thrift.Transport
{
    public class TSocket : TStreamTransport
    {
        private Int32 timeout;

        private Boolean _IsDisposed;

        public String Host { get; private set; }

        public override Boolean IsOpen
        {
            get
            {
                if (TcpClient == null)
                {
                    return false;
                }
                return TcpClient.Connected;
            }
        }

        public Int32 Port { get; private set; }

        public TcpClient TcpClient { get; private set; }

        public Int32 Timeout
        {
            set
            {
                var tcpClient = TcpClient;
                var num = value;
                var num1 = num;
                timeout = num;
                var num2 = num1;
                var num3 = num2;
                TcpClient.SendTimeout = num2;
                tcpClient.ReceiveTimeout = num3;
            }
        }

        public TSocket(TcpClient client)
        {
            TcpClient = client;
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
            this.timeout = timeout;
            InitSocket();
        }

        public override void Close()
        {
            base.Close();
            if (TcpClient != null)
            {
                TcpClient.Dispose();
                TcpClient = null;
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
                if (TcpClient != null)
                {
                    ((IDisposable)TcpClient).Dispose();
                }
                base.Dispose(disposing);
            }
            _IsDisposed = true;
        }

        private void InitSocket()
        {
            TcpClient = new TcpClient();
            var tcpClient = TcpClient;
            var tcpClient1 = TcpClient;
            var num = timeout;
            var num1 = num;
            tcpClient1.SendTimeout = num;
            tcpClient.ReceiveTimeout = num1;
            TcpClient.Client.NoDelay = true;
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
            if (TcpClient == null)
            {
                InitSocket();
            }
            if (timeout != 0)
            {
                var connectHelper = new ConnectHelper(TcpClient);
                var t = TcpClient.ConnectAsync(Host, Port);
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
                TcpClient.ConnectAsync(Host, Port).Wait();
            }
            inputStream = TcpClient.GetStream();
            outputStream = TcpClient.GetStream();
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