using System.ComponentModel;

namespace Util.Webs.Ext {
    /// <summary>
    /// 选项卡位置
    /// </summary>
    public enum TabPosition {
        /// <summary>
        /// 未指定
        /// </summary>
        [Description("")]
        None,
        /// <summary>
        /// 顶部
        /// </summary>
        [Description("top")]
        Top,
        /// <summary>
        /// 底部
        /// </summary>
        [Description( "bottom" )]
        Bottom
    }
}
