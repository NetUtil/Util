using Json.Net;

namespace Util.Webs.Ext.Configs {
    /// <summary>
    /// 选项卡面板配置
    /// </summary>
    internal class TabPanelConfig : ContainerConfigBase{
        /// <summary>
        /// 激活选项卡索引
        /// </summary>
        [Json( Order = 200, NullValueHandling = NullValueHandling.Ignore )]
        public int? activeTab { get; set; }
        /// <summary>
        /// 启用选项卡滚动
        /// </summary>
        [Json( Order = 201, NullValueHandling = NullValueHandling.Ignore )]
        public bool? enableTabScroll { get; set; }
        /// <summary>
        /// 启用重置选项卡大小
        /// </summary>
        [Json( Order = 202, NullValueHandling = NullValueHandling.Ignore )]
        public bool? resizeTabs { get; set; }
        /// <summary>
        /// 选项卡最小宽度
        /// </summary>
        [Json( Order = 203, NullValueHandling = NullValueHandling.Ignore )]
        public int? minTabWidth { get; set; }
        /// <summary>
        /// 选项卡位置
        /// </summary>
        [Json( Order = 204, NullValueHandling = NullValueHandling.Ignore )]
        public string tabPosition { get; set; }
    }
}
