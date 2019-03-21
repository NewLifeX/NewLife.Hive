using System;
using System.IO;
using System.Net;
using System.Text;
using Thrift;
using Thrift.Protocol;

namespace Thrift.Transport
{
    //public class THttpHandler : IHttpHandler
    //{
    //    protected const string contentType = "application/x-thrift";

    //    protected TProcessor processor;

    //    protected TProtocolFactory inputProtocolFactory;

    //    protected TProtocolFactory outputProtocolFactory;

    //    protected Encoding encoding = Encoding.UTF8;

    //    public bool IsReusable
    //    {
    //        get
    //        {
    //            return true;
    //        }
    //    }

    //    public THttpHandler(TProcessor processor) : this(processor, new TBinaryProtocol.Factory())
    //    {
    //    }

    //    public THttpHandler(TProcessor processor, TProtocolFactory protocolFactory) : this(processor, protocolFactory, protocolFactory)
    //    {
    //    }

    //    public THttpHandler(TProcessor processor, TProtocolFactory inputProtocolFactory, TProtocolFactory outputProtocolFactory)
    //    {
    //        this.processor = processor;
    //        this.inputProtocolFactory = inputProtocolFactory;
    //        this.outputProtocolFactory = outputProtocolFactory;
    //    }

    //    public void ProcessRequest(HttpListenerContext context)
    //    {
    //        context.Response.ContentType = "application/x-thrift";
    //        context.Response.ContentEncoding = this.encoding;
    //        this.ProcessRequest(context.Request.InputStream, context.Response.OutputStream);
    //    }

    //    public void ProcessRequest(HttpContext context)
    //    {
    //        context.Response.ContentType = "application/x-thrift";
    //        context.Response.ContentEncoding = this.encoding;
    //        this.ProcessRequest(context.Request.InputStream, context.Response.OutputStream);
    //    }

    //    public void ProcessRequest(Stream input, Stream output)
    //    {
    //        TTransport tStreamTransport = new TStreamTransport(input, output);
    //        TProtocol protocol = null;
    //        TProtocol tProtocol = null;
    //        try
    //        {
    //            protocol = this.inputProtocolFactory.GetProtocol(tStreamTransport);
    //            tProtocol = this.outputProtocolFactory.GetProtocol(tStreamTransport);
    //            while (this.processor.Process(protocol, tProtocol))
    //            {
    //            }
    //        }
    //        catch (TTransportException tTransportException)
    //        {
    //        }
    //        catch (TApplicationException tApplicationException)
    //        {
    //            Console.Error.Write(tApplicationException);
    //        }
    //        catch (Exception exception)
    //        {
    //            Console.Error.Write(exception);
    //        }
    //        tStreamTransport.Close();
    //    }
    //}
}