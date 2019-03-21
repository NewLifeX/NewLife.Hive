using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Thrift;
using Thrift.Protocol;

namespace NewLife.Hive2
{
    public partial class TCLIService
    {
        public interface Iface
        {
            TOpenSessionResp OpenSession(TOpenSessionReq req);
#if SILVERLIGHT
      IAsyncResult Begin_OpenSession(AsyncCallback callback, object state, TOpenSessionReq req);
      TOpenSessionResp End_OpenSession(IAsyncResult asyncResult);
#endif
            TCloseSessionResp CloseSession(TCloseSessionReq req);
#if SILVERLIGHT
      IAsyncResult Begin_CloseSession(AsyncCallback callback, object state, TCloseSessionReq req);
      TCloseSessionResp End_CloseSession(IAsyncResult asyncResult);
#endif
            TGetInfoResp GetInfo(TGetInfoReq req);
#if SILVERLIGHT
      IAsyncResult Begin_GetInfo(AsyncCallback callback, object state, TGetInfoReq req);
      TGetInfoResp End_GetInfo(IAsyncResult asyncResult);
#endif
            TExecuteStatementResp ExecuteStatement(TExecuteStatementReq req);
#if SILVERLIGHT
      IAsyncResult Begin_ExecuteStatement(AsyncCallback callback, object state, TExecuteStatementReq req);
      TExecuteStatementResp End_ExecuteStatement(IAsyncResult asyncResult);
#endif
            TGetTypeInfoResp GetTypeInfo(TGetTypeInfoReq req);
#if SILVERLIGHT
      IAsyncResult Begin_GetTypeInfo(AsyncCallback callback, object state, TGetTypeInfoReq req);
      TGetTypeInfoResp End_GetTypeInfo(IAsyncResult asyncResult);
#endif
            TGetCatalogsResp GetCatalogs(TGetCatalogsReq req);
#if SILVERLIGHT
      IAsyncResult Begin_GetCatalogs(AsyncCallback callback, object state, TGetCatalogsReq req);
      TGetCatalogsResp End_GetCatalogs(IAsyncResult asyncResult);
#endif
            TGetSchemasResp GetSchemas(TGetSchemasReq req);
#if SILVERLIGHT
      IAsyncResult Begin_GetSchemas(AsyncCallback callback, object state, TGetSchemasReq req);
      TGetSchemasResp End_GetSchemas(IAsyncResult asyncResult);
#endif
            TGetTablesResp GetTables(TGetTablesReq req);
#if SILVERLIGHT
      IAsyncResult Begin_GetTables(AsyncCallback callback, object state, TGetTablesReq req);
      TGetTablesResp End_GetTables(IAsyncResult asyncResult);
#endif
            TGetTableTypesResp GetTableTypes(TGetTableTypesReq req);
#if SILVERLIGHT
      IAsyncResult Begin_GetTableTypes(AsyncCallback callback, object state, TGetTableTypesReq req);
      TGetTableTypesResp End_GetTableTypes(IAsyncResult asyncResult);
#endif
            TGetColumnsResp GetColumns(TGetColumnsReq req);
#if SILVERLIGHT
      IAsyncResult Begin_GetColumns(AsyncCallback callback, object state, TGetColumnsReq req);
      TGetColumnsResp End_GetColumns(IAsyncResult asyncResult);
#endif
            TGetFunctionsResp GetFunctions(TGetFunctionsReq req);
#if SILVERLIGHT
      IAsyncResult Begin_GetFunctions(AsyncCallback callback, object state, TGetFunctionsReq req);
      TGetFunctionsResp End_GetFunctions(IAsyncResult asyncResult);
#endif
            TGetOperationStatusResp GetOperationStatus(TGetOperationStatusReq req);
#if SILVERLIGHT
      IAsyncResult Begin_GetOperationStatus(AsyncCallback callback, object state, TGetOperationStatusReq req);
      TGetOperationStatusResp End_GetOperationStatus(IAsyncResult asyncResult);
#endif
            TCancelOperationResp CancelOperation(TCancelOperationReq req);
#if SILVERLIGHT
      IAsyncResult Begin_CancelOperation(AsyncCallback callback, object state, TCancelOperationReq req);
      TCancelOperationResp End_CancelOperation(IAsyncResult asyncResult);
#endif
            TCloseOperationResp CloseOperation(TCloseOperationReq req);
#if SILVERLIGHT
      IAsyncResult Begin_CloseOperation(AsyncCallback callback, object state, TCloseOperationReq req);
      TCloseOperationResp End_CloseOperation(IAsyncResult asyncResult);
#endif
            TGetResultSetMetadataResp GetResultSetMetadata(TGetResultSetMetadataReq req);
#if SILVERLIGHT
      IAsyncResult Begin_GetResultSetMetadata(AsyncCallback callback, object state, TGetResultSetMetadataReq req);
      TGetResultSetMetadataResp End_GetResultSetMetadata(IAsyncResult asyncResult);
#endif
            TFetchResultsResp FetchResults(TFetchResultsReq req);
#if SILVERLIGHT
      IAsyncResult Begin_FetchResults(AsyncCallback callback, object state, TFetchResultsReq req);
      TFetchResultsResp End_FetchResults(IAsyncResult asyncResult);
#endif
            TGetDelegationTokenResp GetDelegationToken(TGetDelegationTokenReq req);
#if SILVERLIGHT
      IAsyncResult Begin_GetDelegationToken(AsyncCallback callback, object state, TGetDelegationTokenReq req);
      TGetDelegationTokenResp End_GetDelegationToken(IAsyncResult asyncResult);
#endif
            TCancelDelegationTokenResp CancelDelegationToken(TCancelDelegationTokenReq req);
#if SILVERLIGHT
      IAsyncResult Begin_CancelDelegationToken(AsyncCallback callback, object state, TCancelDelegationTokenReq req);
      TCancelDelegationTokenResp End_CancelDelegationToken(IAsyncResult asyncResult);
#endif
            TRenewDelegationTokenResp RenewDelegationToken(TRenewDelegationTokenReq req);
#if SILVERLIGHT
      IAsyncResult Begin_RenewDelegationToken(AsyncCallback callback, object state, TRenewDelegationTokenReq req);
      TRenewDelegationTokenResp End_RenewDelegationToken(IAsyncResult asyncResult);
#endif
        }

