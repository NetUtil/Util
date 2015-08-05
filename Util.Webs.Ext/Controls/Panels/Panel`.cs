using Util.Webs.Ext.Configs;

namespace Util.Webs.Ext.Controls.Panels {
    /// <summary>
    /// 面板
    /// </summary>
    /// <typeparam name="T">面板类型</typeparam>
    public class Panel<T> : ContainerBase<T>, IPanel<T> where T : IComponent<T> {

        #region 构造方法

        /// <summary>
        /// 初始化面板
        /// </summary>
        public Panel() {
            _region = Ext.Region.None;
        }

        #endregion

        #region 字段

        /// <summary>
        /// 标题
        /// </summary>
        private string _title;

        /// <summary>
        /// Html
        /// </summary>
        private string _html;

        /// <summary>
        /// 区域
        /// </summary>
        private Region _region;

        /// <summary>
        /// 最小尺寸
        /// </summary>
        private int? _minSize;

        /// <summary>
        /// 最大尺寸
        /// </summary>
        private int? _maxSize;

        /// <summary>
        /// 选项卡提示
        /// </summary>
        private string _tabTip;

        /// <summary>
        /// 图标class
        /// </summary>
        private string _iconClass;

        /// <summary>
        /// 允许折叠
        /// </summary>
        private bool? _collapsible;

        /// <summary>
        /// 允许拖动改动面板大小
        /// </summary>
        private bool? _split;

        /// <summary>
        /// 允许关闭
        /// </summary>
        private bool? _closable;

        /// <summary>
        /// 加载内容元素Id
        /// </summary>
        private string _elementId;

        /// <summary>
        /// 自动显示滚动条
        /// </summary>
        private bool? _autoScroll;

        /// <summary>
        /// 显示圆角边框
        /// </summary>
        private bool? _showRoundBorder;

        /// <summary>
        /// 顶部工具栏
        /// </summary>
        private IToolbar _topbar;

        /// <summary>
        /// 底部工具栏
        /// </summary>
        private IToolbar _bottombar;

        /// <summary>
        /// 迷你折叠模式
        /// </summary>
        private string _collapseMode;

        /// <summary>
        /// 是否显示边框
        /// </summary>
        private bool? _border;

        #endregion

        #region Title(设置标题)

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title">标题</param>
        public T Title( string title ) {
            _title = title;
            return This();
        }

        #endregion

        #region Html(设置Html)

        /// <summary>
        /// 设置Html
        /// </summary>
        /// <param name="html">Html</param>
        public T Html( string html ) {
            _html = html;
            return This();
        }

        #endregion

        #region Region(设置区域)

        /// <summary>
        /// 设置区域
        /// </summary>
        /// <param name="region">区域</param>
        public T Region( Region region ) {
            _region = region;
            return This();
        }

        #endregion

        #region MinSize(设置最小尺寸)

        /// <summary>
        /// 设置最小尺寸
        /// </summary>
        /// <param name="minSize">最小尺寸</param>
        public T MinSize( int? minSize ) {
            _minSize = minSize;
            return This();
        }

        #endregion

        #region MaxSize(设置最大尺寸)

        /// <summary>
        /// 设置最大尺寸
        /// </summary>
        /// <param name="maxSize">最大尺寸</param>
        public T MaxSize( int? maxSize ) {
            _maxSize = maxSize;
            return This();
        }

        #endregion

        #region TabTip(设置选项卡提示)

        /// <summary>
        /// 设置选项卡提示
        /// </summary>
        /// <param name="tip">选项卡提示</param>
        public T TabTip( string tip ) {
            _tabTip = tip;
            return This();
        }

        #endregion

        #region IconClass(设置图标class)

        /// <summary>
        /// 设置图标class
        /// </summary>
        /// <param name="iconClass">图标class</param>
        public T IconClass( string iconClass ) {
            _iconClass = iconClass;
            return This();
        }

        #endregion

        #region Collapsible(允许折叠)

        /// <summary>
        /// 允许折叠
        /// </summary>
        public T Collapsible() {
            _collapsible = true;
            return This();
        }

        #endregion

        #region Split(允许拖动改动面板大小)

        /// <summary>
        /// 允许拖动改动面板大小
        /// </summary>
        public T Split() {
            _split = true;
            return This();
        }

        #endregion

        #region LoadContent(加载内容)

        /// <summary>
        /// 加载内容
        /// </summary>
        /// <param name="elementId">元素Id</param>
        public T LoadContent( string elementId ) {
            _elementId = elementId;
            return This();
        }

        #endregion

        #region Closable(允许关闭)

        /// <summary>
        /// 允许关闭
        /// </summary>
        /// <param name="closable">是否允许关闭</param>
        public T Closable( bool closable = true ) {
            _closable = closable;
            return This();
        }

        #endregion

        #region AutoScroll(自动显示滚动条)

        /// <summary>
        /// 自动显示滚动条
        /// </summary>
        public T AutoScroll() {
            _autoScroll = true;
            return This();
        }

        #endregion

        #region Frame(显示圆角边框)

        /// <summary>
        /// 显示圆角边框
        /// </summary>
        /// <param name="isShow">是否显示圆角边框</param>
        public T Frame( bool isShow = true ) {
            _showRoundBorder = isShow;
            return This();
        }

        #endregion

        #region TopBar(添加顶部工具栏)

        /// <summary>
        /// 添加顶部工具栏
        /// </summary>
        /// <param name="toolbar">工具栏</param>
        public T TopBar( IToolbar toolbar ) {
            if ( toolbar == null )
                return This();
            toolbar.RenderWithXType();
            _topbar = toolbar;
            return This();
        }

        #endregion

        #region BottomBar(添加底部工具栏)

        /// <summary>
        /// 添加底部工具栏
        /// </summary>
        /// <param name="toolbar">工具栏</param>
        public T BottomBar( IToolbar toolbar ) {
            if ( toolbar == null )
                return This();
            toolbar.RenderWithXType();
            _bottombar = toolbar;
            return This();
        }

        #endregion

        #region Mini(迷你折叠模式)

        /// <summary>
        /// 迷你折叠模式
        /// </summary>
        public T Mini() {
            _collapseMode = "mini";
            return This();
        }

        #endregion

        #region Border(显示边框)

        /// <summary>
        /// 显示边框
        /// </summary>
        /// <param name="showBorder">是否显示边框</param>
        public T Border( bool showBorder = true ) {
            _border = showBorder;
            return This();
        }

        #endregion

        #region GetComponentName(获取组件名)

        /// <summary>
        /// 获取组件名
        /// </summary>
        internal override string GetComponentName() {
            return "Ext.Panel";
        }

        #endregion

        #region GetConfig(获取配置)

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return new PanelConfig();
        }

        #endregion

        #region InitConfig(初始化配置)

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="config">配置</param>
        protected override void InitConfig( IConfig config ) {
            base.InitConfig( config );
            var panelConfig = (PanelConfig)config;
            panelConfig.title = _title;
            panelConfig.html = _html;
            panelConfig.region = _region.Description();
            panelConfig.collapsible = _collapsible;
            panelConfig.split = _split;
            panelConfig.contentEl = _elementId;
            panelConfig.minSize = _minSize;
            panelConfig.maxSize = _maxSize;
            panelConfig.tabTip = _tabTip;
            panelConfig.closable = _closable;
            panelConfig.autoScroll = _autoScroll;
            panelConfig.iconCls = _iconClass;
            panelConfig.frame = _showRoundBorder;
            panelConfig.collapseMode = _collapseMode;
            panelConfig.border = _border;
            if ( _topbar != null )
                panelConfig.tbar = _topbar.ToHtmlString();
            if ( _bottombar != null )
                panelConfig.bbar = _bottombar.ToHtmlString();
        }

        #endregion
    }
}
