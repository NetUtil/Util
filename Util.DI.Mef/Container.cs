using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace Util.DI.Mef {
    /// <summary>
    /// Mef对象容器
    /// </summary>
    public class Container {
        /// <summary>
        /// 初始化Mef对象容器
        /// </summary>
        /// <param name="configs">依赖配置</param>
        public Container( params ConfigBase[] configs ) {
            _container = new CompositionContainer( new AggregateCatalog( configs.Select( t => t.GetCatalog() ) ) );
        }

        /// <summary>
        /// 容器
        /// </summary>
        private readonly CompositionContainer _container;

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        public T Create<T>() {
            return _container.GetExportedValue<T>();
        }
    }
}
