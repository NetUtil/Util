using Util.DI.Autofac.Tests;

namespace Util.DI.NInject.Tests.Configs {
    /// <summary>
    /// 配置4
    /// </summary>
    public class Config4 : ConfigBase{
        /// <summary>
        /// 加载NInject依赖配置
        /// </summary>
        public override void Load() {
            Bind<IService>().To<Service>();
        }
    }
}
