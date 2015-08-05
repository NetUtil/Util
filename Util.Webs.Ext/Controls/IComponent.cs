using System.Web;

namespace Util.Webs.Ext.Controls {
    /// <summary>
    /// 组件
    /// </summary>
    public interface IComponent : IHtmlString {
        /// <summary>
        /// 获取标识
        /// </summary>
        string GetId();
        /// <summary>
        /// 获取组件变量名
        /// </summary>
        string GetVarName();
    }
}
