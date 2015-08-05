using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Controls.ProgressBars;

namespace Util.Webs.Ext.Tests.ProgressBars {
    /// <summary>
    /// 进度条测试
    /// </summary>
    [TestClass]
    public class ProgressBarTest {
        /// <summary>
        /// 进度条
        /// </summary>
        private IProgressBar _progressBar;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _progressBar = new ProgressBar();
        }

        /// <summary>
        /// 获取默认结果
        /// </summary>
        public static string GetResult_Default() {
            Str result = new Str();
            result.Add( "Ext.Msg.show({" );
            result.Add( "wait: true," );
            result.Add( "draggable: false," );
            result.Add( "width: 300," );
            result.Add( "progressText: \"请稍候..\"," );
            result.Add( "msg: \"处理中..\"," );
            result.Add( "icon: \"progress-Save\"" );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 获取修改后的结果
        /// </summary>
        public static string GetResult_All() {
            Str result = new Str();
            result.Add( "Ext.Msg.show({" );
            result.Add( "wait: true," );
            result.Add( "draggable: false," );
            result.Add( "width: 300," );
            result.Add( "progressText: \"我在飞\"," );
            result.Add( "msg: \"内容\"," );
            result.Add( "icon: \"icon\"" );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 获取修改进度条内容结果
        /// </summary>
        public static string GetResult_Content() {
            Str result = new Str();
            result.Add( "Ext.Msg.show({" );
            result.Add( "wait: true," );
            result.Add( "draggable: false," );
            result.Add( "width: 300," );
            result.Add( "progressText: \"请稍候..\"," );
            result.Add( "msg: \"\"," );
            result.Add( "icon: \"progress-Save\"" );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 获取隐藏结果
        /// </summary>
        public static string GetResult_Hide() {
            return "Ext.Msg.hide();";
        }

        /// <summary>
        /// 默认进度条
        /// </summary>
        [TestMethod]
        public void Test_Default() {
            Assert.AreEqual( GetResult_Default(), _progressBar.ToHtmlString() );
        }

        /// <summary>
        /// 修改进度条文本
        /// </summary>
        [TestMethod]
        public void Test_ProgressText() {
            _progressBar.ProgressText("我在飞");
            _progressBar.Content( "内容" );
            _progressBar.IconClass("icon");
            Assert.AreEqual( GetResult_All(), _progressBar.ToHtmlString() );
        }
    }
}
