using Util.DI.Autofac.Tests;

namespace Util.DI.NInject.Tests.Configs {
    /// <summary>
    /// 配置1
    /// </summary>
    public class Config1 : ConfigBase{
        /// <summary>
        /// 加载NInject依赖配置
        /// </summary>
        public override void Load() {
            Bind<IOperation>().To<Operation>();
        }
    }
}
