using Ninject;
using Ninject.Modules;

namespace Util.DI.NInject {
    /// <summary>
    /// NInject对象容器
    /// </summary>
    public class Container {
        /// <summary>
        /// NInject核心操作类
        /// </summary>
        protected IKernel Kernel { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="modules">Ioc配置模块</param>
        public Container( params INinjectModule[] modules ) {
            Kernel = new StandardKernel( modules );
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        public T Create<T>() {
            return Create<T>( string.Empty );
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象名称</param>
        public T Create<T>( string name ) {
            return string.IsNullOrWhiteSpace( name ) ? Kernel.Get<T>() : Kernel.Get<T>( name );
        }
    }
}
