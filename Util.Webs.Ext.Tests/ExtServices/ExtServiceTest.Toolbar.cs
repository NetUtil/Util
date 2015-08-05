using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Tests.Toolbars;

namespace Util.Webs.Ext.Tests.ExtServices {
    /// <summary>
    /// Ext服务测试 - 工具栏
    /// </summary>
    public partial class ExtServiceTest {
        /// <summary>
        /// 创建1个按钮 - 重载1
        /// </summary>
        [TestMethod]
        public void TestCreateButton_1_1() {
            var result = _service.Toolbar( "toolbar" ).Button( "新建", "showBox" );
            Assert.AreEqual( ToolbarTest.GetButtonScript_1(), result.ToHtmlString() );
        }

        /// <summary>
        /// 创建1个按钮 - 重载2
        /// </summary>
        [TestMethod]
        public void TestCreateButton_1_2() {
            var result = _service.Toolbar( "toolbar" ).Button( "新建", "showBox", "a" );
            Assert.AreEqual( ToolbarTest.GetButtonScript_1_2(), result.ToHtmlString() );
        }

        /// <summary>
        /// 创建2个按钮
        /// </summary>
        [TestMethod]
        public void TestCreateButton_2() {
            var result = _service.Toolbar( "toolbar" ).Button( "新建", "new" ).Button( "修改", "update" );
            Assert.AreEqual( ToolbarTest.GetButtonScript_2(), result.ToHtmlString() );
        }
    }
}
