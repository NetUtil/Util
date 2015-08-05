using Util.Webs.Ext.Controls;

namespace Util.Webs.Ext {
    /// <summary>
    /// 工具栏
    /// </summary>
    public interface IToolbar : IComponent<IToolbar> {
        /// <summary>
        /// 添加工具栏按钮
        /// </summary>
        /// <param name="text">按钮文本</param>
        /// <param name="handler">回调函数</param>
        /// <param name="iconClass">图标class</param>
        IToolbar Button( string text, string handler, string iconClass = "" );
        /// <summary>
        /// 添加工具栏按钮
        /// </summary>
        /// <param name="btn">工具栏按钮</param>
        IToolbar Button( IToolbarButton btn );
        /// <summary>
        /// 添加分隔符
        /// </summary>
        IToolbar Separator();
        /// <summary>
        /// 添加填充符，产生的效果是后面添加的组件将显示在工具栏的右侧
        /// </summary>
        IToolbar Fill();
        /// <summary>
        /// 添加Html
        /// </summary>
        /// <param name="html">Html</param>
        IToolbar Html( string html );
    }
}
