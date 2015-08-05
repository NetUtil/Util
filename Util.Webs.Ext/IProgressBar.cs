using System.Web;

namespace Util.Webs.Ext {
    /// <summary>
    /// 进度条
    /// </summary>
    public interface IProgressBar : IHtmlString {
        /// <summary>
        /// 设置进度条文本
        /// </summary>
        /// <param name="text">进度条文本</param>
        IProgressBar ProgressText( string text );
        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="content">内容</param>
        IProgressBar Content( string content );
        /// <summary>
        /// 设置图标class
        /// </summary>
        /// <param name="iconClass">图标class</param>
        IProgressBar IconClass( string iconClass );
    }
}
