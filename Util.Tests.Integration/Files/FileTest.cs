using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests.Integration.Files {
    /// <summary>
    /// 文件操作测试
    /// </summary>
    [TestClass]
    public class FileTest {
        /// <summary>
        /// A文件绝对路径
        /// </summary>
        public static string FilePath_A = "";

        /// <summary>
        /// B文件绝对路径
        /// </summary>
        public static string FilePath_B = "";

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            FilePath_A = Sys.GetPhysicalPath( @"~/01-Samples/a.txt" );
            FilePath_B = Sys.GetPhysicalPath( @"~/01-Samples/b.txt" );
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        [TestMethod]
        public void TestRead() {
            Assert.AreEqual( "a中国人", File.Read( FilePath_A, Encoding.GetEncoding( "gb2312" ) ) );
            Assert.AreEqual( "", File.Read( "abc" ) );
        }

        /// <summary>
        /// 读取文件到字节流中
        /// </summary>
        [TestMethod]
        public void TestReadToBytes() {
            Assert.AreEqual( "97", File.ReadToBytes( FilePath_A )[0].ToStr() );
            Assert.AreEqual( null, File.ReadToBytes( "abc" ) );
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        [TestMethod]
        public void TestWrite() {
            File.Write( " ", File.StringToBytes( "a中国人" ) );
            File.Write( FilePath_B, "" );
            File.Write( FilePath_B, File.StringToBytes( "a中国人" ) );
            Assert.AreEqual( "a中国人", File.Read( FilePath_B ) );
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        [TestMethod]
        public void TestDelete() {
            File.Delete( "" );
            string filePath = null;
            File.Delete( filePath );
            File.Delete( @"d:\a1234" );
        }

        /// <summary>
        /// 获取目录中全部文件列表
        /// </summary>
        [TestMethod]
        public void TestGetAllFiles() {
            List<string> files = File.GetAllFiles( Sys.GetPhysicalPath( @"~/01-Samples" ) );
            Assert.IsTrue( files.Contains( FilePath_A ) );
        }
    }
}
