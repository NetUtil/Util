using Util.Webs.Ext.Configs;

namespace Util.Webs.Ext.Controls.TabPanels {
    /// <summary>
    /// 选项卡面板
    /// </summary>
    public class TabPanel : ContainerBase<ITabPanel>,ITabPanel{
        /// <summary>
        /// 初始化选项卡面板
        /// </summary>
        public TabPanel() {
            _tabPosition = Ext.TabPosition.None;
        }

        /// <summary>
        /// 启用选项卡滚动
        /// </summary>
        private bool? _enableTabScroll;
        /// <summary>
        /// 启用重置选项卡大小
        /// </summary>
        private bool? _resizeTabs;
        /// <summary>
        /// 选项卡最小尺寸
        /// </summary>
        private int? _minTabWidth;
        /// <summary>
        /// 激活选项卡索引
        /// </summary>
        private int? _activeTabIndex;
        /// <summary>
        /// 选项卡位置
        /// </summary>
        private TabPosition _tabPosition;

        /// <summary>
        /// 设置激活选项卡索引
        /// </summary>
        /// <param name="index">激活选项卡索引,第一个选项卡的索引为0</param>
        public ITabPanel ActiveTabIndex( int? index ) {
            _activeTabIndex = index;
            return this;
        }

        /// <summary>
        /// 设置选项卡位置
        /// </summary>
        /// <param name="position">选项卡位置</param>
        public ITabPanel TabPosition( TabPosition position ) {
            _tabPosition = position;
            return this;
        }

        /// <summary>
        /// 添加选项卡
        /// </summary>
        /// <param name="item">选项卡</param>
        public ITabPanel AddItem( IPanel item ) {
            if ( item == null )
                return this;
            SetActiveTabIndex();
            item.RenderWithXType();
            Add( item );
            return this;
        }

        /// <summary>
        /// 设置激活选项卡索引
        /// </summary>
        private void SetActiveTabIndex() {
            if ( _activeTabIndex == null )
                _activeTabIndex = 0;
        }

        /// <summary>
        /// 启用选项卡滚动,当选项卡位置为top时有效
        /// </summary>
        public ITabPanel EnableTabScroll() {
            _enableTabScroll = true;
            return this;
        }

        /// <summary>
        /// 设置选项卡宽度
        /// </summary>
        /// <param name="width">选项卡宽度</param>
        public ITabPanel TabWidth( int width ) {
            _resizeTabs = true;
            _minTabWidth = width;
            return this;
        }

        /// <summary>
        /// 获取组件名称
        /// </summary>
        internal override string GetComponentName() {
            return "Ext.TabPanel";
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            var config = new TabPanelConfig();
            config.activeTab = _activeTabIndex;
            config.enableTabScroll = _enableTabScroll;
            config.resizeTabs = _resizeTabs;
            config.minTabWidth = _minTabWidth;
            config.tabPosition = _tabPosition.Description();
            return config;
        }
    }
}
