using Util.Webs.Ext.Controls;

namespace Util.Webs.Ext {
    /// <summary>
    /// 文本框
    /// </summary>
    /// <typeparam name="T">文本框类型</typeparam>
    public interface ITextBox<out T> : IComponent<T> where T : IComponent{
        /// <summary>
        /// 设置为必填项
        /// </summary>
        /// <param name="error">错误消息</param>
        T Required( string error = "" );
    }
}
