namespace Util.Webs.Ext.Controls {
    /// <summary>
    /// 容器
    /// </summary>
    public interface IContainer<out T> : IComponent<T> where T : IComponent {
        /// <summary>
        /// 设置布局方式
        /// </summary>
        /// <param name="layout">布局方式</param>
        T Layout( Layout layout );
        /// <summary>
        /// 添加子组件
        /// </summary>
        /// <param name="childs">子组件</param>
        T Add( params IComponent[] childs );
        /// <summary>
        /// 设置表单标签宽度
        /// </summary>
        /// <param name="width">表单标签宽度</param>
        T LabelWidth( int width );
    }
}
