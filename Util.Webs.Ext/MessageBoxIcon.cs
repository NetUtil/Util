using System.ComponentModel;

namespace Util.Webs.Ext {
    /// <summary>
    /// 消息框图标
    /// </summary>
    public enum MessageBoxIcon {
        /// <summary>
        /// 信息
        /// </summary>
        [Description( "Ext.MessageBox.INFO" )]
        Info,
        /// <summary>
        /// 问题
        /// </summary>
        [Description( "Ext.MessageBox.QUESTION" )]
        Question,
        /// <summary>
        /// 警告
        /// </summary>
        [Description( "Ext.MessageBox.WARNING" )]
        Warning,
        /// <summary>
        /// 错误
        /// </summary>
        [Description( "Ext.MessageBox.ERROR" )]
        Error,
    }
}
