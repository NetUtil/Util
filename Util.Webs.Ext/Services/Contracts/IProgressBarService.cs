using System.Web.Mvc;

namespace Util.Webs.Ext.Services.Contracts {
    /// <summary>
    /// 进度条服务
    /// </summary>
    public interface IProgressBarService {
        /// <summary>
        /// 进度条
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="iconClass">图标class</param>
        /// <param name="progressText">进度条文本</param>
        MvcHtmlString ProgressBar( string content = "",string iconClass = "",string progressText = "" );
        /// <summary>
        /// 隐藏进度条
        /// </summary>
        MvcHtmlString HideProgressBar();
    }
}
