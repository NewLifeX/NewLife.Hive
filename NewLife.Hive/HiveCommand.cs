using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NewLife.Data;
using NewLife.Hive2;

namespace NewLife.Hive
{
    /// <summary>命令</summary>
    public class HiveCommand : DisposeBase
    {
        #region 属性
        private TSessionHandle _Session;
        private TCLIService.Client _Client;
        private TOperationHandle _Operation;
        private TTableSchema _LastSchema;

        public TProtocolVersion Version { get; }
        #endregion

        #region 构造
        public HiveCommand(TSessionHandle session, TCLIService.Client client, TProtocolVersion version = TProtocolVersion.V7)
        {
            _Session = session;
            _Client = client;
            Version = version;
        }

        protected override void OnDispose(Boolean disposing)
        {
            base.OnDispose(disposing);

            CloseOperation();

            _LastSchema = null;
            _Client = null;
            _Session = null;
        }
        #endregion

        #region 执行
        public void Execute(String statement)
        {
            CloseOperation();

            var req = new TExecuteStatementReq()
            {
                SessionHandle = _Session,
                Statement = statement,
            };

            _LastSchema = null;

            var resp = _Client.ExecuteStatement(req);
            resp.Status.CheckStatus();
            _Operation = resp.OperationHandle;
        }

        private void CloseOperation()
        {
            if (_Operation != null)
            {
                var req = new TCloseOperationReq
                {
                    OperationHandle = _Operation
                };
                var resp = _Client.CloseOperation(req);
                resp.Status.CheckStatus();
            }
        }
        #endregion

        #region 查询
        /// <summary>批量获取数据</summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public DbTable Fetch(Int32 size)
        {
            var cs = GetSchema()?.Columns;
            if (cs == null || cs.Count == 0) return null;

            // V5根据行获取数据，不支持
            if (Version <= TProtocolVersion.V5) throw new NotSupportedException();

            // 获取列信息
            var dt = new DbTable
            {
                Columns = cs.Select(i => i.ColumnName).ToArray()
            };

            //  获取数据
            var set = FetchData(size);
            if (set?.Columns != null && set.Columns.Count > 0)
            {
                var cols = new List<IList>();
                foreach (var item in set.Columns)
                {
                    cols.Add(GetrValue(item));
                }

                var rowCount = cols[0].Count;
                dt.Rows = new List<Object[]>(rowCount);
                if (rowCount > 0)
                {
                    // 修补类型
                    if (dt.Types == null || dt.Types.Length != cols.Count)
                    {
                        dt.Types = new Type[cols.Count];
                        for (var k = 0; k < cols.Count; k++)
                        {
                            dt.Types[k] = cols[k][0]?.GetType();
                        }
                    }

                    // 遍历所有行
                    for (var i = 0; i < rowCount; i++)
                    {
                        var row = new Object[cols.Count];
                        for (var k = 0; k < cols.Count; k++)
                        {
                            row[k] = cols[k][i];
                        }
                        dt.Rows.Add(row);
                    }
                }
            }

            return dt;
        }

        private IList GetrValue(TColumn value)
        {
            if (value.__isset.stringVal)
                return value.StringVal.Values;
            else if (value.__isset.i32Val)
                return value.I32Val.Values;
            else if (value.__isset.boolVal)
                return value.BoolVal.Values;
            else if (value.__isset.doubleVal)
                return value.DoubleVal.Values;
            else if (value.__isset.byteVal)
                return value.ByteVal.Values;
            else if (value.__isset.i64Val)
                return value.I64Val.Values;
            else if (value.__isset.i16Val)
                return value.I16Val.Values;
            else
                return null;
        }

        public TRowSet FetchData(Int32 count = Int32.MaxValue)
        {
            if (_Operation == null || !_Operation.HasResultSet) return null;

            var req = new TFetchResultsReq()
            {
                MaxRows = count,
                Orientation = TFetchOrientation.FETCH_NEXT,
                OperationHandle = _Operation,
            };
            var rs = _Client.FetchResults(req);
            rs.Status.CheckStatus();

            return rs.Results;
        }

        public TTableSchema GetSchema()
        {
            if (_Operation == null || !_Operation.HasResultSet) return null;

            if (_LastSchema == null)
            {
                var req = new TGetResultSetMetadataReq(_Operation);
                var rs = _Client.GetResultSetMetadata(req);
                rs.Status.CheckStatus();
                _LastSchema = rs.Schema;
            }

            return _LastSchema;
        }
        #endregion
    }
}