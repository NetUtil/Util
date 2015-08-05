using System.ComponentModel.Composition.Registration;
using System.Reflection;
using Util.DI.Autofac.Tests;

namespace Util.DI.Mef.Tests.Configs {
    /// <summary>
    /// 配置1
    /// </summary>
    public class Config1 : ConfigBase{
        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="builder">配置生成器</param>
        protected override void Load( RegistrationBuilder builder ) {
            builder.ForType<Operation>().Export<IOperation>();
        }

        /// <summary>
        /// 获取程序集
        /// </summary>
        protected override Assembly GetAssembly() {
            return typeof(IOperation).Assembly;
        }
    }
}
