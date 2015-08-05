using System.Web.Mvc;
using Util.Webs.Ext.Services.Impl;

namespace Util.Webs.Ext {
    /// <summary>
    /// HtmlHelper扩展 - Ext扩展
    /// </summary>
    public static class HtmlHelperExtentions {
        /// <summary>
        /// 创建Ext服务
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        public static IExtService Ext( this HtmlHelper helper ) {
            return new ExtService();
        }
    }
}
