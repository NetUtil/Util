using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Util.Wcfs {
    /// <summary>
    /// Wcf日志跟踪
    /// </summary>
    [AttributeUsage( AttributeTargets.Method, Inherited = false, AllowMultiple = false )]
    public sealed class WcfLogAttribute : Attribute, IOperationBehavior {
        /// <summary>
        /// 验证
        /// </summary>
        public void Validate( OperationDescription operationDescription ) {
        }

        /// <summary>
        /// 拦截方法
        /// </summary>
        public void ApplyDispatchBehavior( OperationDescription operationDescription, DispatchOperation dispatchOperation ) {
            dispatchOperation.Invoker = new WcfLogProvider( dispatchOperation );
        }

        /// <summary>
        /// 应用客户端行动
        /// </summary>
        public void ApplyClientBehavior( OperationDescription operationDescription, ClientOperation clientOperation ) {
        }

        /// <summary>
        /// 添加绑定参数
        /// </summary>
        public void AddBindingParameters( OperationDescription operationDescription, BindingParameterCollection bindingParameters ) {
        }
    }
}
