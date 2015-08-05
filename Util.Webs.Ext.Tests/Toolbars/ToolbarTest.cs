using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Controls.Toolbars;

namespace Util.Webs.Ext.Tests.Toolbars {
    /// <summary>
    /// 工具栏测试
    /// </summary>
    [TestClass]
    public partial class ToolbarTest {

        #region 测试初始化

        /// <summary>
        /// 面板
        /// </summary>
        private IToolbar _toolbar;

        /// <summary>
        /// 预期
        /// </summary>
        private Str _result;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _toolbar = new Toolbar();
            _toolbar.Id( "toolbar" );
            _result = new Str();
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        private void CreateResult( Action<Str> handler ) {
            _result.Add( "var toolbar = new Ext.Toolbar({" );
            _result.Add( "\"id\":\"toolbar\"," );
            handler.Invoke( _result );
            _result.Add( "});" );
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertEqual() {
            Assert.AreEqual( _result.ToString(), _toolbar.ToHtmlString() );
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

        #region TestRenderTo(设置渲染目标Id)

        /// <summary>
        /// 设置渲染目标Id
        /// </summary>
        [TestMethod]
        public void TestRenderTo() {
            _toolbar.RenderTo( "div1" );
            CreateResult( t => t.Add( "\"renderTo\":\"div1\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestRenderWithXType(以XType方式渲染)

        /// <summary>
        /// 测试以XType方式渲染
        /// </summary>
        [TestMethod]
        public void TestRenderWithXType() {
            _toolbar.RenderWithXType();
            _result.Clear();
            _result.Add( "[]" );
            AssertEqual();
        }

        /// <summary>
        /// 测试以XType方式渲染
        /// </summary>
        [TestMethod]
        public void TestRenderWithXType_Button() {
            _toolbar.RenderWithXType().Button( "a","a" );
            _result.Clear();
            _result.Add( "[{\"text\":\"a\",\"handler\":a}]" );
            AssertEqual();
        }

        #endregion

        #region TestSeparator(分隔符)

        /// <summary>
        /// 测试分隔符
        /// </summary>
        [TestMethod]
        public void TestSeparator() {
            _toolbar.RenderWithXType().Separator();
            _result.Clear();
            _result.Add( "[\"-\"]" );
            AssertEqual();
        }

        #endregion

        #region TestFill(填充符)

        /// <summary>
        /// 测试填充符
        /// </summary>
        [TestMethod]
        public void TestFill() {
            _toolbar.RenderWithXType().Fill();
            _result.Clear();
            _result.Add( "[\"->\"]" );
            AssertEqual();
        }

        #endregion

        #region TestHtml(Html)

        /// <summary>
        /// 测试Html
        /// </summary>
        [TestMethod]
        public void TestHtml() {
            _toolbar.RenderWithXType().Html("a");
            _result.Clear();
            _result.Add( "[\"a\"]" );
            AssertEqual();
        }

        #endregion
    }
}
