namespace Util.Webs.Ext {
    /// <summary>
    /// 窗口
    /// </summary>
    public interface IWindow : IPanel<IWindow> {
        /// <summary>
        /// 限制窗口在可视范围内
        /// </summary>
        IWindow Constrain();
        /// <summary>
        /// 允许改变窗口大小
        /// </summary>
        /// <param name="resizable">是否允许改变窗口大小</param>
        IWindow Resizable( bool resizable = true );
        /// <summary>
        /// 允许拖动
        /// </summary>
        /// <param name="draggable">是否允许拖动</param>
        IWindow Draggable( bool draggable = true );
        /// <summary>
        /// 模态窗
        /// </summary>
        IWindow Modal();
    }
}
