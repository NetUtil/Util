using System.ComponentModel.Composition.Registration;
using System.Reflection;
using Util.DI.Autofac.Tests;

namespace Util.DI.Mef.Tests.Configs {
    /// <summary>
    /// 配置3
    /// </summary>
    public class Config3 : ConfigBase{
        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="builder">配置生成器</param>
        protected override void Load( RegistrationBuilder builder ) {
            builder.ForType<Context>().Export<Context>();
            builder.ForType<Operation3>().Export<IOperation3>();
            builder.ForType<Operation4>().Export<IOperation4>();
        }

        /// <summary>
        /// 获取程序集
        /// </summary>
        protected override Assembly GetAssembly() {
            return typeof(IOperation3).Assembly;
        }
    }
}
