using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 测试整型标识实体
    /// </summary>
    [TestClass]
    public class IntEntityTest {
        /// <summary>
        /// 客户
        /// </summary>
        private Customer _customer;
        /// <summary>
        /// 客户仓储
        /// </summary>
        private ICustomerRepository _customerRepository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _customer = Customer.GetCustomer();
            _customerRepository = Ioc.Create<ICustomerRepository>();
        }

        /// <summary>
        /// 使用Add方法添加客户
        /// </summary>
        [TestMethod]
        public void TestAddCustomer_Add() {
            _customerRepository.Add( _customer );
            _customerRepository = Ioc.Create<ICustomerRepository>();
            Assert.IsNotNull( _customerRepository.Find( _customer.Id ) );
        }

        /// <summary>
        /// 使用AddCustomer方法添加客户
        /// </summary>
        [TestMethod]
        public void TestAddCustomer_AddCustomer() {
            _customerRepository.AddCustomerByNotCommit( _customer );
            _customerRepository.ClearCache();
            Assert.IsNull( _customerRepository.Find( _customer.Id ) );
        }

        /// <summary>
        /// 使用Add方法添加客户,一次添加多个
        /// </summary>
        [TestMethod]
        public void TestAdd_Multi() {
            _customerRepository.Clear();
            _customerRepository.Add( Customer.GetCustomers() );
            _customerRepository = Ioc.Create<ICustomerRepository>();
            Assert.AreEqual( 3, _customerRepository.FindAll().Count );
        }
    }
}
