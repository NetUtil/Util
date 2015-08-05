using Util.Webs.Ext.Controls;

namespace Util.Webs.Ext {
    /// <summary>
    /// 按钮
    /// </summary>
    /// <typeparam name="T">按钮类型</typeparam>
    public interface IButton<out T> : IComponent<T> where T : IComponent {
        /// <summary>
        /// 设置文本
        /// </summary>
        /// <param name="text">文本</param>
        T Text( string text );
        /// <summary>
        /// 设置图标class
        /// </summary>
        /// <param name="iconClass">图标class</param>
        T IconClass( string iconClass );
        /// <summary>
        /// 设置回调函数
        /// </summary>
        /// <param name="handler">回调函数</param>
        T Handler( string handler );
    }
}
