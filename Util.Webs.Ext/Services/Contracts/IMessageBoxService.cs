using System.Web.Mvc;

namespace Util.Webs.Ext.Services.Contracts {
    /// <summary>
    /// 消息框服务
    /// </summary>
    public interface IMessageBoxService {
        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="callback">回调函数,注意：不要带(),范例：func</param>
        MvcHtmlString Alert( string title, string content, string callback = "" );
        /// <summary>
        /// 确认框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="callback">回调函数,注意：不要带(),范例：func</param>
        MvcHtmlString Confirm( string title, string content, string callback );
        /// <summary>
        /// 输入确认框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="callback">回调函数,注意：不要带(),范例：func</param>
        /// <param name="isMultiLine">是否显示多行文本框</param>
        MvcHtmlString Prompt( string title, string content, string callback, bool isMultiLine = false );
        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        IMessageBox Msg( string title, string content );
        /// <summary>
        /// 消息框
        /// </summary>
        /// <param name="message">提示框消息</param>
        IMessageBox Msg( Message message );
        /// <summary>
        /// 隐藏消息框
        /// </summary>
        MvcHtmlString HideMsg();
    }
}
