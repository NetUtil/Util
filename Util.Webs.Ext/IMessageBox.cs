using System.Web;

namespace Util.Webs.Ext {
    /// <summary>
    /// 消息框
    /// </summary>
    public interface IMessageBox : IHtmlString {
        /// <summary>
        /// 设置消息
        /// </summary>
        /// <param name="message">消息</param>
        IMessageBox Message( Message message );
        /// <summary>
        /// 设置消息框标识
        /// </summary>
        /// <param name="id">消息框标识</param>
        IMessageBox Id( string id );
        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title">标题</param>
        IMessageBox Title( string title );
        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="content">内容</param>
        IMessageBox Content( string content );
        /// <summary>
        /// 是否显示右上角的关闭按钮
        /// </summary>
        /// <param name="showClose">false表示不显示关闭按钮</param>
        IMessageBox ShowClose( bool showClose = true );
        /// <summary>
        /// 是否以模态窗口显示
        /// </summary>
        /// <param name="showModal">true表示按模态窗显示</param>
        IMessageBox Modal( bool showModal = true );
        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度，单位：像素</param>
        IMessageBox Width( int width );
        /// <summary>
        /// 设置提示框按钮
        /// </summary>
        /// <param name="button">提示框按钮类型</param>
        IMessageBox Button( MessageBoxButton button );
        /// <summary>
        /// 设置提示框图标
        /// </summary>
        /// <param name="icon">提示框图标类型</param>
        IMessageBox Icon( MessageBoxIcon icon );
        /// <summary>
        /// 设置回调函数
        /// </summary>
        /// <param name="handler">回调函数,注意：不要带(),范例：func</param>
        IMessageBox Handler( string handler );
        /// <summary>
        /// 设置动画效果
        /// </summary>
        /// <param name="elementId">动画起始和结束的控件Id</param>
        IMessageBox Anime( string elementId );
        /// <summary>
        /// 是否显示输入框
        /// </summary>
        /// <param name="showMultiLine">true显示多行文本框</param>
        IMessageBox Prompt( bool showMultiLine = false );
        /// <summary>
        /// 设置输入框中的值
        /// </summary>
        /// <param name="value">输入框中的默认值</param>
        IMessageBox Value( string value );
        /// <summary>
        /// 设置提示框按钮上的文字
        /// </summary>
        /// <param name="buttonType">提示框按钮类型</param>
        /// <param name="buttonText">显示的文字</param>
        IMessageBox ButtonText( MessageBoxButtonType buttonType, string buttonText );
    }
}
