using System.ComponentModel.Composition.Registration;
using System.Reflection;
using Util.DI.Autofac.Tests;

namespace Util.DI.Mef.Tests.Configs {
    /// <summary>
    /// 配置4
    /// </summary>
    public class Config4 : ConfigBase{
        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="builder">配置生成器</param>
        protected override void Load( RegistrationBuilder builder ) {
            builder.ForType<Service>().Export<IService>();
        }

        /// <summary>
        /// 获取程序集
        /// </summary>
        protected override Assembly GetAssembly() {
            return typeof( Service ).Assembly;
        }
    }
}
