using Util.DI.Autofac;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 依赖注入
    /// </summary>
    public static class Ioc {
        /// <summary>
        /// 初始化容器
        /// </summary>
        static Ioc() {
            lock ( Sync ) {
                if ( Container != null )
                    return;
                Container = new Container( new IocConfig() );
            }
        }

        /// <summary>
        /// 同步锁
        /// </summary>
        private static readonly object Sync = new object();

        /// <summary>
        /// 对象容器
        /// </summary>
        private static readonly Container Container;

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        public static T Create<T>() {
            return Container.Create<T>();
        }
    }
}
