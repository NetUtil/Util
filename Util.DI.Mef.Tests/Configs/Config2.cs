using System.ComponentModel.Composition.Registration;
using System.Reflection;
using Util.DI.Autofac.Tests;

namespace Util.DI.Mef.Tests.Configs {
    /// <summary>
    /// 配置2
    /// </summary>
    public class Config2 : ConfigBase{
        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="builder">配置生成器</param>
        protected override void Load( RegistrationBuilder builder ) {
            builder.ForType<Operation2>().Export<IOperation2>();
        }

        /// <summary>
        /// 获取程序集
        /// </summary>
        protected override Assembly GetAssembly() {
            return typeof(IOperation2).Assembly;
        }
    }
}
