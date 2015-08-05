using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Controls.Windows;

namespace Util.Webs.Ext.Tests.Windows {
    /// <summary>
    /// 窗口测试
    /// </summary>
    [TestClass]
    public class WindowTest {

        #region 测试初始化

        /// <summary>
        /// 面板
        /// </summary>
        private Window _window;

        /// <summary>
        /// 预期
        /// </summary>
        private Str _result;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _window = new Window();
            _window.Id( "window" );
            _result = new Str();
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        private void CreateResult( Action<Str> handler ) {
            _result.Add( "var window = new Ext.Window({" );
            _result.Add( "\"id\":\"window\"," );
            handler.Invoke( _result );
            _result.Add( "});" );
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertEqual() {
            Assert.AreEqual( _result.ToString(), _window.ToHtmlString() );
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

        #region TestShow(显示)

        /// <summary>
        /// 测试显示
        /// </summary>
        [TestMethod]
        public void TestShow() {
            _window.Var( "win" ).Show();
            _result.Add( "var win = new Ext.Window({" );
            _result.Add( "\"id\":\"window\"" );
            _result.Add( "});" );
            _result.Add( "win.show();" );
            AssertEqual();
        }

        #endregion

        #region TestHide(隐藏)

        /// <summary>
        /// 测试隐藏
        /// </summary>
        [TestMethod]
        public void TestHide() {
            _window.Hide();
            CreateResult( t => t.RemoveEnd( "," ) );
            _result.Add( "window.hide();" );
            AssertEqual();
        }

        #endregion

        #region TestIconClass(图标class)

        /// <summary>
        /// 测试图标class
        /// </summary>
        [TestMethod]
        public void TestIconClass() {
            _window.IconClass( "a" );
            CreateResult( t => t.Add( "\"iconCls\":\"a\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestConstrain(限制窗口在可视范围内)

        /// <summary>
        /// 测试限制窗口在可视范围内
        /// </summary>
        [TestMethod]
        public void TestConstrain() {
            _window.Constrain();
            CreateResult( t => t.Add( "\"constrain\":true" ) );
            AssertEqual();
        }

        #endregion

        #region TestResizable(允许改变窗口大小)

        /// <summary>
        /// 测试允许改变窗口大小
        /// </summary>
        [TestMethod]
        public void TestResizable() {
            _window.Resizable();
            CreateResult( t => t.Add( "\"resizable\":true" ) );
            AssertEqual();
        }

        /// <summary>
        /// 测试允许改变窗口大小
        /// </summary>
        [TestMethod]
        public void TestResizable_False() {
            _window.Resizable( false );
            CreateResult( t => t.Add( "\"resizable\":false" ) );
            AssertEqual();
        }

        #endregion

        #region TestDraggable(允许拖动)

        /// <summary>
        /// 测试允许拖动
        /// </summary>
        [TestMethod]
        public void TestDraggable() {
            _window.Draggable();
            CreateResult( t => t.Add( "\"draggable\":true" ) );
            AssertEqual();
        }

        /// <summary>
        /// 测试允许拖动
        /// </summary>
        [TestMethod]
        public void TestDraggable_False() {
            _window.Draggable( false );
            CreateResult( t => t.Add( "\"draggable\":false" ) );
            AssertEqual();
        }

        #endregion

        #region TestModal(模态窗)

        /// <summary>
        /// 测试模态窗
        /// </summary>
        [TestMethod]
        public void TestModal() {
            _window.Modal();
            CreateResult( t => t.Add( "\"modal\":true" ) );
            AssertEqual();
        }

        #endregion
    }
}
