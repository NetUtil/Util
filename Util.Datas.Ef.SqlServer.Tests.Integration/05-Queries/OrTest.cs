using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Queries;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 测试条件连接操作
    /// </summary>
    [TestClass]
    public class OrTest {
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
            _customerRepository.Add( Customer.GetCustomerA() );
            _customerRepository.Add( Customer.GetCustomerB() );
            _customerRepository.Add( Customer.GetCustomerC() );

            //创建查询对象
            _query = new Query<Customer, int>();
        }

        /// <summary>
        /// 使用And连接，当前查询对象未设置条件
        /// </summary>
        [TestMethod]
        public void TestAnd_SelfPredicateIsNull() {
            //And连接
            _query.And( t => t.Name == "A" );

            //验证
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, customers.Count );
        }

        /// <summary>
        /// 测试或连接
        /// </summary>
        [TestMethod]
        public void TestOr_1() {
            //添加条件
            _query.Filter( t => t.Name == "A" );

            //创建第二个查询对象
            Query<Customer, int> query2 = new Query<Customer, int>();
            query2.Filter( t => t.EnglishName == "B" );

            //或操作合并查询对象
            _query.Or( query2 );

            //验证
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 2, customers.Count );
        }

        /// <summary>
        /// 测试或连接
        /// </summary>
        [TestMethod]
        public void TestOr_2() {
            //创建第二个查询对象
            Query<Customer, int> query2 = new Query<Customer, int>();
            query2.Filter( t => t.EnglishName == "B" ).Filter( t => t.Age == 20 );

            //添加条件
            _query.Filter( t => t.Name == "A" ).Or( query2 );

            //清空并添加一个条件，用And操作合并
            query2.Clear();
            query2.Filter( t => t.Age == 10 );
            _query.And( query2 );

            //验证
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, customers.Count );
        }
    }
}
