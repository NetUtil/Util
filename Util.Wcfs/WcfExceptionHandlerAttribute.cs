using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Util.Wcfs {
    /// <summary>
    /// Wcf全局异常处理
    /// </summary>
    [AttributeUsage( AttributeTargets.Class, Inherited = true, AllowMultiple = false )]
    public class WcfExceptionHandlerAttribute : Attribute, IServiceBehavior {
        /// <summary>
        /// 验证
        /// </summary>
        public void Validate( ServiceDescription serviceDescription, ServiceHostBase serviceHostBase ) {
        }

        /// <summary>
        /// 添加绑定参数
        /// </summary>
        public void AddBindingParameters( ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters ) {
        }

        /// <summary>
        /// 拦截
        /// </summary>
        public void ApplyDispatchBehavior( ServiceDescription serviceDescription, ServiceHostBase serviceHost ) {
            foreach ( var channelDispatcher in serviceHost.ChannelDispatchers ) {
                var dispatcher = channelDispatcher as ChannelDispatcher;
                if ( dispatcher == null )
                    continue;
                dispatcher.ErrorHandlers.Add( new WcfErrorHandler() );
            }
        }
    }
}
