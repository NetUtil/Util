using Autofac;

namespace Util.ApplicationServices.Tests.Samples {
    /// <summary>
    /// Ioc配置
    /// </summary>
    public class IocConfig : DI.Autofac.ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load( ContainerBuilder builder ) {
            builder.RegisterType<TestService2>().As<ITestService>();
        }
    }
}
