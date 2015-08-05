using Json.Net;

namespace Util.Webs.Ext.Configs {
    /// <summary>
    /// 按钮配置
    /// </summary>
    internal class ButtonConfig : ComponentConfigBase{
        /// <summary>
        /// 文本
        /// </summary>
        [Json( Order = 200, NullValueHandling = NullValueHandling.Ignore )]
        public string text { get; set; }
        /// <summary>
        /// 图标class
        /// </summary>
        [Json( Order = 201, NullValueHandling = NullValueHandling.Ignore )]
        public string iconCls { get; set; }
        /// <summary>
        /// 回调函数
        /// </summary>
        [Json( false, Order = 202, NullValueHandling = NullValueHandling.Ignore )]
        public string handler { get; set; }
    }
}
