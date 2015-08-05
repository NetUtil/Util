using Util.DI.Mef.Tests.Configs;

namespace Util.DI.Mef.Tests {
    /// <summary>
    /// Mef依赖注入
    /// </summary>
    public static class Ioc {
        /// <summary>
        /// 初始化容器
        /// </summary>
        static Ioc() {
            Container = new Container( new Config1(), new Config2(), new Config3(), new Config4() );
        }

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
