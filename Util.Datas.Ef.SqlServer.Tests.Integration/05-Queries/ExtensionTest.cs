using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas;
using Util.Datas.Tests.Samples;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 查询扩展测试
    /// </summary>
    [TestClass]
    public class ExtensionTest {
        /// <summary>
        /// 客户仓储
        /// </summary>
        private ICustomerRepository _customerRepository;
        /// <summary>
        /// 客户查询
        /// </summary>
        private IQueryable<Customer> _queryable;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            //设置基础数据
            _customerRepository = Ioc.Create<ICustomerRepository>();
            _customerRepository.Clear();
            _customerRepository.Add( Customer.GetCustomerA() );
            _customerRepository.Add( Customer.GetCustomerB() );
            _customerRepository.Add( Customer.GetCustomerC() );

            //设置查询
            _queryable = _customerRepository.Find();
        }

        /// <summary>
        /// 过滤条件
        /// </summary>
        [TestMethod]
        public void TestFilter() {
            //值为空则忽略条件
            List<Customer> result = Datas.Extensions.Filter( _queryable, t => t.Name.Contains( "" ) ).ToList();
            Assert.AreEqual( 3,result.Count );

            //添加一个条件
            result = Datas.Extensions.Filter( _queryable, t => t.Name.Contains( "B" ) ).ToList();
            Assert.AreEqual( 1, result.Count );
        }

        /// <summary>
        /// 使用规约条件
        /// </summary>
        [TestMethod]
        public void TestFilter_Criteria() {
            List<Customer> customers = Enumerable.ToList( _queryable.Filter( new VipCriteria() ) );
            Assert.AreEqual( 2, customers.Count );
            Assert.AreEqual( "B", customers[0].Name );
        }

        /// <summary>
        /// 过滤int数值段
        /// </summary>
        [TestMethod]
        public void TestFilterInt() {
            List<Customer> result = Enumerable.ToList( _queryable.FilterInt( t => t.Age,11,20 ) );
            Assert.AreEqual( 1, result.Count );
        }

        /// <summary>
        /// 过滤double数值段
        /// </summary>
        [TestMethod]
        public void TestFilterDouble() {
            List<Customer> result = Enumerable.ToList( _queryable.FilterDouble( t => t.Db, 10, 10.1 ) );
            Assert.AreEqual( 1, result.Count );
        }

        /// <summary>
        /// 过滤decimal数值段
        /// </summary>
        [TestMethod]
        public void TestFilterDecimal() {
            List<Customer> result = Enumerable.ToList( _queryable.FilterDecimal( t => t.Dec, 10, 10.1M ) );
            Assert.AreEqual( 1, result.Count );
        }

        /// <summary>
        /// 过滤日期段
        /// </summary>
        [TestMethod]
        public void TestFilterDate() {
            List<Customer> result = Enumerable.ToList( _queryable.FilterDate( t => t.Birthday, Customer.Date1, Customer.Date2.Date ) );
            Assert.AreEqual( 2, result.Count );
        }

        /// <summary>
        /// 过滤日期时间段
        /// </summary>
        [TestMethod]
        public void TestFilterDateTime() {
            List<Customer> result = Enumerable.ToList( _queryable.FilterDateTime( t => t.NullableBirthday, Customer.Date1, Customer.Date2.Date ) );
            Assert.AreEqual( 1, result.Count );
        }

        /// <summary>
        /// 升序
        /// </summary>
        [TestMethod]
        public void TestOrderBy_Asc() {
            List<Customer> result = _queryable.OrderBy( "Tel" ).ToList();
            Assert.AreEqual( "B", result.Last().Name ); 
        }

        /// <summary>
        /// 降序
        /// </summary>
        [TestMethod]
        public void TestOrderBy_Desc() {
            List<Customer> result = _queryable.OrderBy( "Tel desc" ).ToList();
            Assert.AreEqual( "A", result.Last().Name );
        }

        /// <summary>
        /// 2个排序条件
        /// </summary>
        [TestMethod]
        public void TestOrderBy_2() {
            //添加客户
            AddCustomer();

            //排序
            List<Customer> result = _queryable.OrderBy( "Name,Tel desc" ).ToList();
            Assert.AreEqual( 4, result.First().Tel );
            Assert.AreEqual( 1, result[1].Tel );
        }

        /// <summary>
        /// 新添加一个客户
        /// </summary>
        private void AddCustomer() {
            var customer = Customer.GetCustomerA();
            customer.Tel = 4;
            _customerRepository.Add( customer );
        }
    }
}
