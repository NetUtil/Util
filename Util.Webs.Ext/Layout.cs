using System.ComponentModel;

namespace Util.Webs.Ext {
    /// <summary>
    /// Ext布局
    /// </summary>
    public enum Layout {
        /// <summary>
        /// 未指定
        /// </summary>
        [Description( "" )]
        None,
        /// <summary>
        /// 边框布局
        /// </summary>
        [Description( "border" )]
        Border,
        /// <summary>
        /// 自适应布局
        /// </summary>
        [Description("fit")]
        Fit,
        /// <summary>
        /// 锚点布局
        /// </summary>
        [Description( "anchor" )]
        Anchor,
        /// <summary>
        /// 表单布局
        /// </summary>
        [Description( "form" )]
        Form,
        /// <summary>
        /// 绝对布局
        /// </summary>
        [Description( "absolute" )]
        Absolute,
        /// <summary>
        /// 折叠布局
        /// </summary>
        [Description( "accordion" )]
        Accordion
    }
}
