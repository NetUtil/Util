using System.ComponentModel;

namespace Util.Webs.Ext {
    /// <summary>
    /// 消息框按钮
    /// </summary>
    public enum MessageBoxButton {
        /// <summary>
        /// 仅显示确定按钮
        /// </summary>
        [Description( "Ext.MessageBox.OK" )]
        Ok,
        /// <summary>
        /// 仅显示取消按钮
        /// </summary>
        [Description( "Ext.MessageBox.CANCEL" )]
        Cancel,
        /// <summary>
        /// 显示确定和取消按钮
        /// </summary>
        [Description( "Ext.MessageBox.OKCANCEL" )]
        OkCancel,
        /// <summary>
        /// 显示是和否按钮
        /// </summary>
        [Description( "Ext.MessageBox.YESNO" )]
        YesNo,
        /// <summary>
        /// 显示是、否、取消三个按钮
        /// </summary>
        [Description( "Ext.MessageBox.YESNOCANCEL" )]
        YesNoCancel,
    }
}