        public class Client : IDisposable, Iface
        {
            public Client(TProtocol prot) : this(prot, prot)
            {
            }

            public Client(TProtocol iprot, TProtocol oprot)
            {
                iprot_ = iprot;
                oprot_ = oprot;
            }

            protected TProtocol iprot_;
            protected TProtocol oprot_;
            protected Int32 seqid_;

            public TProtocol InputProtocol
            {
                get { return iprot_; }
            }
            public TProtocol OutputProtocol
            {
                get { return oprot_; }
            }


            #region " IDisposable Support "
            private Boolean _IsDisposed;

            // IDisposable
            public void Dispose()
            {
                Dispose(true);
            }


            protected virtual void Dispose(Boolean disposing)
            {
                if (!_IsDisposed)
                {
                    if (disposing)
                    {
                        if (iprot_ != null)
                        {
                            ((IDisposable)iprot_).Dispose();
                        }
                        if (oprot_ != null)
                        {
                            ((IDisposable)oprot_).Dispose();
                        }
                    }
                }
                _IsDisposed = true;
            }
            #endregion



#if SILVERLIGHT
      public IAsyncResult Begin_OpenSession(AsyncCallback callback, object state, TOpenSessionReq req)
      {
        return send_OpenSession(callback, state, req);
      }

      public TOpenSessionResp End_OpenSession(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_OpenSession();
      }

#endif

