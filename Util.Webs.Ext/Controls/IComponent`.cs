namespace Util.Webs.Ext.Controls {
    /// <summary>
    /// 组件
    /// </summary>
    public interface IComponent<out T> : IComponent where T : IComponent {
        /// <summary>
        /// 设置组件变量名
        /// </summary>
        /// <param name="varName">组件变量名</param>
        T Var( string varName );
        /// <summary>
        /// 设置标识
        /// </summary>
        /// <param name="id">标识</param>
        T Id( string id );
        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度</param>
        T Width( int? width );
        /// <summary>
        /// 设置高度
        /// </summary>
        /// <param name="height">高度</param>
        T Height( int? height );
        /// <summary>
        /// 渲染到目标
        /// </summary>
        /// <param name="id">渲染目标标识</param>
        T RenderTo( string id );
        /// <summary>
        /// 禁用
        /// </summary>
        T Disable();
        /// <summary>
        /// 显示
        /// </summary>
        T Show();
        /// <summary>
        /// 隐藏
        /// </summary>
        T Hide();
        /// <summary>
        /// 以xtype方式渲染
        /// </summary>
        T RenderWithXType();
        /// <summary>
        /// 设置锚点布局
        /// </summary>
        /// <param name="width">宽度，可以是百分比或偏移量，范例1："50%",范例2: "-50"</param>
        /// <param name="height">高度，可以是百分比或偏移量，范例1："50%",范例2: "-50"</param>
        T Anchor( string width, string height = "" );
        /// <summary>
        /// 以百分比方式设置锚点布局
        /// </summary>
        /// <param name="width">表示当前组件占父容器的百分比宽度，范例：50，表示50%</param>
        /// <param name="height">表示当前组件占父容器的百分比高度，范例：50，表示50%</param>
        T AnchorByPercent( int width, int? height = null );
        /// <summary>
        /// 以偏移量方式设置锚点布局
        /// </summary>
        /// <param name="width">表示当前组件相对父容器的宽度偏移量，范例:-50,表示父容器宽度-50</param>
        /// <param name="height">表示当前组件相对父容器的高度偏移量，范例:-50,表示父容器高度-50</param>
        T AnchorByOffset( int width,int? height = null );
        /// <summary>
        /// 设置外边距
        /// </summary>
        /// <param name="top">上边距</param>
        /// <param name="right">右边距</param>
        /// <param name="bottom">下边距</param>
        /// <param name="left">左边距</param>
        T Margin( int top, int right = 0, int bottom = 0, int left = 0 );
        /// <summary>
        /// 设置表单标签文本
        /// </summary>
        /// <param name="text">表单标签文本</param>
        /// <param name="separator">表单标签分隔符</param>
        T Label( string text,string separator = "" );
        /// <summary>
        /// 设置绝对布局
        /// </summary>
        /// <param name="left">左边距</param>
        /// <param name="top">上边距</param>
        T Absolute( int? left,int? top );
        /// <summary>
        /// 是否以xtype方式渲染
        /// </summary>
        bool IsRenderWithXType { get; }
    }
}
