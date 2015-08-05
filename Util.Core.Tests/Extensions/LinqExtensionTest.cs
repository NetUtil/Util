using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Tests.Samples;

namespace Util.Tests.Extensions {
    /// <summary>
    /// Linq表达式测试
    /// </summary>
    [TestClass]
    public class LinqExtensionTest {
        /// <summary>
        /// 测试过滤重复
        /// </summary>
        [TestMethod]
        public void TestDistinctBy_1() {
            var list = new List<Test1>() {
                new Test1(){ Name = "a"},
                new Test1(){ Name = "a"},
            };
            Assert.AreEqual( 1,list.DistinctBy( t => t.Name ).Count() );
        }

        /// <summary>
        /// 测试过滤重复
        /// </summary>
        [TestMethod]
        public void TestDistinctBy_2() {
            var list = new List<Test1>() {
                new Test1(){ Name = "a",Age = 1},
                new Test1(){ Name = "a",Age = 2},
            };
            Assert.AreEqual( 2, list.DistinctBy( t => new { t.Name,t.Age} ).Count() );
        }

        /// <summary>
        /// 测试过滤重复
        /// </summary>
        [TestMethod]
        public void TestDistinctBy_3() {
            var list = new List<Test1>() {
                new Test1(){ Name = "a",Age = 1},
                new Test1(){ Name = "a",Age = 1},
            };
            Assert.AreEqual( 1, list.DistinctBy( t => new { t.Name, t.Age } ).Count() );
        }
    }
}
