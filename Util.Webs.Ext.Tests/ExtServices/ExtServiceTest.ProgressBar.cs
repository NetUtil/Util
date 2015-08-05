using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Tests.ProgressBars;

namespace Util.Webs.Ext.Tests.ExtServices {
    /// <summary>
    /// 进度条测试
    /// </summary>
    public partial class ExtServiceTest {
        /// <summary>
        /// 默认进度条
        /// </summary>
        [TestMethod]
        public void Test_Default() {
            Assert.AreEqual( ProgressBarTest.GetResult_Default(), _service.ProgressBar().ToHtmlString() );
        }

        /// <summary>
        /// 修改进度条文本
        /// </summary>
        [TestMethod]
        public void Test_ProgressText() {
            Assert.AreEqual( ProgressBarTest.GetResult_All(), _service.ProgressBar( "内容", "icon", "我在飞" ).ToHtmlString() );
        }

        /// <summary>
        /// 隐藏进度条
        /// </summary>
        [TestMethod]
        public void TestHide() {
            Assert.AreEqual( ProgressBarTest.GetResult_Hide(), _service.HideProgressBar().ToHtmlString() );
        }
    }
}
