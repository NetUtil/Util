using Json.Net;

namespace Util.Webs.Ext.Configs {
    /// <summary>
    /// 窗口配置
    /// </summary>
    internal class WindowConfig : PanelConfig{
        /// <summary>
        /// 限制窗口在可视范围内
        /// </summary>
        [Json( Order = 300, NullValueHandling = NullValueHandling.Ignore )]
        public bool? constrain { get; set; }
        /// <summary>
        /// 允许改变窗口大小
        /// </summary>
        [Json( Order = 301, NullValueHandling = NullValueHandling.Ignore )]
        public bool? resizable { get; set; }
        /// <summary>
        /// 允许拖动
        /// </summary>
        [Json( Order = 302, NullValueHandling = NullValueHandling.Ignore )]
        public bool? draggable { get; set; }
        /// <summary>
        /// 模态窗
        /// </summary>
        [Json( Order = 303, NullValueHandling = NullValueHandling.Ignore )]
        public bool? modal { get; set; }
    }
}
