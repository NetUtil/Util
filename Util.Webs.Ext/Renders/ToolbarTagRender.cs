using Util.Webs.Ext.Controls.Toolbars;

namespace Util.Webs.Ext.Renders {
    /// <summary>
    /// 工具栏标签渲染器
    /// </summary>
    internal class ToolbarTagRender : TagRender<IToolbar> {
        /// <summary>
        /// 初始化工具栏标签渲染器
        /// </summary>
        /// <param name="toolbar">工具栏</param>
        public ToolbarTagRender( Toolbar toolbar ) 
            : base( toolbar ) {
            _toolbar = toolbar;
        }

        /// <summary>
        /// 工具栏
        /// </summary>
        private readonly Toolbar _toolbar;

        /// <summary>
        /// 渲染
        /// </summary>
        protected override void Render( Str result ) {
            base.Render( result );
            RenderItems( result );
        }

        /// <summary>
        /// 渲染子组件
        /// </summary>
        private void RenderItems( Str result ) {
            if ( _toolbar.GetItems().Count == 0 )
                return;
            result.Add( "{0}.add(", _toolbar.GetId() );
            result.Add( _toolbar.GetItems().Splice() );
            result.Add( ");" );
        }
    }
}
