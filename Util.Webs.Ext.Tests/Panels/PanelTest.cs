using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Controls.Panels;
using Util.Webs.Ext.Controls.Toolbars;

namespace Util.Webs.Ext.Tests.Panels {
    /// <summary>
    /// 面板测试
    /// </summary>
    [TestClass]
    public class PanelTest {

        #region 测试初始化

        /// <summary>
        /// 面板
        /// </summary>
        private Panel _panel;

        /// <summary>
        /// 预期
        /// </summary>
        private Str _result;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _panel = new Panel();
            _panel.Id( "panel" );
            _result = new Str();
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        private void CreateResult( Action<Str> handler ) {
            _result.Add( "var panel = new Ext.Panel({" );
            _result.Add( "\"id\":\"panel\"," );
            handler.Invoke( _result );
            _result.Add( "});" );
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertEqual() {
            Assert.AreEqual( _result.ToString(), _panel.ToHtmlString() );
        }

        #endregion

        #region TestRenderWithXType(以xtype方式渲染)

        /// <summary>
        /// 测试以xtype方式渲染
        /// </summary>
        [TestMethod]
        public void TestRenderWithXType() {
            _panel.RenderWithXType();
            Assert.AreEqual( "{\"id\":\"panel\",\"xtype\":\"panel\"}", _panel.ToHtmlString() );
        }

        #endregion

        #region TestId(标识)

        /// <summary>
        /// 测试标识
        /// </summary>
        [TestMethod]
        public void TestId() {
            CreateResult( t => t.RemoveEnd( "," ) );
            AssertEqual();
        }

        #endregion

        #region TestWidth(宽度)

        /// <summary>
        /// 测试宽度
        /// </summary>
        [TestMethod]
        public void TestWidth() {
            _panel.Width( 800 );
            CreateResult( t => t.Add( "\"width\":800" ) );
            AssertEqual();
        }

        #endregion

        #region TestHeight(高度)

        /// <summary>
        /// 测试高度
        /// </summary>
        [TestMethod]
        public void TestHeight() {
            _panel.Height( 800 );
            CreateResult( t => t.Add( "\"height\":800" ) );
            AssertEqual();
        }

        #endregion

        #region TestTitle(标题)

        /// <summary>
        /// 测试标题
        /// </summary>
        [TestMethod]
        public void TestTitle() {
            _panel.Title( "a" );
            CreateResult( t => t.Add( "\"title\":\"a\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestHtml(Html)

        /// <summary>
        /// 测试Html
        /// </summary>
        [TestMethod]
        public void TestHtml() {
            _panel.Html( "a" );
            CreateResult( t => t.Add( "\"html\":\"a\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestCollapsible(允许折叠)

        /// <summary>
        /// 测试允许折叠
        /// </summary>
        [TestMethod]
        public void TestCollapsible() {
            _panel.Collapsible();
            CreateResult( t => t.Add( "\"collapsible\":true" ) );
            AssertEqual();
        }

        #endregion

        #region TestRenderTo(渲染)

        /// <summary>
        /// 测试渲染
        /// </summary>
        [TestMethod]
        public void TestRenderTo() {
            _panel.RenderTo( "div" );
            CreateResult( t => t.Add( "\"renderTo\":\"div\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestAdd(添加面板)

        /// <summary>
        /// 添加1个面板
        /// </summary>
        [TestMethod]
        public void TestAdd_1Panel() {
            var panel = new Panel().Id( "child1" );
            _panel.Add( panel );
            CreateResult( t => t.Add( "\"items\":[{0}]",panel ) );
            AssertEqual();
        }

        /// <summary>
        /// 添加2个面板
        /// </summary>
        [TestMethod]
        public void TestAdd_2Panel() {
            var panel = new Panel().Id( "child1" );
            _panel.Add( panel );
            var panel2 = new Panel().Id( "child2" );
            _panel.Add( panel2 );
            CreateResult( t => t.Add( "\"items\":[{0},{1}]",panel,panel2 ) );
            AssertEqual();
        }

        #endregion

        #region TestRegion(区域)

        /// <summary>
        /// 测试区域
        /// </summary>
        [TestMethod]
        public void TestRegion() {
            _panel.Region( Region.Top );
            CreateResult( t => t.Add( "\"region\":\"north\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestLoadContent(加载内容)

        /// <summary>
        /// 测试加载内容
        /// </summary>
        [TestMethod]
        public void TestLoadContent() {
            _panel.LoadContent( "div1" );
            CreateResult( t => t.Add( "\"contentEl\":\"div1\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestSplit(允许拖动)

        /// <summary>
        /// 测试允许拖动
        /// </summary>
        [TestMethod]
        public void TestSplit() {
            _panel.Split();
            CreateResult( t => t.Add( "\"split\":true" ) );
            AssertEqual();
        }

        #endregion

        #region TestMinSize(最小尺寸)

        /// <summary>
        /// 测试最小尺寸
        /// </summary>
        [TestMethod]
        public void TestMinSize() {
            _panel.MinSize( 100 );
            CreateResult( t => t.Add( "\"minSize\":100" ) );
            AssertEqual();
        }

        #endregion

        #region TestMaxSize(最大尺寸)

        /// <summary>
        /// 测试最大尺寸
        /// </summary>
        [TestMethod]
        public void TestMaxSize() {
            _panel.MaxSize( 100 );
            CreateResult( t => t.Add( "\"maxSize\":100" ) );
            AssertEqual();
        }

        #endregion

        #region TestTabTip(选项卡提示)

        /// <summary>
        /// 测试选项卡提示
        /// </summary>
        [TestMethod]
        public void TestTabTip() {
            _panel.TabTip( "a" );
            CreateResult( t => t.Add( "\"tabTip\":\"a\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestClosable(允许关闭)

        /// <summary>
        /// 测试允许关闭
        /// </summary>
        [TestMethod]
        public void TestClosable() {
            _panel.Closable();
            CreateResult( t => t.Add( "\"closable\":true" ) );
            AssertEqual();
        }

        /// <summary>
        /// 测试允许关闭
        /// </summary>
        [TestMethod]
        public void TestClosable_False() {
            _panel.Closable( false );
            CreateResult( t => t.Add( "\"closable\":false" ) );
            AssertEqual();
        }

        #endregion

        #region TestDisable(禁用)

        /// <summary>
        /// 测试禁用
        /// </summary>
        [TestMethod]
        public void TestDisable() {
            _panel.Disable();
            CreateResult( t => t.Add( "\"disabled\":true" ) );
            AssertEqual();
        }

        #endregion

        #region TestAutoScroll(自动显示滚动条)

        /// <summary>
        /// 测试自动显示滚动条
        /// </summary>
        [TestMethod]
        public void TestAutoScroll() {
            _panel.AutoScroll();
            CreateResult( t => t.Add( "\"autoScroll\":true" ) );
            AssertEqual();
        }

        #endregion

        #region TestIconClass(图标class)

        /// <summary>
        /// 测试图标class
        /// </summary>
        [TestMethod]
        public void TestIconClass() {
            _panel.IconClass( "a" );
            CreateResult( t => t.Add( "\"iconCls\":\"a\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestFrame(显示圆角边框)

        /// <summary>
        /// 测试显示圆角边框
        /// </summary>
        [TestMethod]
        public void TestFrame() {
            _panel.Frame();
            CreateResult( t => t.Add( "\"frame\":true" ) );
            AssertEqual();
        }

        #endregion

        #region TesTopBar(添加顶部工具栏)

        /// <summary>
        /// 测试添加顶部工具栏
        /// </summary>
        [TestMethod]
        public void TesTopBar() {
            _panel.TopBar( new Toolbar().Button( "a", "a" ) );
            CreateResult( t => t.Add( "\"tbar\":[{\"text\":\"a\",\"handler\":a}]" ) );
            AssertEqual();
        }

        #endregion

        #region TesBottomBar(添加底部工具栏)

        /// <summary>
        /// 测试添加底部工具栏
        /// </summary>
        [TestMethod]
        public void TesBottomBar() {
            _panel.BottomBar( new Toolbar().Button( "a", "a" ) );
            CreateResult( t => t.Add( "\"bbar\":[{\"text\":\"a\",\"handler\":a}]" ) );
            AssertEqual();
        }

        #endregion

        #region TestAnchor(锚点布局)

        /// <summary>
        /// 测试锚点布局
        /// </summary>
        [TestMethod]
        public void TestAnchor() {
            _panel.Anchor( "50%", "-50" );
            CreateResult( t => t.Add( "\"anchor\":\"50% # -50\"" ) );
            AssertEqual();
        }

        /// <summary>
        /// 测试锚点布局
        /// </summary>
        [TestMethod]
        public void TestAnchor_Width() {
            _panel.Anchor( "50%" );
            CreateResult( t => t.Add( "\"anchor\":\"50%\"" ) );
            AssertEqual();
        }

        /// <summary>
        /// 测试锚点布局 - 百分比方式
        /// </summary>
        [TestMethod]
        public void TestAnchorByPercent() {
            _panel.AnchorByPercent( 50, 50 );
            CreateResult( t => t.Add( "\"anchor\":\"50% # 50%\"" ) );
            AssertEqual();
        }

        /// <summary>
        /// 测试锚点布局 - 百分比方式
        /// </summary>
        [TestMethod]
        public void TestAnchorByPercent_Width() {
            _panel.AnchorByPercent( 50 );
            CreateResult( t => t.Add( "\"anchor\":\"50%\"" ) );
            AssertEqual();
        }

        /// <summary>
        /// 测试锚点布局 - 偏移量方式
        /// </summary>
        [TestMethod]
        public void TestAnchorByOffset() {
            _panel.AnchorByOffset( 50, 50 );
            CreateResult( t => t.Add( "\"anchor\":\"-50 # -50\"" ) );
            AssertEqual();
        }

        /// <summary>
        /// 测试锚点布局 - 偏移量方式
        /// </summary>
        [TestMethod]
        public void TestAnchorByOffset_Width() {
            _panel.AnchorByOffset( 50 );
            CreateResult( t => t.Add( "\"anchor\":\"-50\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestMargin(外边距)

        /// <summary>
        /// 测试外边距
        /// </summary>
        [TestMethod]
        public void TestMargin() {
            _panel.Margin( 1, 2, 3, 4 );
            CreateResult( t => t.Add( "\"margins\":\"1 2 3 4\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestLabelWidth(表单标签宽度)

        /// <summary>
        /// 测试表单标签宽度
        /// </summary>
        [TestMethod]
        public void TestLabelWidth() {
            _panel.LabelWidth( 120 );
            CreateResult( t => t.Add( "\"labelWidth\":120" ) );
            AssertEqual();
        }

        #endregion

        #region TestAbsolute(设置绝对布局)

        /// <summary>
        /// 设置绝对布局
        /// </summary>
        [TestMethod]
        public void TestAbsolute() {
            _panel.Absolute( 1, 2 );
            CreateResult( t => {
                t.Add( "\"x\":1," );
                t.Add( "\"y\":2" );
            } );
            AssertEqual();
        }

        #endregion

        #region TestMini(迷你折叠模式)

        /// <summary>
        /// 测试迷你折叠模式
        /// </summary>
        [TestMethod]
        public void TestMini() {
            _panel.Mini();
            CreateResult( t => t.Add( "\"collapseMode\":\"mini\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestBorder(测试边框)

        /// <summary>
        /// 测试边框
        /// </summary>
        [TestMethod]
        public void TestBorder() {
            _panel.Border( false );
            CreateResult( t => t.Add( "\"border\":false" ) );
            AssertEqual();
        }

        #endregion
    }
}
