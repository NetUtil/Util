using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Algorithm;

namespace Util.Tests.Algorithm {
    /// <summary>
    /// 冒泡排序算法测试
    /// </summary>
    [TestClass]
    public class BubbleSortTest {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        private BubbleSort _sort;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _sort = new BubbleSort();
        }

        /// <summary>
        /// 测试输入135246,应输出123456
        /// </summary>
        [TestMethod]
        public void TestSort_135246() {
            var input = new object[] { 1, 3, 5, 2, 4, 6 };
            var output = new object[] { 1, 2, 3, 4, 5, 6 };
            AssertSort( input, output );
        }

        /// <summary>
        /// 断言排序结果
        /// </summary>
        private void AssertSort( object[] input, object[] output ) {
            _sort.Sort( input );
            for ( int i = 0; i < input.Length; i++ ) {
                Assert.AreEqual( output[i], input[i] );
            }
        }

        /// <summary>
        /// 测试输入987654321,应输出123456789
        /// </summary>
        [TestMethod]
        public void TestSort_987654321() {
            var input = new object[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var output = new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            AssertSort( input, output );
        }
    }
}
