using Json.Net;

namespace Util.Webs.Ext.Configs {
    /// <summary>
    /// 文本框配置
    /// </summary>
    internal class TextBoxConfig : ComponentConfigBase{
        /// <summary>
        /// 设置为必填项
        /// </summary>
        [Json( Order = 101, NullValueHandling = NullValueHandling.Ignore )]
        public bool? allowBlank { get; set; }
        /// <summary>
        /// 必填项错误消息
        /// </summary>
        [Json( Order = 102, NullValueHandling = NullValueHandling.Ignore )]
        public string blankText { get; set; }
    }
}
