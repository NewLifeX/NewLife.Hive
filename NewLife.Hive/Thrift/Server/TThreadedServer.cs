using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Thrift;
using Thrift.Collections;
using Thrift.Protocol;
using Thrift.Transport;

namespace Thrift.Server
{
    public class TThreadedServer : TServer
    {
        private const int DEFAULT_MAX_THREADS = 100;

        private volatile bool stop;

        private readonly int maxThreads;

        private Queue<TTransport> clientQueue;

        private THashSet<Thread> clientThreads;

        private object clientLock;

        private Thread workerThread;

        public TThreadedServer(TProcessor processor, TServerTransport serverTransport) : this(processor, serverTransport, new TTransportFactory(), new TTransportFactory(), new TBinaryProtocol.Factory(), new TBinaryProtocol.Factory(), 100, new TServer.LogDelegate(TServer.DefaultLogDelegate))
        {
        }

        public TThreadedServer(TProcessor processor, TServerTransport serverTransport, TServer.LogDelegate logDelegate) : this(processor, serverTransport, new TTransportFactory(), new TTransportFactory(), new TBinaryProtocol.Factory(), new TBinaryProtocol.Factory(), 100, logDelegate)
        {
        }

        public TThreadedServer(TProcessor processor, TServerTransport serverTransport, TTransportFactory transportFactory, TProtocolFactory protocolFactory) : this(processor, serverTransport, transportFactory, transportFactory, protocolFactory, protocolFactory, 100, new TServer.LogDelegate(TServer.DefaultLogDelegate))
        {
        }

        public TThreadedServer(TProcessor processor, TServerTransport serverTransport, TTransportFactory inputTransportFactory, TTransportFactory outputTransportFactory, TProtocolFactory inputProtocolFactory, TProtocolFactory outputProtocolFactory, int maxThreads, TServer.LogDelegate logDel) : base(processor, serverTransport, inputTransportFactory, outputTransportFactory, inputProtocolFactory, outputProtocolFactory, logDel)
        {
            this.maxThreads = maxThreads;
            clientQueue = new Queue<TTransport>();
            clientLock = new object();
            clientThreads = new THashSet<Thread>();
        }

        private void ClientWorker(object context)
        {
            TTransport tTransport = (TTransport)context;
            TTransport tTransport1 = null;
            TTransport tTransport2 = null;
            TProtocol protocol = null;
            TProtocol tProtocol = null;
            try
            {
                TTransport transport = inputTransportFactory.GetTransport(tTransport);
                tTransport1 = transport;
                using (transport)
                {
                    TTransport transport1 = outputTransportFactory.GetTransport(tTransport);
                    tTransport2 = transport1;
                    using (transport1)
                    {
                        protocol = inputProtocolFactory.GetProtocol(tTransport1);
                        tProtocol = outputProtocolFactory.GetProtocol(tTransport2);
                        while (processor.Process(protocol, tProtocol))
                        {
                        }
                    }
                }
            }
            catch (TTransportException tTransportException)
            {
            }
            catch (Exception exception)
            {
                logDelegate(string.Concat("Error: ", exception));
            }
            lock (clientLock)
            {
                clientThreads.Remove(Thread.CurrentThread);
                Monitor.Pulse(clientLock);
            }
        }

        private void Execute()
        {
            TTransport tTransport;
            Thread thread;
            while (!stop)
            {
                lock (clientLock)
                {
                    while (clientThreads.Count >= maxThreads)
                    {
                        Monitor.Wait(clientLock);
                    }
                    while (clientQueue.Count == 0)
                    {
                        Monitor.Wait(clientLock);
                    }
                    tTransport = clientQueue.Dequeue();
                    thread = new Thread(new ParameterizedThreadStart(ClientWorker));
                    clientThreads.Add(thread);
                }
                thread.Start(tTransport);
            }
        }

        public override void Serve()
        {
            try
            {
                workerThread = new Thread(new ThreadStart(Execute));
                workerThread.Start();
                serverTransport.Listen();
            }
            catch (TTransportException tTransportException)
            {
                logDelegate(string.Concat("Error, could not listen on ServerTransport: ", tTransportException));
                return;
            }
            while (!stop)
            {
                int num = 0;
                try
                {
                    TTransport tTransport = serverTransport.Accept();
                    lock (clientLock)
                    {
                        clientQueue.Enqueue(tTransport);
                        Monitor.Pulse(clientLock);
                    }
                }
                catch (TTransportException tTransportException2)
                {
                    TTransportException tTransportException1 = tTransportException2;
                    if (!stop)
                    {
                        num++;
                        logDelegate(tTransportException1.ToString());
                    }
                    else
                    {
                        logDelegate(string.Concat("TThreadPoolServer was shutting down, caught ", tTransportException1));
                    }
                }
            }
            if (stop)
            {
                try
                {
                    serverTransport.Close();
                }
                catch (TTransportException tTransportException3)
                {
                    logDelegate(string.Concat("TServeTransport failed on close: ", tTransportException3.Message));
                }
                stop = false;
            }
        }

        public override void Stop()
        {
            stop = true;
            serverTransport.Close();
            workerThread.Join();
            foreach (Thread clientThread in clientThreads)
            {
                clientThread.Join();
            }
        }
    }
}