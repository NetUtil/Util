using Json.Net;

namespace Util.Webs.Ext.Configs {
    /// <summary>
    /// BoxComponent配置
    /// </summary>
    internal class BoxComponentConfig : ContainerConfigBase {
        /// <summary>
        /// 区域
        /// </summary>
        [Json( Order = 200, NullValueHandling = NullValueHandling.Ignore )]
        public string region { get; set; }
        /// <summary>
        /// 加载元素Id
        /// </summary>
        [Json(Order = 201,NullValueHandling = NullValueHandling.Ignore)]
        public string el { get; set; }
    }
}
