using System.ComponentModel;

namespace Util.Webs.Ext {
    /// <summary>
    /// 区域
    /// </summary>
    public enum Region {
        /// <summary>
        /// 未指定
        /// </summary>
        [Description("")]
        None,
        /// <summary>
        /// 顶部
        /// </summary>
        [Description( "north" )]
        Top,
        /// <summary>
        /// 底部
        /// </summary>
        [Description( "south" )]
        Bottom,
        /// <summary>
        /// 左侧
        /// </summary>
        [Description( "west" )]
        Left,
        /// <summary>
        /// 右侧
        /// </summary>
        [Description( "east" )]
        Right,
        /// <summary>
        /// 中心区域
        /// </summary>
        [Description( "center" )]
        Center
    }
}
