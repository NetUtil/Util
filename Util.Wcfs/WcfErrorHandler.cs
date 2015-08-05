using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Util.Logs;
using Util.Logs.Log4;

namespace Util.Wcfs {
    /// <summary>
    /// Wcf错误处理
    /// </summary>
    internal class WcfErrorHandler : IErrorHandler {
        /// <summary>
        /// 处理错误
        /// </summary>
        public bool HandleError( Exception error ) {
            return true;
        }

        /// <summary>
        /// 提供错误消息
        /// </summary>
        public void ProvideFault( Exception error, MessageVersion version, ref Message fault ) {
            try {
                WriteLog( error );
                CreateFaultMessage( error, version, ref fault );
            }
            catch ( Exception ex ) {
                CreateFaultMessage( ex, version, ref fault );
            }
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        private void WriteLog( Exception ex ) {
            var log = Log.GetContextLog();
            log.Caption.Add( "Wcf全局异常捕获" );
            log.Exception = ex;
            Warning.WriteLog( log, ex );
        }

        /// <summary>
        /// 创建错误消息
        /// </summary>
        private void CreateFaultMessage( Exception ex, MessageVersion version, ref Message fault ) {
            var exception = new FaultException( GetMessage( ex ) );
            MessageFault message = exception.CreateMessageFault();
            fault = Message.CreateMessage( version, message, exception.Action );
        }

        /// <summary>
        /// 获取错误消息
        /// </summary>
        private string GetMessage( Exception ex ) {
            var warning = ex as Warning;
            if ( warning == null )
                return R.SystemError;
            if ( warning.Level == LogLevel.Information || warning.Level == LogLevel.Warning )
                return warning.Message;
            return R.SystemError;
        }
    }
}