            public TOpenSessionResp OpenSession(TOpenSessionReq req)
            {
#if !SILVERLIGHT
                send_OpenSession(req);
                return recv_OpenSession();

#else
        var asyncResult = Begin_OpenSession(null, null, req);
        return End_OpenSession(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_OpenSession(AsyncCallback callback, object state, TOpenSessionReq req)
#else
            public void send_OpenSession(TOpenSessionReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("OpenSession", TMessageType.Call, seqid_));
                var args = new OpenSession_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TOpenSessionResp recv_OpenSession()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new OpenSession_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "OpenSession failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_CloseSession(AsyncCallback callback, object state, TCloseSessionReq req)
      {
        return send_CloseSession(callback, state, req);
      }

      public TCloseSessionResp End_CloseSession(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_CloseSession();
      }

#endif

            public TCloseSessionResp CloseSession(TCloseSessionReq req)
            {
#if !SILVERLIGHT
                send_CloseSession(req);
                return recv_CloseSession();

#else
        var asyncResult = Begin_CloseSession(null, null, req);
        return End_CloseSession(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_CloseSession(AsyncCallback callback, object state, TCloseSessionReq req)
#else
            public void send_CloseSession(TCloseSessionReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("CloseSession", TMessageType.Call, seqid_));
                var args = new CloseSession_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TCloseSessionResp recv_CloseSession()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new CloseSession_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "CloseSession failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_GetInfo(AsyncCallback callback, object state, TGetInfoReq req)
      {
        return send_GetInfo(callback, state, req);
      }

      public TGetInfoResp End_GetInfo(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetInfo();
      }

#endif

            public TGetInfoResp GetInfo(TGetInfoReq req)
            {
#if !SILVERLIGHT
                send_GetInfo(req);
                return recv_GetInfo();

#else
        var asyncResult = Begin_GetInfo(null, null, req);
        return End_GetInfo(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_GetInfo(AsyncCallback callback, object state, TGetInfoReq req)
#else
            public void send_GetInfo(TGetInfoReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("GetInfo", TMessageType.Call, seqid_));
                var args = new GetInfo_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TGetInfoResp recv_GetInfo()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new GetInfo_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetInfo failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_ExecuteStatement(AsyncCallback callback, object state, TExecuteStatementReq req)
      {
        return send_ExecuteStatement(callback, state, req);
      }

      public TExecuteStatementResp End_ExecuteStatement(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_ExecuteStatement();
      }

#endif

            public TExecuteStatementResp ExecuteStatement(TExecuteStatementReq req)
            {
#if !SILVERLIGHT
                send_ExecuteStatement(req);
                return recv_ExecuteStatement();

#else
        var asyncResult = Begin_ExecuteStatement(null, null, req);
        return End_ExecuteStatement(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_ExecuteStatement(AsyncCallback callback, object state, TExecuteStatementReq req)
#else
            public void send_ExecuteStatement(TExecuteStatementReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("ExecuteStatement", TMessageType.Call, seqid_));
                var args = new ExecuteStatement_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TExecuteStatementResp recv_ExecuteStatement()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new ExecuteStatement_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "ExecuteStatement failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_GetTypeInfo(AsyncCallback callback, object state, TGetTypeInfoReq req)
      {
        return send_GetTypeInfo(callback, state, req);
      }

      public TGetTypeInfoResp End_GetTypeInfo(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetTypeInfo();
      }

#endif

            public TGetTypeInfoResp GetTypeInfo(TGetTypeInfoReq req)
            {
#if !SILVERLIGHT
                send_GetTypeInfo(req);
                return recv_GetTypeInfo();

#else
        var asyncResult = Begin_GetTypeInfo(null, null, req);
        return End_GetTypeInfo(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_GetTypeInfo(AsyncCallback callback, object state, TGetTypeInfoReq req)
#else
            public void send_GetTypeInfo(TGetTypeInfoReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("GetTypeInfo", TMessageType.Call, seqid_));
                var args = new GetTypeInfo_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TGetTypeInfoResp recv_GetTypeInfo()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new GetTypeInfo_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetTypeInfo failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_GetCatalogs(AsyncCallback callback, object state, TGetCatalogsReq req)
      {
        return send_GetCatalogs(callback, state, req);
      }

      public TGetCatalogsResp End_GetCatalogs(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetCatalogs();
      }

#endif

            public TGetCatalogsResp GetCatalogs(TGetCatalogsReq req)
            {
#if !SILVERLIGHT
                send_GetCatalogs(req);
                return recv_GetCatalogs();

#else
        var asyncResult = Begin_GetCatalogs(null, null, req);
        return End_GetCatalogs(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_GetCatalogs(AsyncCallback callback, object state, TGetCatalogsReq req)
#else
            public void send_GetCatalogs(TGetCatalogsReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("GetCatalogs", TMessageType.Call, seqid_));
                var args = new GetCatalogs_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TGetCatalogsResp recv_GetCatalogs()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new GetCatalogs_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetCatalogs failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_GetSchemas(AsyncCallback callback, object state, TGetSchemasReq req)
      {
        return send_GetSchemas(callback, state, req);
      }

      public TGetSchemasResp End_GetSchemas(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetSchemas();
      }

#endif

            public TGetSchemasResp GetSchemas(TGetSchemasReq req)
            {
#if !SILVERLIGHT
                send_GetSchemas(req);
                return recv_GetSchemas();

#else
        var asyncResult = Begin_GetSchemas(null, null, req);
        return End_GetSchemas(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_GetSchemas(AsyncCallback callback, object state, TGetSchemasReq req)
#else
            public void send_GetSchemas(TGetSchemasReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("GetSchemas", TMessageType.Call, seqid_));
                var args = new GetSchemas_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TGetSchemasResp recv_GetSchemas()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new GetSchemas_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetSchemas failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_GetTables(AsyncCallback callback, object state, TGetTablesReq req)
      {
        return send_GetTables(callback, state, req);
      }

      public TGetTablesResp End_GetTables(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetTables();
      }

#endif

            public TGetTablesResp GetTables(TGetTablesReq req)
            {
#if !SILVERLIGHT
                send_GetTables(req);
                return recv_GetTables();

#else
        var asyncResult = Begin_GetTables(null, null, req);
        return End_GetTables(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_GetTables(AsyncCallback callback, object state, TGetTablesReq req)
#else
            public void send_GetTables(TGetTablesReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("GetTables", TMessageType.Call, seqid_));
                var args = new GetTables_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TGetTablesResp recv_GetTables()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new GetTables_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetTables failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_GetTableTypes(AsyncCallback callback, object state, TGetTableTypesReq req)
      {
        return send_GetTableTypes(callback, state, req);
      }

      public TGetTableTypesResp End_GetTableTypes(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetTableTypes();
      }

#endif

            public TGetTableTypesResp GetTableTypes(TGetTableTypesReq req)
            {
#if !SILVERLIGHT
                send_GetTableTypes(req);
                return recv_GetTableTypes();

#else
        var asyncResult = Begin_GetTableTypes(null, null, req);
        return End_GetTableTypes(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_GetTableTypes(AsyncCallback callback, object state, TGetTableTypesReq req)
#else
            public void send_GetTableTypes(TGetTableTypesReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("GetTableTypes", TMessageType.Call, seqid_));
                var args = new GetTableTypes_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TGetTableTypesResp recv_GetTableTypes()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new GetTableTypes_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetTableTypes failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_GetColumns(AsyncCallback callback, object state, TGetColumnsReq req)
      {
        return send_GetColumns(callback, state, req);
      }

      public TGetColumnsResp End_GetColumns(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetColumns();
      }

#endif

            public TGetColumnsResp GetColumns(TGetColumnsReq req)
            {
#if !SILVERLIGHT
                send_GetColumns(req);
                return recv_GetColumns();

#else
        var asyncResult = Begin_GetColumns(null, null, req);
        return End_GetColumns(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_GetColumns(AsyncCallback callback, object state, TGetColumnsReq req)
#else
            public void send_GetColumns(TGetColumnsReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("GetColumns", TMessageType.Call, seqid_));
                var args = new GetColumns_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TGetColumnsResp recv_GetColumns()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new GetColumns_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetColumns failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_GetFunctions(AsyncCallback callback, object state, TGetFunctionsReq req)
      {
        return send_GetFunctions(callback, state, req);
      }

      public TGetFunctionsResp End_GetFunctions(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetFunctions();
      }

#endif

            public TGetFunctionsResp GetFunctions(TGetFunctionsReq req)
            {
#if !SILVERLIGHT
                send_GetFunctions(req);
                return recv_GetFunctions();

#else
        var asyncResult = Begin_GetFunctions(null, null, req);
        return End_GetFunctions(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_GetFunctions(AsyncCallback callback, object state, TGetFunctionsReq req)
#else
            public void send_GetFunctions(TGetFunctionsReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("GetFunctions", TMessageType.Call, seqid_));
                var args = new GetFunctions_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TGetFunctionsResp recv_GetFunctions()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new GetFunctions_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetFunctions failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_GetOperationStatus(AsyncCallback callback, object state, TGetOperationStatusReq req)
      {
        return send_GetOperationStatus(callback, state, req);
      }

      public TGetOperationStatusResp End_GetOperationStatus(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetOperationStatus();
      }

#endif

            public TGetOperationStatusResp GetOperationStatus(TGetOperationStatusReq req)
            {
#if !SILVERLIGHT
                send_GetOperationStatus(req);
                return recv_GetOperationStatus();

#else
        var asyncResult = Begin_GetOperationStatus(null, null, req);
        return End_GetOperationStatus(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_GetOperationStatus(AsyncCallback callback, object state, TGetOperationStatusReq req)
#else
            public void send_GetOperationStatus(TGetOperationStatusReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("GetOperationStatus", TMessageType.Call, seqid_));
                var args = new GetOperationStatus_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TGetOperationStatusResp recv_GetOperationStatus()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new GetOperationStatus_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetOperationStatus failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_CancelOperation(AsyncCallback callback, object state, TCancelOperationReq req)
      {
        return send_CancelOperation(callback, state, req);
      }

      public TCancelOperationResp End_CancelOperation(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_CancelOperation();
      }

#endif

            public TCancelOperationResp CancelOperation(TCancelOperationReq req)
            {
#if !SILVERLIGHT
                send_CancelOperation(req);
                return recv_CancelOperation();

#else
        var asyncResult = Begin_CancelOperation(null, null, req);
        return End_CancelOperation(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_CancelOperation(AsyncCallback callback, object state, TCancelOperationReq req)
#else
            public void send_CancelOperation(TCancelOperationReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("CancelOperation", TMessageType.Call, seqid_));
                var args = new CancelOperation_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TCancelOperationResp recv_CancelOperation()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new CancelOperation_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "CancelOperation failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_CloseOperation(AsyncCallback callback, object state, TCloseOperationReq req)
      {
        return send_CloseOperation(callback, state, req);
      }

      public TCloseOperationResp End_CloseOperation(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_CloseOperation();
      }

#endif

            public TCloseOperationResp CloseOperation(TCloseOperationReq req)
            {
#if !SILVERLIGHT
                send_CloseOperation(req);
                return recv_CloseOperation();

#else
        var asyncResult = Begin_CloseOperation(null, null, req);
        return End_CloseOperation(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_CloseOperation(AsyncCallback callback, object state, TCloseOperationReq req)
#else
            public void send_CloseOperation(TCloseOperationReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("CloseOperation", TMessageType.Call, seqid_));
                var args = new CloseOperation_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TCloseOperationResp recv_CloseOperation()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new CloseOperation_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "CloseOperation failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_GetResultSetMetadata(AsyncCallback callback, object state, TGetResultSetMetadataReq req)
      {
        return send_GetResultSetMetadata(callback, state, req);
      }

      public TGetResultSetMetadataResp End_GetResultSetMetadata(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetResultSetMetadata();
      }

#endif

            public TGetResultSetMetadataResp GetResultSetMetadata(TGetResultSetMetadataReq req)
            {
#if !SILVERLIGHT
                send_GetResultSetMetadata(req);
                return recv_GetResultSetMetadata();

#else
        var asyncResult = Begin_GetResultSetMetadata(null, null, req);
        return End_GetResultSetMetadata(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_GetResultSetMetadata(AsyncCallback callback, object state, TGetResultSetMetadataReq req)
#else
            public void send_GetResultSetMetadata(TGetResultSetMetadataReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("GetResultSetMetadata", TMessageType.Call, seqid_));
                var args = new GetResultSetMetadata_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TGetResultSetMetadataResp recv_GetResultSetMetadata()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new GetResultSetMetadata_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetResultSetMetadata failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_FetchResults(AsyncCallback callback, object state, TFetchResultsReq req)
      {
        return send_FetchResults(callback, state, req);
      }

      public TFetchResultsResp End_FetchResults(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_FetchResults();
      }

#endif

            public TFetchResultsResp FetchResults(TFetchResultsReq req)
            {
#if !SILVERLIGHT
                send_FetchResults(req);
                return recv_FetchResults();

#else
        var asyncResult = Begin_FetchResults(null, null, req);
        return End_FetchResults(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_FetchResults(AsyncCallback callback, object state, TFetchResultsReq req)
#else
            public void send_FetchResults(TFetchResultsReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("FetchResults", TMessageType.Call, seqid_));
                var args = new FetchResults_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TFetchResultsResp recv_FetchResults()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new FetchResults_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "FetchResults failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_GetDelegationToken(AsyncCallback callback, object state, TGetDelegationTokenReq req)
      {
        return send_GetDelegationToken(callback, state, req);
      }

      public TGetDelegationTokenResp End_GetDelegationToken(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_GetDelegationToken();
      }

#endif

            public TGetDelegationTokenResp GetDelegationToken(TGetDelegationTokenReq req)
            {
#if !SILVERLIGHT
                send_GetDelegationToken(req);
                return recv_GetDelegationToken();

#else
        var asyncResult = Begin_GetDelegationToken(null, null, req);
        return End_GetDelegationToken(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_GetDelegationToken(AsyncCallback callback, object state, TGetDelegationTokenReq req)
#else
            public void send_GetDelegationToken(TGetDelegationTokenReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("GetDelegationToken", TMessageType.Call, seqid_));
                var args = new GetDelegationToken_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TGetDelegationTokenResp recv_GetDelegationToken()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new GetDelegationToken_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "GetDelegationToken failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_CancelDelegationToken(AsyncCallback callback, object state, TCancelDelegationTokenReq req)
      {
        return send_CancelDelegationToken(callback, state, req);
      }

      public TCancelDelegationTokenResp End_CancelDelegationToken(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_CancelDelegationToken();
      }

#endif

            public TCancelDelegationTokenResp CancelDelegationToken(TCancelDelegationTokenReq req)
            {
#if !SILVERLIGHT
                send_CancelDelegationToken(req);
                return recv_CancelDelegationToken();

#else
        var asyncResult = Begin_CancelDelegationToken(null, null, req);
        return End_CancelDelegationToken(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_CancelDelegationToken(AsyncCallback callback, object state, TCancelDelegationTokenReq req)
#else
            public void send_CancelDelegationToken(TCancelDelegationTokenReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("CancelDelegationToken", TMessageType.Call, seqid_));
                var args = new CancelDelegationToken_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TCancelDelegationTokenResp recv_CancelDelegationToken()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new CancelDelegationToken_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "CancelDelegationToken failed: unknown result");
            }


#if SILVERLIGHT
      public IAsyncResult Begin_RenewDelegationToken(AsyncCallback callback, object state, TRenewDelegationTokenReq req)
      {
        return send_RenewDelegationToken(callback, state, req);
      }

      public TRenewDelegationTokenResp End_RenewDelegationToken(IAsyncResult asyncResult)
      {
        oprot_.Transport.EndFlush(asyncResult);
        return recv_RenewDelegationToken();
      }

#endif

            public TRenewDelegationTokenResp RenewDelegationToken(TRenewDelegationTokenReq req)
            {
#if !SILVERLIGHT
                send_RenewDelegationToken(req);
                return recv_RenewDelegationToken();

#else
        var asyncResult = Begin_RenewDelegationToken(null, null, req);
        return End_RenewDelegationToken(asyncResult);

#endif
            }
#if SILVERLIGHT
      public IAsyncResult send_RenewDelegationToken(AsyncCallback callback, object state, TRenewDelegationTokenReq req)
#else
            public void send_RenewDelegationToken(TRenewDelegationTokenReq req)
#endif
            {
                oprot_.WriteMessageBegin(new TMessage("RenewDelegationToken", TMessageType.Call, seqid_));
                var args = new RenewDelegationToken_args
                {
                    Req = req
                };
                args.Write(oprot_);
                oprot_.WriteMessageEnd();
#if SILVERLIGHT
        return oprot_.Transport.BeginFlush(callback, state);
#else
                oprot_.Transport.Flush();
#endif
            }

            public TRenewDelegationTokenResp recv_RenewDelegationToken()
            {
                var msg = iprot_.ReadMessageBegin();
                if (msg.Type == TMessageType.Exception)
                {
                    var x = TApplicationException.Read(iprot_);
                    iprot_.ReadMessageEnd();
                    throw x;
                }
                var result = new RenewDelegationToken_result();
                result.Read(iprot_);
                iprot_.ReadMessageEnd();
                if (result.__isset.success)
                {
                    return result.Success;
                }
                throw new TApplicationException(TApplicationException.ExceptionType.MissingResult, "RenewDelegationToken failed: unknown result");
            }

        }
        public class Processor : TProcessor
        {
            public Processor(Iface iface)
            {
                iface_ = iface;
                processMap_["OpenSession"] = OpenSession_Process;
                processMap_["CloseSession"] = CloseSession_Process;
                processMap_["GetInfo"] = GetInfo_Process;
                processMap_["ExecuteStatement"] = ExecuteStatement_Process;
                processMap_["GetTypeInfo"] = GetTypeInfo_Process;
                processMap_["GetCatalogs"] = GetCatalogs_Process;
                processMap_["GetSchemas"] = GetSchemas_Process;
                processMap_["GetTables"] = GetTables_Process;
                processMap_["GetTableTypes"] = GetTableTypes_Process;
                processMap_["GetColumns"] = GetColumns_Process;
                processMap_["GetFunctions"] = GetFunctions_Process;
                processMap_["GetOperationStatus"] = GetOperationStatus_Process;
                processMap_["CancelOperation"] = CancelOperation_Process;
                processMap_["CloseOperation"] = CloseOperation_Process;
                processMap_["GetResultSetMetadata"] = GetResultSetMetadata_Process;
                processMap_["FetchResults"] = FetchResults_Process;
                processMap_["GetDelegationToken"] = GetDelegationToken_Process;
                processMap_["CancelDelegationToken"] = CancelDelegationToken_Process;
                processMap_["RenewDelegationToken"] = RenewDelegationToken_Process;
            }

            protected delegate void ProcessFunction(Int32 seqid, TProtocol iprot, TProtocol oprot);
            private Iface iface_;
            protected Dictionary<String, ProcessFunction> processMap_ = new Dictionary<String, ProcessFunction>();

            public Boolean Process(TProtocol iprot, TProtocol oprot)
            {
                try
                {
                    var msg = iprot.ReadMessageBegin();
                    processMap_.TryGetValue(msg.Name, out var fn);
                    if (fn == null)
                    {
                        TProtocolUtil.Skip(iprot, TType.Struct);
                        iprot.ReadMessageEnd();
                        var x = new TApplicationException(TApplicationException.ExceptionType.UnknownMethod, "Invalid method name: '" + msg.Name + "'");
                        oprot.WriteMessageBegin(new TMessage(msg.Name, TMessageType.Exception, msg.SeqID));
                        x.Write(oprot);
                        oprot.WriteMessageEnd();
                        oprot.Transport.Flush();
                        return true;
                    }
                    fn(msg.SeqID, iprot, oprot);
                }
                catch (IOException)
                {
                    return false;
                }
                return true;
            }

            public void OpenSession_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new OpenSession_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new OpenSession_result
                {
                    Success = iface_.OpenSession(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("OpenSession", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void CloseSession_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new CloseSession_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new CloseSession_result
                {
                    Success = iface_.CloseSession(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("CloseSession", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void GetInfo_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new GetInfo_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new GetInfo_result
                {
                    Success = iface_.GetInfo(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("GetInfo", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void ExecuteStatement_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new ExecuteStatement_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new ExecuteStatement_result
                {
                    Success = iface_.ExecuteStatement(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("ExecuteStatement", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void GetTypeInfo_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new GetTypeInfo_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new GetTypeInfo_result
                {
                    Success = iface_.GetTypeInfo(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("GetTypeInfo", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void GetCatalogs_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new GetCatalogs_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new GetCatalogs_result
                {
                    Success = iface_.GetCatalogs(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("GetCatalogs", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void GetSchemas_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new GetSchemas_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new GetSchemas_result
                {
                    Success = iface_.GetSchemas(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("GetSchemas", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void GetTables_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new GetTables_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new GetTables_result
                {
                    Success = iface_.GetTables(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("GetTables", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void GetTableTypes_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new GetTableTypes_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new GetTableTypes_result
                {
                    Success = iface_.GetTableTypes(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("GetTableTypes", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void GetColumns_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new GetColumns_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new GetColumns_result
                {
                    Success = iface_.GetColumns(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("GetColumns", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void GetFunctions_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new GetFunctions_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new GetFunctions_result
                {
                    Success = iface_.GetFunctions(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("GetFunctions", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void GetOperationStatus_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new GetOperationStatus_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new GetOperationStatus_result
                {
                    Success = iface_.GetOperationStatus(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("GetOperationStatus", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void CancelOperation_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new CancelOperation_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new CancelOperation_result
                {
                    Success = iface_.CancelOperation(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("CancelOperation", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void CloseOperation_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new CloseOperation_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new CloseOperation_result
                {
                    Success = iface_.CloseOperation(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("CloseOperation", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void GetResultSetMetadata_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new GetResultSetMetadata_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new GetResultSetMetadata_result
                {
                    Success = iface_.GetResultSetMetadata(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("GetResultSetMetadata", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void FetchResults_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new FetchResults_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new FetchResults_result
                {
                    Success = iface_.FetchResults(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("FetchResults", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void GetDelegationToken_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new GetDelegationToken_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new GetDelegationToken_result
                {
                    Success = iface_.GetDelegationToken(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("GetDelegationToken", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void CancelDelegationToken_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new CancelDelegationToken_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new CancelDelegationToken_result
                {
                    Success = iface_.CancelDelegationToken(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("CancelDelegationToken", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

            public void RenewDelegationToken_Process(Int32 seqid, TProtocol iprot, TProtocol oprot)
            {
                var args = new RenewDelegationToken_args();
                args.Read(iprot);
                iprot.ReadMessageEnd();
                var result = new RenewDelegationToken_result
                {
                    Success = iface_.RenewDelegationToken(args.Req)
                };
                oprot.WriteMessageBegin(new TMessage("RenewDelegationToken", TMessageType.Reply, seqid));
                result.Write(oprot);
                oprot.WriteMessageEnd();
                oprot.Transport.Flush();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class OpenSession_args : TBase
        {
            private TOpenSessionReq _req;

            public TOpenSessionReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public OpenSession_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TOpenSessionReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("OpenSession_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("OpenSession_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class OpenSession_result : TBase
        {
            private TOpenSessionResp _success;

            public TOpenSessionResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public OpenSession_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TOpenSessionResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("OpenSession_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("OpenSession_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class CloseSession_args : TBase
        {
            private TCloseSessionReq _req;

            public TCloseSessionReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public CloseSession_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TCloseSessionReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("CloseSession_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("CloseSession_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class CloseSession_result : TBase
        {
            private TCloseSessionResp _success;

            public TCloseSessionResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public CloseSession_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TCloseSessionResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("CloseSession_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("CloseSession_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetInfo_args : TBase
        {
            private TGetInfoReq _req;

            public TGetInfoReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public GetInfo_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TGetInfoReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetInfo_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetInfo_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetInfo_result : TBase
        {
            private TGetInfoResp _success;

            public TGetInfoResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public GetInfo_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TGetInfoResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetInfo_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetInfo_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class ExecuteStatement_args : TBase
        {
            private TExecuteStatementReq _req;

            public TExecuteStatementReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public ExecuteStatement_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TExecuteStatementReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("ExecuteStatement_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("ExecuteStatement_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class ExecuteStatement_result : TBase
        {
            private TExecuteStatementResp _success;

            public TExecuteStatementResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public ExecuteStatement_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TExecuteStatementResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("ExecuteStatement_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("ExecuteStatement_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetTypeInfo_args : TBase
        {
            private TGetTypeInfoReq _req;

            public TGetTypeInfoReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public GetTypeInfo_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TGetTypeInfoReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetTypeInfo_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetTypeInfo_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetTypeInfo_result : TBase
        {
            private TGetTypeInfoResp _success;

            public TGetTypeInfoResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public GetTypeInfo_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TGetTypeInfoResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetTypeInfo_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetTypeInfo_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetCatalogs_args : TBase
        {
            private TGetCatalogsReq _req;

            public TGetCatalogsReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public GetCatalogs_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TGetCatalogsReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetCatalogs_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetCatalogs_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetCatalogs_result : TBase
        {
            private TGetCatalogsResp _success;

            public TGetCatalogsResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public GetCatalogs_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TGetCatalogsResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetCatalogs_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetCatalogs_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetSchemas_args : TBase
        {
            private TGetSchemasReq _req;

            public TGetSchemasReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public GetSchemas_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TGetSchemasReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetSchemas_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetSchemas_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetSchemas_result : TBase
        {
            private TGetSchemasResp _success;

            public TGetSchemasResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public GetSchemas_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TGetSchemasResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetSchemas_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetSchemas_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetTables_args : TBase
        {
            private TGetTablesReq _req;

            public TGetTablesReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public GetTables_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TGetTablesReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetTables_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetTables_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetTables_result : TBase
        {
            private TGetTablesResp _success;

            public TGetTablesResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public GetTables_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TGetTablesResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetTables_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetTables_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetTableTypes_args : TBase
        {
            private TGetTableTypesReq _req;

            public TGetTableTypesReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public GetTableTypes_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TGetTableTypesReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetTableTypes_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetTableTypes_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetTableTypes_result : TBase
        {
            private TGetTableTypesResp _success;

            public TGetTableTypesResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public GetTableTypes_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TGetTableTypesResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetTableTypes_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetTableTypes_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetColumns_args : TBase
        {
            private TGetColumnsReq _req;

            public TGetColumnsReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public GetColumns_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TGetColumnsReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetColumns_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetColumns_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetColumns_result : TBase
        {
            private TGetColumnsResp _success;

            public TGetColumnsResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public GetColumns_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TGetColumnsResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetColumns_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetColumns_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetFunctions_args : TBase
        {
            private TGetFunctionsReq _req;

            public TGetFunctionsReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public GetFunctions_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TGetFunctionsReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetFunctions_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetFunctions_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetFunctions_result : TBase
        {
            private TGetFunctionsResp _success;

            public TGetFunctionsResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public GetFunctions_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TGetFunctionsResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetFunctions_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetFunctions_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetOperationStatus_args : TBase
        {
            private TGetOperationStatusReq _req;

            public TGetOperationStatusReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public GetOperationStatus_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TGetOperationStatusReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetOperationStatus_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetOperationStatus_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetOperationStatus_result : TBase
        {
            private TGetOperationStatusResp _success;

            public TGetOperationStatusResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public GetOperationStatus_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TGetOperationStatusResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetOperationStatus_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetOperationStatus_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class CancelOperation_args : TBase
        {
            private TCancelOperationReq _req;

            public TCancelOperationReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public CancelOperation_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TCancelOperationReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("CancelOperation_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("CancelOperation_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class CancelOperation_result : TBase
        {
            private TCancelOperationResp _success;

            public TCancelOperationResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public CancelOperation_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TCancelOperationResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("CancelOperation_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("CancelOperation_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class CloseOperation_args : TBase
        {
            private TCloseOperationReq _req;

            public TCloseOperationReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public CloseOperation_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TCloseOperationReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("CloseOperation_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("CloseOperation_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class CloseOperation_result : TBase
        {
            private TCloseOperationResp _success;

            public TCloseOperationResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public CloseOperation_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TCloseOperationResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("CloseOperation_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("CloseOperation_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetResultSetMetadata_args : TBase
        {
            private TGetResultSetMetadataReq _req;

            public TGetResultSetMetadataReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public GetResultSetMetadata_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TGetResultSetMetadataReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetResultSetMetadata_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetResultSetMetadata_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetResultSetMetadata_result : TBase
        {
            private TGetResultSetMetadataResp _success;

            public TGetResultSetMetadataResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public GetResultSetMetadata_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TGetResultSetMetadataResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetResultSetMetadata_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetResultSetMetadata_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class FetchResults_args : TBase
        {
            private TFetchResultsReq _req;

            public TFetchResultsReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public FetchResults_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TFetchResultsReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("FetchResults_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("FetchResults_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class FetchResults_result : TBase
        {
            private TFetchResultsResp _success;

            public TFetchResultsResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public FetchResults_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TFetchResultsResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("FetchResults_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("FetchResults_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetDelegationToken_args : TBase
        {
            private TGetDelegationTokenReq _req;

            public TGetDelegationTokenReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public GetDelegationToken_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TGetDelegationTokenReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetDelegationToken_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetDelegationToken_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class GetDelegationToken_result : TBase
        {
            private TGetDelegationTokenResp _success;

            public TGetDelegationTokenResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public GetDelegationToken_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TGetDelegationTokenResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("GetDelegationToken_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("GetDelegationToken_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class CancelDelegationToken_args : TBase
        {
            private TCancelDelegationTokenReq _req;

            public TCancelDelegationTokenReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public CancelDelegationToken_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TCancelDelegationTokenReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("CancelDelegationToken_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("CancelDelegationToken_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class CancelDelegationToken_result : TBase
        {
            private TCancelDelegationTokenResp _success;

            public TCancelDelegationTokenResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public CancelDelegationToken_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TCancelDelegationTokenResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("CancelDelegationToken_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("CancelDelegationToken_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class RenewDelegationToken_args : TBase
        {
            private TRenewDelegationTokenReq _req;

            public TRenewDelegationTokenReq Req
            {
                get
                {
                    return _req;
                }
                set
                {
                    __isset.req = true;
                    _req = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean req;
            }

            public RenewDelegationToken_args()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 1:
                            if (field.Type == TType.Struct)
                            {
                                Req = new TRenewDelegationTokenReq();
                                Req.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("RenewDelegationToken_args");
                oprot.WriteStructBegin(struc);
                var field = new TField();
                if (Req != null && __isset.req)
                {
                    field.Name = "req";
                    field.Type = TType.Struct;
                    field.ID = 1;
                    oprot.WriteFieldBegin(field);
                    Req.Write(oprot);
                    oprot.WriteFieldEnd();
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("RenewDelegationToken_args(");
                sb.Append("Req: ");
                sb.Append(Req == null ? "<null>" : Req.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }


#if !SILVERLIGHT
        [Serializable]
#endif
        public partial class RenewDelegationToken_result : TBase
        {
            private TRenewDelegationTokenResp _success;

            public TRenewDelegationTokenResp Success
            {
                get
                {
                    return _success;
                }
                set
                {
                    __isset.success = true;
                    _success = value;
                }
            }


            public Isset __isset;
#if !SILVERLIGHT
            [Serializable]
#endif
            public struct Isset
            {
                public Boolean success;
            }

            public RenewDelegationToken_result()
            {
            }

            public void Read(TProtocol iprot)
            {
                TField field;
                iprot.ReadStructBegin();
                while (true)
                {
                    field = iprot.ReadFieldBegin();
                    if (field.Type == TType.Stop)
                    {
                        break;
                    }
                    switch (field.ID)
                    {
                        case 0:
                            if (field.Type == TType.Struct)
                            {
                                Success = new TRenewDelegationTokenResp();
                                Success.Read(iprot);
                            }
                            else
                            {
                                TProtocolUtil.Skip(iprot, field.Type);
                            }
                            break;
                        default:
                            TProtocolUtil.Skip(iprot, field.Type);
                            break;
                    }
                    iprot.ReadFieldEnd();
                }
                iprot.ReadStructEnd();
            }

            public void Write(TProtocol oprot)
            {
                var struc = new TStruct("RenewDelegationToken_result");
                oprot.WriteStructBegin(struc);
                var field = new TField();

                if (__isset.success)
                {
                    if (Success != null)
                    {
                        field.Name = "Success";
                        field.Type = TType.Struct;
                        field.ID = 0;
                        oprot.WriteFieldBegin(field);
                        Success.Write(oprot);
                        oprot.WriteFieldEnd();
                    }
                }
                oprot.WriteFieldStop();
                oprot.WriteStructEnd();
            }

            public override String ToString()
            {
                var sb = new StringBuilder("RenewDelegationToken_result(");
                sb.Append("Success: ");
                sb.Append(Success == null ? "<null>" : Success.ToString());
                sb.Append(")");
                return sb.ToString();
            }

        }

    }
}
