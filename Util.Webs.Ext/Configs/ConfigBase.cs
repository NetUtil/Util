namespace Util.Webs.Ext.Configs {
    /// <summary>
    /// 基配置
    /// </summary>
    internal abstract class ConfigBase : IConfig {
        /// <summary>
        /// 转成Json
        /// </summary>
        public string ToJson() {
            return Json.ToJson( this );
        }
    }
}
