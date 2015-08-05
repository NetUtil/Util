using System.ComponentModel;

namespace Util.Webs.Ext {
    /// <summary>
    /// 消息提示框按钮类型
    /// </summary>
    public enum MessageBoxButtonType {
        /// <summary>
        /// 仅显示取消按钮
        /// </summary>
        [Description( "Ext.Msg.buttonText.cancel" )]
        Cancel,
        /// <summary>
        /// 仅显示确定按钮
        /// </summary>
        [Description( "Ext.Msg.buttonText.ok" )]
        Ok,
        /// <summary>
        /// 显示确定和取消按钮
        /// </summary>
        [Description( "Ext.Msg.buttonText.yes" )]
        Yes,
        /// <summary>
        /// 显示是和否按钮
        /// </summary>
        [Description( "Ext.Msg.buttonText.no" )]
        No
    }
}
