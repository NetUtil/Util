using Json.Net;

namespace Util.Webs.Ext.Configs {
    /// <summary>
    /// 面板
    /// </summary>
    internal class PanelConfig : ContainerConfigBase {
        /// <summary>
        /// 标题
        /// </summary>
        [Json(Order = 200,NullValueHandling = NullValueHandling.Ignore)]
        public string title { get; set; }
        /// <summary>
        /// Html
        /// </summary>
        [Json( Order = 201, NullValueHandling = NullValueHandling.Ignore )]
        public string html { get; set; }
        /// <summary>
        /// 是否可折叠
        /// </summary>
        [Json( Order = 202, NullValueHandling = NullValueHandling.Ignore )]
        public bool? collapsible { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        [Json( Order = 203, NullValueHandling = NullValueHandling.Ignore )]
        public string region { get; set; }
        /// <summary>
        /// Html元素Id
        /// </summary>
        [Json( Order = 204, NullValueHandling = NullValueHandling.Ignore )]
        public string contentEl { get; set; }
        /// <summary>
        /// 是否可拖动
        /// </summary>
        [Json( Order = 205, NullValueHandling = NullValueHandling.Ignore )]
        public bool? split { get; set; }
        /// <summary>
        /// 最小尺寸
        /// </summary>
        [Json( Order = 206, NullValueHandling = NullValueHandling.Ignore )]
        public int? minSize { get; set; }
        /// <summary>
        /// 最大尺寸
        /// </summary>
        [Json( Order = 207, NullValueHandling = NullValueHandling.Ignore )]
        public int? maxSize { get; set; }
        /// <summary>
        /// 选项卡提示
        /// </summary>
        [Json( Order = 208, NullValueHandling = NullValueHandling.Ignore )]
        public string tabTip { get; set; }
        /// <summary>
        /// 允许关闭选项卡
        /// </summary>
        [Json( Order = 209, NullValueHandling = NullValueHandling.Ignore )]
        public bool? closable { get; set; }
        /// <summary>
        /// 自动显示滚动条
        /// </summary>
        [Json( Order = 210, NullValueHandling = NullValueHandling.Ignore )]
        public bool? autoScroll { get; set; }
        /// <summary>
        /// 图标class
        /// </summary>
        [Json( Order = 211, NullValueHandling = NullValueHandling.Ignore )]
        public string iconCls { get; set; }
        /// <summary>
        /// 显示圆角边框
        /// </summary>
        [Json( Order = 212, NullValueHandling = NullValueHandling.Ignore )]
        public bool? frame { get; set; }
        /// <summary>
        /// 顶部工具栏
        /// </summary>
        [Json( false, Order = 213, NullValueHandling = NullValueHandling.Ignore )]
        public string tbar { get; set; }
        /// <summary>
        /// 底部工具栏
        /// </summary>
        [Json( false, Order = 214, NullValueHandling = NullValueHandling.Ignore )]
        public string bbar { get; set; }
        /// <summary>
        /// 迷你折叠模式
        /// </summary>
        [Json( Order = 215, NullValueHandling = NullValueHandling.Ignore )]
        public string collapseMode { get; set; }
        /// <summary>
        /// 是否显示边框
        /// </summary>
        [Json( Order = 216, NullValueHandling = NullValueHandling.Ignore )]
        public bool? border { get; set; }
    }
}
