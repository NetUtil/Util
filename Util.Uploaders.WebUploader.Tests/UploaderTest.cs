using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Uploaders.WebUploader.Tests {
    /// <summary>
    /// 上传控件测试
    /// </summary>
    [TestClass]
    public class UploaderTest {
        /// <summary>
        /// 上传控件
        /// </summary>
        private Uploader _uploader;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _uploader = new Uploader();
        }

        /// <summary>
        /// 验证结果
        /// </summary>
        private void AssertResult(string options = "",string html = "") {
            var result = new Str();
            result.Add( "<div class=\"web-uploader\" data-options=\"{0}\">", options );
            result.Add( html );
            result.Add( "</div>" );
            Assert.AreEqual( result.ToString(), _uploader.ToString() );
            
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [TestMethod]
        public void TestDefault() {
            AssertResult();
        }

        /// <summary>
        /// 测试控件名称
        /// </summary>
        [TestMethod]
        public void TestName() {
            _uploader.Name( "a" );
            AssertResult( "{'name':'a'}" );
        }

        /// <summary>
        /// 测试设置html
        /// </summary>
        [TestMethod]
        public void TestHtml() {
            _uploader.Html( "a" );
            AssertResult( "", "a" );
        }

        /// <summary>
        /// 测试选择文件的按钮容器
        /// </summary>
        [TestMethod]
        public void TestPick() {
            _uploader.Pick( "a", "b", false );
            AssertResult( "{'pick':{'id':'#a','innerHTML':'b','multiple':false}}" );
        }

        /// <summary>
        /// 测试文件接收服务端
        /// </summary>
        [TestMethod]
        public void TestServer() {
            _uploader.Server( "a" );
            AssertResult( "{'server':'a'}" );
        }

        /// <summary>
        /// 测试文件加入队列事件
        /// </summary>
        [TestMethod]
        public void TestFileQueued() {
            _uploader.FileQueued( "a" );
            AssertResult( "{'fileQueued':a}" );
        }
    }
}
