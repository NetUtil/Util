using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 分页测试
    /// </summary>
    [TestClass]
    public class PagerTest {
        /// <summary>
        /// 客户仓储
        /// </summary>
        private ICustomerRepository _customerRepository;

        /// <summary>
        /// 查询对象
        /// </summary>
        private Query<Customer, int> _query;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            //添加测试数据
            _customerRepository = Ioc.Create<ICustomerRepository>();
            _customerRepository.Clear();
            for( int i = 0; i < 6; i++ ) {
                _customerRepository.Add( Customer.GetCustomerA() );
                _customerRepository.Add( Customer.GetCustomerB() );
                _customerRepository.Add( Customer.GetCustomerC() );
            }

            //创建查询对象
            _query = new Query<Customer, int>();
            _query.PageSize = 3;
            _query.OrderBy( t => t.Name );
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        [TestMethod]
        public void TestGetPagerList() {
            _query.Filter( t => t.Name == "a" );
            _query.Page = 2;
            PagerList<Customer> result = _query.GetPagerList(_customerRepository.Find() );
            Assert.AreEqual( 2, result.Page, "Page" );
            Assert.AreEqual( 3, result.PageSize, "PageSize" );
            Assert.AreEqual( 2, result.PageCount, "PageCount" );
            Assert.AreEqual( 6, result.TotalCount, "TotalCount" );
        }
    }
}
