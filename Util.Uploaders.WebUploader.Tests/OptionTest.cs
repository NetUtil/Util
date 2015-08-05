using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Uploaders.WebUploader.Configs;

namespace Util.Uploaders.WebUploader.Tests {
    /// <summary>
    /// 配置项测试
    /// </summary>
    [TestClass]
    public class OptionTest {
        /// <summary>
        /// 配置项
        /// </summary>
        private Option _option;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _option = new Option();
        }

        /// <summary>
        /// 测试拖拽的容器选择器
        /// </summary>
        [TestMethod]
        public void TestDnd() {
            _option.Dnd = "a";
            Assert.AreEqual( "{'dnd':'a'}", _option.ToString() );
        }

        /// <summary>
        /// 测试是否禁掉整个页面的拖拽功能
        /// </summary>
        [TestMethod]
        public void TestDisableGlobalDnd() {
            _option.DisableGlobalDnd = true;
            Assert.AreEqual( "{'disableGlobalDnd':true}", _option.ToString() );
        }

        /// <summary>
        /// 测试选择文件的按钮容器
        /// </summary>
        [TestMethod]
        public void TestPick() {
            _option.Pick = new PickOption() { Id = "#a", InnerHtml = "a", Multiple = true };
            Assert.AreEqual( "{'pick':{'id':'#a','innerHTML':'a','multiple':true}}", _option.ToString() );
        }

        /// <summary>
        /// 测试自动上传
        /// </summary>
        [TestMethod]
        public void TestAuto() {
            _option.Auto = true;
            Assert.AreEqual( "{'auto':true}", _option.ToString() );
        }

        /// <summary>
        /// 测试服务端Url
        /// </summary>
        [TestMethod]
        public void TestServer() {
            _option.Server = "a";
            Assert.AreEqual( "{'server':'a'}", _option.ToString() );
        }

        /// <summary>
        /// 测试文件加入队列事件
        /// </summary>
        [TestMethod]
        public void TestFileQueued() {
            _option.FileQueued = "a";
            Assert.AreEqual( "{'fileQueued':a}", _option.ToString() );
        }

        /// <summary>
        /// 测试上传进度事件
        /// </summary>
        [TestMethod]
        public void TestUploadProgress() {
            _option.UploadProgress = "a";
            Assert.AreEqual( "{'uploadProgress':a}", _option.ToString() );
        }
    }
}
