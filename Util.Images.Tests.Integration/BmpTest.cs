using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Images.Tests.Integration {
    /// <summary>
    /// Bmp图片操作测试
    /// </summary>
    [TestClass]
    public class BmpTest {
        /// <summary>
        /// 源图片地址
        /// </summary>
        public static string SourcePath { get; set; }
        /// <summary>
        /// 目标图片地址
        /// </summary>
        public static string DestPath { get; set; }

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            SourcePath = Sys.GetPhysicalPath( "~/01-Samples/c.bmp" );
            DestPath = @"d:\c.bmp";
        }

        /// <summary>
        /// 创建缩略图
        /// </summary>
        [TestMethod]
        public void TestCreateThumb() {
            var image = Image.CreateThumb( SourcePath, DestPath, 200, 100 );
            Assert.AreEqual( 1920,image.SourceWidth );
            Assert.AreEqual( 1080, image.SourceHeight );
            Assert.AreEqual( 200, image.Width );
            Assert.AreEqual( 100, image.Height );
            File.Delete( DestPath );
        }

        /// <summary>
        /// 创建缩略图,使用Url查询字符串参数
        /// </summary>
        [TestMethod]
        public void TestCreateThumb_Query() {
            var image = Image.CreateThumb( SourcePath, @"d:\c.png", "width=790&height=200&format=png&mode=Pad" );
            Assert.AreEqual( 1920, image.SourceWidth );
            Assert.AreEqual( 1080, image.SourceHeight );
            File.Delete( @"d:\c.png" );
        }
    }
}
