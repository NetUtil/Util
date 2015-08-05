using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Controls.Panels;
using Util.Webs.Ext.Controls.Viewports;

namespace Util.Webs.Ext.Tests.Viewports {
    /// <summary>
    /// 视区测试
    /// </summary>
    [TestClass]
    public class ViewportTest {

        #region 测试初始化

        /// <summary>
        /// 视区
        /// </summary>
        private Viewport _viewport;

        /// <summary>
        /// 预期
        /// </summary>
        private Str _result;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _viewport = new Viewport();
            _result = new Str();
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        private void CreateResult( Action<Str> handler ) {
            _result.Add( "var viewport = new Ext.Viewport({" );
            _result.Add( "\"id\":\"viewport\"," );
            handler.Invoke( _result );
            _result.Add( "});" );
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertEqual() {
            Assert.AreEqual( _result.ToString(), _viewport.ToHtmlString() );
        }

        #endregion

        #region TestLayout(布局)

        /// <summary>
        /// Border布局
        /// </summary>
        [TestMethod]
        public void TestLayout_Border() {
            _viewport.Layout( Layout.Border );
            CreateResult( t => t.Add( "\"layout\":\"border\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestAdd(添加子组件)

        /// <summary>
        /// 验证添加空对象
        /// </summary>
        [TestMethod]
        public void TestAdd_Validate_Null() {
            _viewport.Add( null );
            CreateResult( t => t.RemoveEnd( "," ) );
            AssertEqual();
        }

        /// <summary>
        /// 添加1个面板
        /// </summary>
        [TestMethod]
        public void TestAdd_1Panel() {
            var panel = new Panel();
            _viewport.Add( panel );
            CreateResult( t => t.Add( "\"items\":[{0}]", panel ) );
            AssertEqual();
        }

        /// <summary>
        /// 添加2个面板
        /// </summary>
        [TestMethod]
        public void TestAdd_2Panel() {
            var panel = new Panel();
            _viewport.Add( panel );
            var panel2 = new Panel();
            _viewport.Add( panel2 );
            CreateResult( t => t.Add( "\"items\":[{0},{1}]", panel, panel2 ) );
            AssertEqual();
        }

        #endregion
    }
}
