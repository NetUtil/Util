using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests {
    /// <summary>
    /// Web单元测试
    /// </summary>
    [TestClass]
    public class WebTest {
        /// <summary>
        /// 解析相对Url,验证空值
        /// </summary>
        [TestMethod]
        public void TestResolveUrl_Validate_Empty() {
            Assert.AreEqual( "",Web.ResolveUrl( null ) );
            Assert.AreEqual( "", Web.ResolveUrl( "" ) );
        }

        /// <summary>
        /// 解析相对Url,如果是根路径，直接返回，并修正反斜杠
        /// </summary>
        [TestMethod]
        public void TestResolveUrl_RootPath() {
            Assert.AreEqual( "/a.js",Web.ResolveUrl( "/a.js" ) );
            Assert.AreEqual( "/a/b.js", Web.ResolveUrl( @"\a\b.js" ) );
        }

        /// <summary>
        /// 解析相对Url,如果是Http绝对路径，则直接返回
        /// </summary>
        [TestMethod]
        public void TestResolveUrl_Http() {
            Assert.AreEqual( "http://a.js", Web.ResolveUrl( "http://a.js" ) );
        }

        /// <summary>
        /// Url编码
        /// </summary>
        [TestMethod]
        public void TestUrlEncode() {
            Assert.AreEqual( "http%3a%2f%2fwww.a.com", Web.UrlEncode( @"http://www.a.com" ) );
        }

        /// <summary>
        /// Url编码,转大写
        /// </summary>
        [TestMethod]
        public void TestUrlEncode_Upper() {
            Assert.AreEqual( "http%3A%2F%2Fwww.a.com", Web.UrlEncode( @"http://www.a.com", true ) );
        }
    }
}
