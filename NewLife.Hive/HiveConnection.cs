using System;
using NewLife.Hive2;
using NewLife.Thrift.Protocol;
using NewLife.Thrift.Transport;

namespace NewLife.Hive
{
    public static class Hive2Helper
    {
        public static void CheckStatus(this TStatus status)
        {
            if (status.__isset.errorMessage)
            {
                throw new Exception(status.ErrorMessage);
            }
        }
    }

    /// <summary>Hive连接</summary>
    public class HiveConnection : DisposeBase
    {
        #region 属性
        private TSaslClientTransport _Transport;
        private TCLIService.Client _Client;
        private TSessionHandle _Session;

        public TProtocolVersion Version { get; }
        #endregion

        #region 构造
        public HiveConnection(String host, Int32 port, String userName = "None", String password = "None", TProtocolVersion version = TProtocolVersion.V7)
        {
            var socket = new TSocket(host, port);
            _Transport = new TSaslClientTransport(socket, userName, password);
            var protocol = new TBinaryProtocol(_Transport);
            _Client = new TCLIService.Client(protocol);
            Version = version;
        }

        protected override void OnDispose(Boolean disposing)
        {
            base.OnDispose(disposing);

            try
            {
                Close();
            }
            catch { }

            _Client = null;
            _Transport = null;
            _Session = null;
        }
        #endregion

        #region 方法
        public void Open()
        {
            if (_Transport != null && !_Transport.IsOpen) _Transport.Open();
            if (_Session == null) _Session = GetSession();
        }

        public void Close()
        {
            if (_Session != null) CloseSession();
            if (_Transport != null && _Transport.IsOpen) _Transport.Close();
        }

        private TSessionHandle GetSession()
        {
            var req = new TOpenSessionReq(Version);
            var resp = _Client.OpenSession(req);
            resp.Status.CheckStatus();
            return resp.SessionHandle;
        }

        private void CloseSession()
        {
            var req = new TCloseSessionReq
            {
                SessionHandle = _Session
            };
            var resp = _Client.CloseSession(req);
            resp.Status.CheckStatus();
        }

        public HiveCommand CreateCommand()
        {
            Open();

            return new HiveCommand(_Session, _Client, Version);
        }
        #endregion
    }
}