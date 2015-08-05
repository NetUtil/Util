using Util.Webs.Ext.Controls.Toolbars;

namespace Util.Webs.Ext.Renders {
    /// <summary>
    /// 工具栏XType渲染器
    /// </summary>
    internal class ToolbarXTypeRender : IRender {
        /// <summary>
        /// 初始化工具栏XType渲染器
        /// </summary>
        /// <param name="toolbar">工具栏</param>
        public ToolbarXTypeRender( Toolbar toolbar ) {
            _toolbar = toolbar;
        }

        /// <summary>
        /// 工具栏
        /// </summary>
        private readonly Toolbar _toolbar;

        /// <summary>
        /// 渲染
        /// </summary>
        public string Render() {
            var result = new Str();
            result.Add( "[" );
            result.Add( _toolbar.GetItems().Splice() );
            result.Add( "]" );
            return result.ToString();
        }
    }
}
