using System.Web.Mvc;

namespace Util.Webs.Ext.Services.Impl {
    /// <summary>
    /// 消息框服务
    /// </summary>
    public partial class ExtService {
        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="handler">回调函数</param>
        public MvcHtmlString Alert( string title, string content, string handler = "" ) {
            var messageBox = GetMessageBox().Title( title ).Content( content ).Handler( handler );
            return new MvcHtmlString( messageBox.ToHtmlString() );
        }

        /// <summary>
        /// 确认框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="handler">回调函数</param>
        public MvcHtmlString Confirm( string title, string content, string handler ) {
            return new MvcHtmlString( string.Format( "Ext.Msg.confirm(\"{0}\",\"{1}\",{2});", title, content, handler ) );
        }

        /// <summary>
        /// 输入确认框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="handler">回调函数</param>
        /// <param name="isMultiLine">是否显示多行文本框</param>
        public MvcHtmlString Prompt( string title, string content, string handler, bool isMultiLine = false ) {
            var messageBox = GetMessageBox()
                    .Title( title )
                    .Content( content )
                    .Handler( handler )
                    .Prompt( isMultiLine )
                    .Width( 400 )
                    .Button( MessageBoxButton.OkCancel )
                    .Icon( MessageBoxIcon.Info );
            return new MvcHtmlString( messageBox.ToHtmlString() );
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        public IMessageBox Msg( string title, string content ) {
            return GetMessageBox().Title( title ).Content( content );
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="message">提示框消息</param>
        public virtual IMessageBox Msg( Message message ) {
            return GetMessageBox().Message( message );
        }

        /// <summary>
        /// 隐藏消息框
        /// </summary>
        public MvcHtmlString HideMsg() {
            return new MvcHtmlString( "Ext.Msg.hide();" );
        }
    }
}
