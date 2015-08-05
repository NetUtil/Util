using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests.Encrypts {
    /// <summary>
    /// DES加密测试
    /// </summary>
    [TestClass]
    public class DesTest {
        /// <summary>
        /// 验证值为空
        /// </summary>
        [TestMethod]
        public void TestDes_Validate_ValueIsEmpty() {
            Assert.AreEqual( string.Empty, Encrypt.EncodeDes( "" ) );
            Assert.AreEqual( string.Empty, Encrypt.DecodeDes( "" ) );
        }

        /// <summary>
        /// 验证密钥为空
        /// </summary>
        [TestMethod]
        public void TestDes_Validate_KeyIsEmpty() {
            const double value = 100.123;
            Assert.AreEqual( string.Empty, Encrypt.EncodeDes( value, "" ) );
            Assert.AreEqual( string.Empty, Encrypt.DecodeDes( value, "" ) );
        }

        /// <summary>
        /// 验证无效密钥
        /// </summary>
        [TestMethod]
        public void TestDes_Validate_InvalidKey() {
            const double value = 100.123;
            const string key = "12345678901234567890123";
            Assert.AreEqual( string.Empty, Encrypt.EncodeDes( value, key ) );
            Assert.AreEqual( string.Empty, Encrypt.DecodeDes( value, key ) );
        }

        /// <summary>
        /// 加密数字
        /// </summary>
        [TestMethod]
        public void TestDes_Number() {
            const double value = 100.123;
            var encode = Encrypt.EncodeDes( value );
            Assert.AreEqual( value.ToStr(), Encrypt.DecodeDes( encode ) );
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        [TestMethod]
        public void TestDes_String() {
            const string value = @"~!@#$%^&*()_+|,./;[]'{}""}{?>:<> \\ qwe测 *试rtyuiopadE15R3JrMnByS3c9sdfghjklzxcvbnm1234567890-=\";
            var encode = Encrypt.EncodeDes( value );
            Assert.AreEqual( value.ToStr(), Encrypt.DecodeDes( encode ) );
        }
    }
}
