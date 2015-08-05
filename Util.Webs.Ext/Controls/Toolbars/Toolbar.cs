using System.Collections.Generic;
using Util.Webs.Ext.Configs;
using Util.Webs.Ext.Renders;

namespace Util.Webs.Ext.Controls.Toolbars {
    /// <summary>
    /// 工具栏
    /// </summary>
    public class Toolbar : ComponentBase<IToolbar>, IToolbar {

        #region 构造方法

        /// <summary>
        /// 初始化工具栏
        /// </summary>
        public Toolbar() {
            _items = new List<IToolbarItem>();
        }

        #endregion

        #region 字段

        /// <summary>
        /// 工具栏项集合
        /// </summary>
        private readonly List<IToolbarItem> _items;

        #endregion

        #region Button(添加工具栏按钮)

        /// <summary>
        /// 添加工具栏按钮
        /// </summary>
        /// <param name="text">按钮文本</param>
        /// <param name="handler">回调函数</param>
        /// <param name="iconClass">图标class</param>
        public IToolbar Button( string text, string handler, string iconClass = "" ) {
            var button = new ToolbarButton();
            button.Text( text ).Handler( handler ).IconClass( iconClass );
            Button( button );
            return this;
        }

        /// <summary>
        /// 添加工具栏按钮
        /// </summary>
        /// <param name="btn">工具栏按钮</param>
        public IToolbar Button( IToolbarButton btn ) {
            if ( btn != null )
                _items.Add( btn );
            return this;
        }

        #endregion

        #region Separator(添加分隔符)

        /// <summary>
        /// 添加分隔符
        /// </summary>
        public IToolbar Separator() {
            _items.Add( new ToolbarSeparator() );
            return this;
        }

        #endregion

        #region Fill(添加填充符)

        /// <summary>
        /// 添加填充符
        /// </summary>
        public IToolbar Fill() {
            _items.Add( new ToolbarFill() );
            return this;
        }

        #endregion

        #region Html(添加Html)

        /// <summary>
        /// 添加Html
        /// </summary>
        /// <param name="html">Html</param>
        public IToolbar Html( string html ) {
            _items.Add( new ToolbarHtml( html ) );
            return this;
        }

        #endregion

        #region GetItems(获取工具栏项)

        /// <summary>
        /// 获取工具栏项
        /// </summary>
        internal List<IToolbarItem> GetItems() {
            return _items;
        }

        #endregion

        #region GetComponentName(获取组件名称)

        /// <summary>
        /// 获取组件名称
        /// </summary>
        internal override string GetComponentName() {
            return "Ext.Toolbar";
        }

        #endregion

        #region GetConfig(获取配置)

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return new ToolbarConfig();
        }

        #endregion

        #region GetTagRender(获取标签渲染器)

        /// <summary>
        /// 获取标签渲染器
        /// </summary>
        protected override IRender GetTagRender() {
            return new ToolbarTagRender( this );
        }

        #endregion

        #region GetXTypeRender(获取XType渲染器)

        /// <summary>
        /// 获取XType渲染器
        /// </summary>
        protected override IRender GetXTypeRender() {
            return new ToolbarXTypeRender( this );
        }

        #endregion
    }
}
