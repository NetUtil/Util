using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Tests {
    /// <summary>
    /// 验证测试
    /// </summary>
    [TestClass]
    public class ValidTest {
        /// <summary>
        /// 是否整数
        /// </summary>
        [TestMethod]
        public void TestIsInt() {
            Assert.IsFalse( Valid.IsInt( "" ) );
            Assert.IsTrue( Valid.IsInt( "1" ) );
            Assert.IsFalse( Valid.IsInt( "1a" ) );
            Assert.IsTrue( Valid.IsInt( "100", 3 ), "IsInt 3" );
            Assert.IsFalse( Valid.IsInt( "100", 2 ), "IsInt 2" );
        }

        /// <summary>
        /// 是否数字
        /// </summary>
        [TestMethod]
        public void TestIsNumber() {
            Assert.IsFalse( Valid.IsNumber( "" ) );
            Assert.IsTrue( Valid.IsNumber( "1" ) );
            Assert.IsFalse( Valid.IsNumber( "1a" ) );
            Assert.IsTrue( Valid.IsNumber( "100.04" ) );
            Assert.IsFalse( Valid.IsNumber( "100a.01" ) );
        }

        /// <summary>
        /// 值为123，不重复
        /// </summary>
        [TestMethod]
        public void TestIsReapeat() {
            string value = "";
            Assert.IsFalse( Valid.IsRepeat( value ) );
            value = null;
            Assert.IsFalse( Valid.IsRepeat( value ) );
            value = "123";
            Assert.IsFalse( Valid.IsRepeat( value ) );
            value = "112";
            Assert.IsTrue( Valid.IsRepeat( value ) );
            value = "121";
            Assert.IsTrue( Valid.IsRepeat( value ) );
            value = "aba";
            Assert.IsTrue( Valid.IsRepeat( value ) );
        }

        /// <summary>
        /// 验证手机号
        /// </summary>
        [TestMethod]
        public void TestIsMobile() {
            Assert.IsFalse( Valid.IsMobile( "" ) );
            Assert.IsFalse( Valid.IsMobile( null ) );
            Assert.IsTrue( Valid.IsMobile( "15208281927" ) );
            Assert.IsFalse( Valid.IsMobile( "1520828192" ) );
            Assert.IsFalse( Valid.IsMobile( "152082819278" ) );
            Assert.IsFalse( Valid.IsMobile( "25208281927" ) );
            Assert.IsFalse( Valid.IsMobile( "12208281927" ) );
            Assert.IsFalse( Valid.IsMobile( "19208281927" ) );
        }

        /// <summary>
        /// 验证电子邮件
        /// </summary>
        [TestMethod]
        public void TestIsEmail() {
            Assert.IsFalse( Valid.IsEmail( "" ) );
            Assert.IsFalse( Valid.IsEmail( null ) );
            Assert.IsTrue( Valid.IsEmail( "xia@qq.com" ) );
            Assert.IsTrue( Valid.IsEmail( "entice-g@qq.com" ) );
            Assert.IsFalse( Valid.IsEmail( "xia$qq.com" ) );
            Assert.IsFalse( Valid.IsEmail( "@qq.com" ) );
            Assert.IsFalse( Valid.IsEmail( "xia@qq" ) );
            Assert.IsFalse( Valid.IsEmail( "xiaqq.com" ) );
        }
    }
}
