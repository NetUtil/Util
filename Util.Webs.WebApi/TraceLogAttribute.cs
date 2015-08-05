using System;
using System.Collections.Generic;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Util.Logs;

namespace Util.Webs.WebApi {
    /// <summary>
    /// 记录跟踪日志
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false )]
    public class TraceLogAttribute : ActionFilterAttribute {
        /// <summary>
        /// 是否忽略,为true不记录日志
        /// </summary>
        public bool Ignore { get; set; }

        /// <summary>
        /// 日志
        /// </summary>
        private ILog Log { get; set; }

        /// <summary>
        /// 执行前
        /// </summary>
        public override void OnActionExecuting( HttpActionContext context ) {
            base.OnActionExecuting( context );
            if ( Ignore )
                return;
            WriteLog( context );
        }

        /// <summary>
        /// 执行前日志
        /// </summary>
        private void WriteLog( HttpActionContext context ) {
            Log = Logs.Log4.Log.GetContextLog( context.ControllerContext );
            Log.Method = context.ActionDescriptor.ActionName;
            AddParams( context.ActionArguments );
            Log.Debug();
        }

        /// <summary>
        /// 添加参数列表
        /// </summary>
        private void AddParams( IEnumerable<KeyValuePair<string, object>> paramList ) {
            foreach ( var parameter in paramList ) {
                if ( IsSecret( parameter.Key ) )
                    continue;
                AddParams( parameter );
            }
        }

        /// <summary>
        /// 是否机密
        /// </summary>
        private bool IsSecret( string name ) {
            return name.ToLower().Contains( "password" );
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        private void AddParams( KeyValuePair<string, object> parameter ) {
            Log.Params.Add( "{0}:{1},", parameter.Key, parameter.Value );
        }

        /// <summary>
        /// 执行后
        /// </summary>
        public override void OnActionExecuted( HttpActionExecutedContext context ) {
            base.OnActionExecuted( context );
            if ( Ignore )
                return;
            WriteLog( context );
        }

        /// <summary>
        /// 执行后日志
        /// </summary>
        private void WriteLog( HttpActionExecutedContext context ) {
            Log.Method = context.ActionContext.ActionDescriptor.ActionName;
            Log.Debug();
        }
    }
}
