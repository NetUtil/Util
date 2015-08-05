using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Compress;

namespace Util.Tests.Integration.Compress {
    /// <summary>
    /// NotNetZip压缩测试
    /// </summary>
    [TestClass]
    public class DotNetZipTest {
        /// <summary>
        /// 压缩器
        /// </summary>
        private ICompress _compress;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _compress = CompressFactory.CreateDotNetZip();
        }

        /// <summary>
        /// 压缩
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestCompress() {
            _compress.Password( "a" ).AddDirectory( @"d:\a", @"d:\Deploy" ).AddFile( @"d:\a.doc", @"d:\b.doc" ).Compress( @"d:", "c" );
        }

        /// <summary>
        /// 解压缩
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestDecompress() {
            _compress.Password( "a" ).AddFile( @"d:\a\c.zip" ).Decompress(@"d:\a");
        }
    }
}
