using Util.DI.Autofac.Tests;

namespace Util.DI.NInject.Tests.Configs {
    /// <summary>
    /// 配置2
    /// </summary>
    public class Config2 : ConfigBase{
        /// <summary>
        /// 加载NInject依赖配置
        /// </summary>
        public override void Load() {
            Bind<IOperation2>().To<Operation2>();
        }
    }
}
