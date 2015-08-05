using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Registration;
using System.Reflection;

namespace Util.DI.Mef {
    /// <summary>
    /// Mef基配置
    /// </summary>
    public abstract class ConfigBase {
        /// <summary>
        /// 初始化Mef基配置
        /// </summary>
        protected ConfigBase() {
            Builder = new RegistrationBuilder();
            Load( Builder );
        }

        /// <summary>
        /// 配置生成器
        /// </summary>
        private RegistrationBuilder Builder { get; set; }

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="builder">配置生成器</param>
        protected abstract void Load( RegistrationBuilder builder );

        /// <summary>
        /// 获取程序集目录
        /// </summary>
        internal AssemblyCatalog GetCatalog() {
            return new AssemblyCatalog( GetAssembly(), Builder );
        }

        /// <summary>
        /// 获取类型所在的程序集，注意:不是依赖配置所在的程序集
        /// </summary>
        protected abstract Assembly GetAssembly();
    }
}
