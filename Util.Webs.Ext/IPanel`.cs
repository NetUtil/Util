using Util.Webs.Ext.Controls;

namespace Util.Webs.Ext {
    /// <summary>
    /// 面板
    /// </summary>
    public interface IPanel<out T> : IContainer<T> where T : IComponent<T> {
        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title">标题</param>
        T Title( string title );
        /// <summary>
        /// 设置Html
        /// </summary>
        /// <param name="html">Html</param>
        T Html( string html );
        /// <summary>
        /// 设置区域
        /// </summary>
        /// <param name="region">区域</param>
        T Region( Region region );
        /// <summary>
        /// 设置最小尺寸
        /// </summary>
        /// <param name="minSize">最小尺寸</param>
        T MinSize( int? minSize );
        /// <summary>
        /// 设置最大尺寸
        /// </summary>
        /// <param name="maxSize">最大尺寸</param>
        T MaxSize( int? maxSize );
        /// <summary>
        /// 设置选项卡提示
        /// </summary>
        /// <param name="tip">选项卡提示</param>
        T TabTip( string tip );
        /// <summary>
        /// 设置图标class
        /// </summary>
        /// <param name="iconClass">图标class</param>
        T IconClass( string iconClass );
        /// <summary>
        /// 允许折叠
        /// </summary>
        T Collapsible();
        /// <summary>
        /// 允许拖动改动面板大小
        /// </summary>
        T Split();
        /// <summary>
        /// 加载内容
        /// </summary>
        /// <param name="elementId">元素Id</param>
        T LoadContent( string elementId );
        /// <summary>
        /// 允许关闭
        /// </summary>
        /// <param name="closable">是否允许关闭</param>
        T Closable( bool closable = true );
        /// <summary>
        /// 自动显示滚动条
        /// </summary>
        T AutoScroll();
        /// <summary>
        /// 显示圆角边框
        /// </summary>
        /// <param name="isShow">是否显示圆角边框</param>
        T Frame( bool isShow = true );
        /// <summary>
        /// 添加顶部工具栏
        /// </summary>
        /// <param name="toolbar">工具栏</param>
        T TopBar( IToolbar toolbar );
        /// <summary>
        /// 添加底部工具栏
        /// </summary>
        /// <param name="toolbar">工具栏</param>
        T BottomBar( IToolbar toolbar );
        /// <summary>
        /// 迷你折叠模式
        /// </summary>
        T Mini();
        /// <summary>
        /// 显示边框
        /// </summary>
        /// <param name="showBorder">是否显示边框</param>
        T Border( bool showBorder = true );
    }
}
