namespace Util.Webs.Ext {
    /// <summary>
    /// 消息
    /// </summary>
    public class Message {
        /// <summary>
        /// 初始化消息
        /// </summary>
        public Message() {
            ShowClose = true;
            Modal = true;
        }

        /// <summary>
        /// 消息框标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否显示右上角的关闭按钮
        /// </summary>
        public bool ShowClose { get; set; }
        /// <summary>
        /// 是否以模态窗口显示
        /// </summary>
        public bool Modal { get; set; }
        /// <summary>
        /// 设置宽度,单位：像素
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// 提示框按钮
        /// </summary>
        public MessageBoxButton Button { get; set; }
        /// <summary>
        /// 提示框图标
        /// </summary>
        public MessageBoxIcon Icon { get; set; }
        /// <summary>
        /// 设置回调函数
        /// </summary>
        public string Handler { get; set; }
        /// <summary>
        /// 设置动画起始和结束的控件Id
        /// </summary>
        public string AnimeElementId { get; set; }
        /// <summary>
        /// 是否显示输入框
        /// </summary>
        public bool? Prompt { get; set; }
        /// <summary>
        /// 输入框是否显示多行文本框
        /// </summary>
        public bool? MultiLine { get; set; }
        /// <summary>
        /// 设置输入框中的值
        /// </summary>
        public string Value { get; set; }
    }
}
