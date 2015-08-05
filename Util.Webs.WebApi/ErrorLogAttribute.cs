using System;
using System.Web.Http.Filters;
using Util.Logs.Log4;

namespace Util.Webs.WebApi {
    /// <summary>
    /// 记录异常日志
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true )]
    public class ErrorLogAttribute : ExceptionFilterAttribute {
        /// <summary>
        /// 处理异常
        /// </summary>
        public override void OnException( HttpActionExecutedContext context ) {
            base.OnException( context );
            WriteLog( context );
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        private void WriteLog( HttpActionExecutedContext context ) {
            if ( context == null )
                return;
            var log = Log.GetContextLog( context.ActionContext );
            log.Caption.Add( "WebApi全局异常捕获" );
            log.Exception = context.Exception;
            Warning.WriteLog( log,context.Exception );
        }
    }
}
