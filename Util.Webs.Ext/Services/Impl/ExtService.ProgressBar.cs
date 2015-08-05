using System.Web.Mvc;

namespace Util.Webs.Ext.Services.Impl {
    /// <summary>
    /// 进度条服务
    /// </summary>
    public partial class ExtService {
        /// <summary>
        /// 进度条
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="iconClass">图标class</param>
        /// <param name="progressText">进度条文本</param>
        public MvcHtmlString ProgressBar( string content = "", string iconClass = "", string progressText = "" ) {
            var progressBar = GetProgressBar().Content( content ).IconClass( iconClass ).ProgressText( progressText );
            return new MvcHtmlString( progressBar.ToHtmlString() );
        }

        /// <summary>
        /// 隐藏进度条
        /// </summary>
        public MvcHtmlString HideProgressBar() {
            return new MvcHtmlString( "Ext.Msg.hide();" );
        }
    }
}
