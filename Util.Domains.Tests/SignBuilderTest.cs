using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Domains.Tests {
    /// <summary>
    /// 签名生成器测试
    /// </summary>
    [TestClass]
    public class SignBuilderTest {
        /// <summary>
        /// 签名生成器
        /// </summary>
        public SignBuilder Builder { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            Builder = new SignBuilder();
        }

        /// <summary>
        /// 默认返回空
        /// </summary>
        [TestMethod]
        public void Test_Empty() {
            Assert.AreEqual( string.Empty,Builder.CreateSign() );
        }

        /// <summary>
        /// 添加1个字符串值
        /// </summary>
        [TestMethod]
        public void Test_AddStringValue_1() {
            Builder.Add( "Name","a" );
            Assert.AreEqual( Encrypt.Md5By32( "name=a" ), Builder.CreateSign() );
        }

        /// <summary>
        /// 添加2个字符串值
        /// </summary>
        [TestMethod]
        public void Test_AddStringValue_2() {
            Builder.Add( "Tag", "b" );
            Builder.Add( "Name", "中国" );
            Assert.AreEqual( Encrypt.Md5By32( "name=中国&tag=b",Encoding.GetEncoding( "gb2312" ) ), Builder.CreateSign() );
        }

        /// <summary>
        /// 添加整型值
        /// </summary>
        [TestMethod]
        public void Test_AddIntValue() {
            Builder.Add( "Age",12 );
            Builder.Add( "Jar", 100 );
            Assert.AreEqual( Encrypt.Md5By32( "age=12&jar=100" ), Builder.CreateSign() );
        }

        /// <summary>
        /// 添加布尔值
        /// </summary>
        [TestMethod]
        public void Test_AddBoolValue() {
            Builder.Add( "Jar", false );
            Builder.Add( "Bar", true );
            Assert.AreEqual( Encrypt.Md5By32( "bar=true&jar=false" ), Builder.CreateSign() );
        }

        /// <summary>
        /// 添加double值
        /// </summary>
        [TestMethod]
        public void Test_AddDoubleValue() {
            Builder.Add( "A", 12.5 );
            Builder.Add( "C", 012.500 );
            Builder.Add( "B", 12.50 );
            Assert.AreEqual( Encrypt.Md5By32( "a=12.5&b=12.5&c=12.5" ), Builder.CreateSign() );
        }

        /// <summary>
        /// 添加decimal值
        /// </summary>
        [TestMethod]
        public void Test_AddDecimalValue() {
            Builder.Add( "A", 12.5M );
            Builder.Add( "C", 012.500M );
            Builder.Add( "D", 12.00M );
            Builder.Add( "B", 12.50M );
            Builder.Add( "E", 12.0505005000M );
            Builder.Add( "f", 1M );
            Assert.AreEqual( Encrypt.Md5By32( "a=12.5&b=12.5&c=12.5&d=12&e=12.0505005&f=1" ), Builder.CreateSign() );
        }

        /// <summary>
        /// 设置密钥
        /// </summary>
        [TestMethod]
        public void TestSetKey() {
            Builder.Add( "Name", "a" );
            Builder.SetKey( "a" );
            Assert.AreEqual( Encrypt.Md5By32( "name=a&a" ), Builder.CreateSign() );
        }
    }
}
