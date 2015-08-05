using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Domains.Tests.Changes {
    /// <summary>
    /// 对象变更测试
    /// </summary>
    [TestClass]
    public class ChangeTest {
        /// <summary>
        /// 测试1
        /// </summary>
        private Customer _customer1;

        /// <summary>
        /// 测试2
        /// </summary>
        private Customer _customer2;

        /// <summary>
        /// 初始化测试
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _customer1 = new Customer();
            _customer1.Employee = new Employee();
            _customer2 = new Customer();
            _customer2.Employee = new Employee();
        }

        /// <summary>
        /// 变更测试
        /// </summary>
        [TestMethod]
        public void Test_1() {
            Assert.AreEqual( 0, _customer1.GetChanges( _customer2 ).Count );
        }

        /// <summary>
        /// 变更测试
        /// </summary>
        [TestMethod]
        public void Test_2() {
            _customer2.Name = "a";
            var changes = _customer1.GetChanges( _customer2 );
            Assert.AreEqual( 1, changes.Count );
            Assert.AreEqual( "", changes[0].OldValue );
            Assert.AreEqual( "a", changes[0].NewValue );
        }

        /// <summary>
        /// 变更测试
        /// </summary>
        [TestMethod]
        public void Test_3() {
            _customer1.Name = "a";
            _customer2.Name = "a";
            Assert.AreEqual( 0, _customer1.GetChanges( _customer2 ).Count );
        }

        /// <summary>
        /// 变更测试
        /// </summary>
        [TestMethod]
        public void Test_4() {
            _customer2.Name = "a";
            _customer2.Employee.Name = "b";
            var changes = _customer1.GetChanges( _customer2 );
            Assert.AreEqual( 2, changes.Count );
            Assert.AreEqual( "客户名称", changes[0].Description );
            Assert.AreEqual( "", changes[0].OldValue );
            Assert.AreEqual( "a", changes[0].NewValue );
            Assert.AreEqual( "员工名称", changes[1].Description );
            Assert.AreEqual( "", changes[1].OldValue );
            Assert.AreEqual( "b", changes[1].NewValue );
        }

        /// <summary>
        /// 变更测试
        /// </summary>
        [TestMethod]
        public void Test_5() {
            _customer2.Name = "a";
            _customer2.Employee = new Employee();
            var changes = _customer1.GetChanges( _customer2 );
            Assert.AreEqual( 1, changes.Count );
        }

        /// <summary>
        /// 变更测试
        /// </summary>
        [TestMethod]
        public void Test_6() {
            _customer1.Dec = 100.00M;
            _customer2.Dec = 100;
            var changes = _customer1.GetChanges( _customer2 );
            Assert.AreEqual( 0, changes.Count );
            Assert.IsFalse( changes.IsAttention );
        }

        /// <summary>
        /// 变更测试
        /// </summary>
        [TestMethod]
        public void Test_7() {
            _customer1.Employees.Add( new Employee() { Name = "a" } );
            _customer1.Employees.Add( new Employee() { Name = "b" } );
            _customer2.Employees.Add( new Employee(){Name = "a2"} );
            _customer2.Employees.Add( new Employee() { Name = "b2" } );
            var changes = _customer1.GetChanges( _customer2 );
            Assert.AreEqual( 2, changes.Count );
            Assert.AreEqual( "a", changes[0].OldValue );
            Assert.AreEqual( "a2", changes[0].NewValue );
            Assert.AreEqual( "b", changes[1].OldValue );
            Assert.AreEqual( "b2", changes[1].NewValue );
        }

        /// <summary>
        /// 变更测试
        /// </summary>
        [TestMethod]
        public void Test_8() {
            _customer1.Name = "a";
            _customer2.Name = "b";
            _customer1.Dec = 1;
            _customer2.Dec = 2;
            var changes = _customer1.GetChanges( _customer2 );
            Assert.AreEqual( 2, changes.Count );
            Assert.IsTrue( changes.IsAttention );
            Assert.AreEqual( 1, changes.GetAttentionValues().Count );
            Assert.AreEqual( "b", changes.GetAttentionValues()[0].NewValue );
        }
    }
}
