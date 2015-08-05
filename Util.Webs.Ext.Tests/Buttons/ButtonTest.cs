using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Controls.Buttons;

namespace Util.Webs.Ext.Tests.Buttons {
    /// <summary>
    /// 按钮测试
    /// </summary>
    [TestClass]
    public class ButtonTest {

        #region 测试初始化

        /// <summary>
        /// 面板
        /// </summary>
        private Button _button;

        /// <summary>
        /// 预期
        /// </summary>
        private Str _result;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _button = new Button();
            _button.Id( "btn" );
            _result = new Str();
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        private void CreateResult( Action<Str> handler ) {
            _result.Add( "var btn = new Ext.Button({" );
            _result.Add( "\"id\":\"btn\"," );
            handler.Invoke( _result );
            _result.Add( "});" );
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertEqual() {
            Assert.AreEqual( _result.ToString(), _button.ToHtmlString() );
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

        #region TestText(文本)

        /// <summary>
        /// 测试文本
        /// </summary>
        [TestMethod]
        public void TestText() {
            _button.Text( "a" );
            CreateResult( t => t.Add( "\"text\":\"a\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestIconClass(图标class)

        /// <summary>
        /// 测试图标class
        /// </summary>
        [TestMethod]
        public void TestIconClass() {
            _button.IconClass( "a" );
            CreateResult( t => t.Add( "\"iconCls\":\"a\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestRenderWithXType(测试XType方式渲染)

        /// <summary>
        /// 测试XType方式渲染
        /// </summary>
        [TestMethod]
        public void TestRenderWithXType() {
            _button = new Button();
            _button.RenderWithXType();
            _result.Clear();
            _result.Add( "{}" );
            AssertEqual();
        }

        /// <summary>
        /// 测试XType方式渲染
        /// </summary>
        [TestMethod]
        public void TestRenderWithXType_Text() {
            _button = new Button();
            _button.RenderWithXType().Text( "a" );
            _result.Clear();
            _result.Add( "{\"text\":\"a\"}" );
            AssertEqual();
        }

        #endregion
    }
}
