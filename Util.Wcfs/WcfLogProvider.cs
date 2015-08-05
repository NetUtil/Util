using System;
using System.Collections.Generic;
using System.ServiceModel.Dispatcher;
using Util.Logs;
using Util.Logs.Log4;

namespace Util.Wcfs {
    /// <summary>
    /// Wcf日志提供程序
    /// </summary>
    internal sealed class WcfLogProvider : IOperationInvoker {
        /// <summary>
        /// 初始化Wcf日志提供程序
        /// </summary>
        /// <param name="dispatchOperation">操作描述</param>
        public WcfLogProvider( DispatchOperation dispatchOperation ) {
            _dispatchOperation = dispatchOperation;
            _invoker = dispatchOperation.Invoker;
        }

        /// <summary>
        /// 分发操作
        /// </summary>
        private readonly DispatchOperation _dispatchOperation;
        /// <summary>
        /// 操作
        /// </summary>
        private readonly IOperationInvoker _invoker;
        /// <summary>
        /// 日志
        /// </summary>
        private ILog _log;

        /// <summary>
        /// 分配输入
        /// </summary>
        public object[] AllocateInputs() {
            return _invoker.AllocateInputs();
        }

        /// <summary>
        /// 调用方法
        /// </summary>
        public object Invoke( object instance, object[] inputs, out object[] outputs ) {
            object result = null;
            try {
                InvokeBefore( inputs );
                result = _invoker.Invoke( instance, inputs, out outputs );
                return result;
            }
            catch ( Warning ex ) {
                ex.TraceId = _log.TraceId;
                throw;
            }
            catch ( Exception ex ) {
                var warning = new Warning( ex );
                warning.TraceId = _log.TraceId;
                warning.Level = LogLevel.Error;
                throw warning;
            }
            finally {
                InvokeAfter( result );
            }
        }

        /// <summary>
        /// 调用前
        /// </summary>
        private void InvokeBefore( IEnumerable<object> inputs ) {
            _log = Log.GetContextLog();
            _log.Method = _dispatchOperation.Name;
            AddParams( inputs );
            _log.Debug();
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        private void AddParams( IEnumerable<object> inputs ) {
            if ( inputs == null )
                return;
            foreach ( var input in inputs ) {
                _log.Params.Add( "{0},", input.ToString() );
            }
        }

        /// <summary>
        /// 调用后
        /// </summary>
        private void InvokeAfter( object result ) {
            _log.Method = _dispatchOperation.Name;
            if ( result.ToStr().IsEmpty() == false )
                _log.Params.AddLine( "结果: {0}", result.ToString() );
            _log.Debug();
        }

        /// <summary>
        /// 异步调用开始
        /// </summary>
        public IAsyncResult InvokeBegin( object instance, object[] inputs, AsyncCallback callback, object state ) {
            return _invoker.InvokeBegin( instance, inputs, callback, state );
        }

        /// <summary>
        /// 异步调用结束
        /// </summary>
        public object InvokeEnd( object instance, out object[] outputs, IAsyncResult result ) {
            return _invoker.InvokeEnd( instance, out outputs, result );
        }

        /// <summary>
        /// 是否同步
        /// </summary>
        public bool IsSynchronous {
            get { return _invoker.IsSynchronous; }
        }
    }
}
