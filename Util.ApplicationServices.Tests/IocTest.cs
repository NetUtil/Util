using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.ApplicationServices.Tests.Samples;

namespace Util.ApplicationServices.Tests {
    /// <summary>
    /// Ioc测试
    /// </summary>
    [TestClass]
    public class IocTest {
        /// <summary>
        /// 测试
        /// </summary>
        [TestMethod]
        public void Test() {
            Ioc.RegisterTest();
            Assert.AreEqual( "TestService1", Ioc.Create<ITestService>().GetResult() );
        }

        /// <summary>
        /// 测试
        /// </summary>
        [TestMethod]
        public void Test_2() {
            Ioc.RegisterTest( new IocConfig() );
            Assert.AreEqual( "TestService2", Ioc.Create<ITestService>().GetResult() );
        }
    }
}
