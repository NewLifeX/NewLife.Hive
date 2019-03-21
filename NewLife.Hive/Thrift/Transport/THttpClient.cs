using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Thrift.Transport
{
    public class THttpClient : TTransport, IDisposable
    {
        private readonly Uri uri;

        private Stream inputStream;

        private MemoryStream outputStream = new MemoryStream();

        private int connectTimeout = 30000;

        private int readTimeout = 30000;

        private IDictionary<string, string> customHeaders = new Dictionary<string, string>();

        private HttpClient connection = new HttpClient();

        private IWebProxy proxy = new HttpClientHandler().Proxy;

        private bool _IsDisposed;

        public int ConnectTimeout
        {
            set
            {
                connectTimeout = value;
            }
        }

        public IDictionary<string, string> CustomHeaders
        {
            get
            {
                return customHeaders;
            }
        }

        public override bool IsOpen
        {
            get
            {
                return true;
            }
        }

        public IWebProxy Proxy
        {
            set
            {
                proxy = value;
            }
        }

        public int ReadTimeout
        {
            set
            {
                readTimeout = value;
            }
        }

        public THttpClient(Uri u)
        {
            uri = u;
            connection = CreateRequest();
        }

        public override void Close()
        {
            if (inputStream != null)
            {
                inputStream.Dispose();
                inputStream = null;
            }
            if (outputStream != null)
            {
                outputStream.Dispose();
                outputStream = null;
            }
        }

        private HttpClient CreateRequest()
        {
            HttpClientHandler version10 = new HttpClientHandler();
            version10.Proxy = proxy;
            using (var hc = new HttpClient(version10))
            {
                //HttpMethod.Post, this.uri
                if (connectTimeout > 0)
                {
                    hc.Timeout = new TimeSpan(connectTimeout);
                }
                //if (this.readTimeout > 0)
                //{
                //    version10.ReadWriteTimeout = this.readTimeout;
                //}
                hc.DefaultRequestHeaders.Add("ContentType", "application/x-thrift");
                hc.DefaultRequestHeaders.Add("Accept", "application/x-thrift");
                hc.DefaultRequestHeaders.Add("UserAgent", "C#/THttpClient");
                foreach (KeyValuePair<string, string> customHeader in customHeaders)
                {
                    hc.DefaultRequestHeaders.Add(customHeader.Key, customHeader.Value);
                }
                //version10.Method = "POST";
                //version10.ProtocolVersion = HttpVersion.Version10;
                return hc;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_IsDisposed && disposing)
            {
                if (inputStream != null)
                {
                    inputStream.Dispose();
                }
                if (outputStream != null)
                {
                    outputStream.Dispose();
                }
            }
            _IsDisposed = true;
        }

        public override void Flush()
        {
            try
            {
                SendRequest();
            }
            finally
            {
                outputStream = new MemoryStream();
            }
        }

        public override void Open()
        {
        }

        public override int Read(byte[] buf, int off, int len)
        {
            int num;
            if (inputStream == null)
            {
                throw new TTransportException(TTransportException.ExceptionType.NotOpen, "No request has been sent");
            }
            try
            {
                int num1 = inputStream.Read(buf, off, len);
                if (num1 == -1)
                {
                    throw new TTransportException(TTransportException.ExceptionType.EndOfFile, "No more data available");
                }
                num = num1;
            }
            catch (IOException oException)
            {
                throw new TTransportException(TTransportException.ExceptionType.Unknown, oException.ToString());
            }
            return num;
        }

        private void SendRequest()
        {
            try
            {
                var length = CreateRequest();
                byte[] array = outputStream.ToArray();
                using (Stream requestStream = new MemoryStream(array.Length))
                {
                    requestStream.Write(array, 0, (int)array.Length);
                    var sc = new StreamContent(requestStream);
                    var t = length.PostAsync(uri, sc);
                    t.Wait();
                    var o = t.Result.Content.ReadAsStreamAsync();
                    o.Wait();
                    inputStream = o.Result;
                }
            }
            catch (IOException oException)
            {
                throw new TTransportException(TTransportException.ExceptionType.Unknown, oException.ToString());
            }
            catch (Exception webException)
            {
                throw new TTransportException(TTransportException.ExceptionType.Unknown, string.Concat("Couldn't connect to server: ", webException));
            }
        }

        public override void Write(byte[] buf, int off, int len)
        {
            outputStream.Write(buf, off, len);
        }
    }
}