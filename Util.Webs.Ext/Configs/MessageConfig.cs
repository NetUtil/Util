using Json.Net;

namespace Util.Webs.Ext.Configs {
    /// <summary>
    /// 提示消息配置
    /// </summary>
    internal class MessageConfig : ConfigBase {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        [Json(NullValueHandling=NullValueHandling.Ignore)]
        public int? width { get; set; }
        /// <summary>
        /// 提示框按钮类型
        /// </summary>
        [Json(false)]
        public string buttons { get; set; }
        /// <summary>
        /// 回调函数
        /// </summary>
        [Json( false, NullValueHandling = NullValueHandling.Ignore )]
        public string fn { get; set; }
        /// <summary>
        /// 动画元素Id
        /// </summary>
        [Json( NullValueHandling = NullValueHandling.Ignore )]
        public string animEl { get; set; }
        /// <summary>
        /// 是否显示右上角的关闭按钮
        /// </summary>
        public bool closable { get; set; }
        /// <summary>
        /// 是否模态窗
        /// </summary>
        public bool modal { get; set; }
        /// <summary>
        /// 显示输入框
        /// </summary>
        [Json( NullValueHandling = NullValueHandling.Ignore )]
        public bool? prompt { get; set; }
        /// <summary>
        /// 显示多行文本框
        /// </summary>
        [Json( NullValueHandling = NullValueHandling.Ignore )]
        public bool? multiline { get; set; }
        /// <summary>
        /// 消息框图标
        /// </summary>
        [Json(false)]
        public string icon { get; set; }
        /// <summary>
        /// 输入框中的值
        /// </summary>
        [Json( NullValueHandling = NullValueHandling.Ignore )]
        public string value { get; set; }
    }
}
