using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Controls.Panels;
using Util.Webs.Ext.Controls.TabPanels;

namespace Util.Webs.Ext.Tests.TabPanels {
    /// <summary>
    /// 选项卡面板测试
    /// </summary>
    [TestClass]
    public class TabPanelTest {
        /// <summary>
        /// 预期输出
        /// </summary>
        private Str _result;
        /// <summary>
        /// 选项卡面板
        /// </summary>
        private TabPanel _tabPanel;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _result = new Str();
            _tabPanel = new TabPanel();
            _tabPanel.Id( "tabPanel" );
        }

        /// <summary>
        /// 测试标识
        /// </summary>
        [TestMethod]
        public void TestId() {
            _result.Add( "var tabPanel = new Ext.TabPanel({" );
            _result.Add( "\"id\":\"tabPanel\"" );
            _result.Add( "});" );
            AssertEqual();
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertEqual() {
            Assert.AreEqual( _result.ToString(), _tabPanel.ToHtmlString() );
        }

        /// <summary>
        /// 测试添加选项卡
        /// </summary>
        [TestMethod]
        public void TestAddItem() {
            var panel = new Panel().Id( "item" ).Title( "选项卡1" );
            _tabPanel.AddItem( panel );
            _result.Add( "var tabPanel = new Ext.TabPanel({" );
            _result.Add( "\"id\":\"tabPanel\"," );
            _result.Add( "\"items\":[{\"id\":\"item\",\"xtype\":\"panel\",\"title\":\"选项卡1\"}]," );
            _result.Add( "\"activeTab\":0" );
            _result.Add( "});" );
            AssertEqual();
        }

        /// <summary>
        /// 测试添加选项卡
        /// </summary>
        [TestMethod]
        public void TestAddItem_2() {
            var item1 = new Panel().Id( "item1" ).Title( "选项卡1" );
            var item2 = new Panel().Id( "item2" ).Title( "选项卡1" );
            _tabPanel.AddItem( item1 );
            _tabPanel.AddItem( item2 );
            _result.Add( "var tabPanel = new Ext.TabPanel({" );
            _result.Add( "\"id\":\"tabPanel\"," );
            _result.Add( "\"items\":[{0},{1}],", item1, item2 );
            _result.Add( "\"activeTab\":0" );
            _result.Add( "});" );
            AssertEqual();
        }

        /// <summary>
        /// 测试激活选项卡索引
        /// </summary>
        [TestMethod]
        public void TestActiveTabIndex() {
            _tabPanel.ActiveTabIndex( 0 );
            _result.Add( "var tabPanel = new Ext.TabPanel({" );
            _result.Add( "\"id\":\"tabPanel\"," );
            _result.Add( "\"activeTab\":0" );
            _result.Add( "});" );
            AssertEqual();
        }

        /// <summary>
        /// 测试启用选项卡滚动
        /// </summary>
        [TestMethod]
        public void TestEnableTabScroll() {
            _tabPanel.EnableTabScroll();
            _result.Add( "var tabPanel = new Ext.TabPanel({" );
            _result.Add( "\"id\":\"tabPanel\"," );
            _result.Add( "\"enableTabScroll\":true" );
            _result.Add( "});" );
            AssertEqual();
        }

        /// <summary>
        /// 测试设置选项卡宽度
        /// </summary>
        [TestMethod]
        public void TestSetTabWidth() {
            _tabPanel.TabWidth( 100 );
            _result.Add( "var tabPanel = new Ext.TabPanel({" );
            _result.Add( "\"id\":\"tabPanel\"," );
            _result.Add( "\"resizeTabs\":true," );
            _result.Add( "\"minTabWidth\":100" );
            _result.Add( "});" );
            AssertEqual();
        }

        /// <summary>
        /// 测试选项卡位置
        /// </summary>
        [TestMethod]
        public void TestTabPosition() {
            _tabPanel.TabPosition( TabPosition.Bottom );
            _result.Add( "var tabPanel = new Ext.TabPanel({" );
            _result.Add( "\"id\":\"tabPanel\"," );
            _result.Add( "\"tabPosition\":\"bottom\"" );
            _result.Add( "});" );
            AssertEqual();
        }
    }
}
