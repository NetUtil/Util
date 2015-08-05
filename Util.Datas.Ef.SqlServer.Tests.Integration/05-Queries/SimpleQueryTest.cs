using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 简单查询测试
    /// </summary>
    [TestClass]
    public class SimpleQueryTest {

        #region 测试初始化

        /// <summary>
        /// 客户仓储
        /// </summary>
        private ICustomerRepository _customerRepository;
        /// <summary>
        /// 客户A
        /// </summary>
        private Customer _customerA;
        /// <summary>
        /// 客户B
        /// </summary>
        private Customer _customerB;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _customerRepository = Ioc.Create<ICustomerRepository>();
            _customerRepository.Clear();
            _customerA = Customer.GetCustomerA();
            _customerB = Customer.GetCustomerB();
            _customerRepository.Add( _customerA );
            _customerRepository.Add( _customerB );
        }

        #endregion

        #region Find(通过实体标识列表查询)

        /// <summary>
        /// 通过实体标识列表查询
        /// </summary>
        [TestMethod]
        public void TestFind_Ids() {
            var list = _customerRepository.Find( new[] { _customerA.Id, _customerB.Id } );
            Assert.AreEqual( 2, list.Count );
        }

        #endregion
    }
}
