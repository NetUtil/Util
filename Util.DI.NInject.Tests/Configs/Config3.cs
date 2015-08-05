using Util.DI.Autofac.Tests;

namespace Util.DI.NInject.Tests.Configs {
    /// <summary>
    /// 配置3
    /// </summary>
    public class Config3 : ConfigBase{
        /// <summary>
        /// 加载NInject依赖配置
        /// </summary>
        public override void Load() {
            Bind<Context>().To<Context>().InThreadScope();
            Bind<IOperation3>().To<Operation3>();
            Bind<IOperation4>().To<Operation4>();
        }
    }
}
