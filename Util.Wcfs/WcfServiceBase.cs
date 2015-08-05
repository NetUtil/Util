using System;
using Util.Domains;
using Util.Logs;
using Util.Security;

namespace Util.Wcfs {
    /// <summary>
    /// Wcf服务
    /// </summary>
    [WcfExceptionHandler]
    public abstract class WcfServiceBase {
        /// <summary>
        /// 初始化Wcf基服务
        /// </summary>
        protected WcfServiceBase() {
            Log = Logs.Log4.Log.GetContextLog( this );
        }

        /// <summary>
        /// 日志操作
        /// </summary>
        protected ILog Log { get; set; }
    }
}
