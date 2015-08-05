using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Datas.Queries;
using Util.Datas.Tests.Samples;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 查询对象测试
    /// </summary>
    [TestClass]
    public class QueryTest {

        #region 测试初始化

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

            //创建查询对象
            _query = new Query<Customer, int>();
        }

        #endregion

        #region 验证添加参数

        /// <summary>
        /// 添加的条件为null,抛出异常
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof(ArgumentNullException) )]
        public void TestAdd_Validate_Null() {
            Expression<Func<Customer, bool>> predicate = null;
            _query.Filter( predicate );
        }

        /// <summary>
        /// 一次添加两个条件，抛出异常
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof(InvalidOperationException) )]
        public void TestAdd_Validate_2Criteria() {
            try {
                _query.Filter( t => t.Name == "A" || t.Name == "B" );
            }
            catch( InvalidOperationException ex ) {
                Assert.IsTrue( ex.Message.Contains( "仅允许添加一个条件" ) );
                throw;
            }
        }

        /// <summary>
        /// 条件的值均为空，忽略所有条件
        /// </summary>
        [TestMethod]
        public void TestQuery_Validate_0Criteria() {
            //添加条件
            _query.Filter( t => t.Name == "" );
            _query.Filter( t => t.EnglishName == "" );
            _query.Filter( t => t.Age == null );

            //验证
            _customerRepository = Ioc.Create<ICustomerRepository>();
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 2, customers.Count );
        }

        /// <summary>
        /// 如果值为空，则忽略该条件
        /// </summary>
        [TestMethod]
        public void TestQuery_Validate_ValueIsEmpty() {
            //添加条件
            _query.Filter( t => t.Name == "A" );
            _query.Filter( t => t.EnglishName == "" );
            _query.Filter( t => t.Age == null );

            //验证
            _customerRepository = Ioc.Create<ICustomerRepository>();
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, customers.Count );
        }

        #endregion

        #region 查询操作

        /// <summary>
        /// 指定一个条件进行查询
        /// </summary>
        [TestMethod]
        public void TestQuery_1Criteria() {
            _query.Filter( t => t.Name == "A" );
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, customers.Count );
            Assert.AreEqual( "A", customers[0].Name );
        }

        /// <summary>
        /// 指定2个条件进行查询，多个Add添加的条件使用与操作连接
        /// </summary>
        [TestMethod]
        public void TestQuery_2Criteria_And() {
            _query.Filter( t => t.Name == "A" );
            _query.Filter( t => t.EnglishName == "B" );
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 0, customers.Count );
        }

        /// <summary>
        /// 指定3个条件进行查询
        /// </summary>
        [TestMethod]
        public void TestQuery_3Criteria_And() {
            _query.Filter( t => t.Name == "A" ).Filter( t => t.EnglishName == "A" ).Filter( t => t.Age == 10 );
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, customers.Count );
        }

        #endregion

        #region 规约模式

        /// <summary>
        /// 自定义查询条件
        /// </summary>
        [TestMethod]
        public void TestQuery_CustomCriteria_1() {
            _query.Filter( new VipCriteria() );
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, customers.Count );
            Assert.AreEqual( "B", customers[0].Name );
        }

        #endregion

        #region 过滤数值段

        /// <summary>
        /// 过滤整数段
        /// </summary>
        [TestMethod]
        public void TestFilterInt() {
            _query.FilterInt( t => t.Age, 11, 20 );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, result.Count );
        }

        /// <summary>
        /// 过滤可空整数段
        /// </summary>
        [TestMethod]
        public void TestFilterInt_Nullable() {
            _query.FilterInt( t => t.Tel, 2, 3 );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, result.Count );
        }

        /// <summary>
        /// 过滤double数值段
        /// </summary>
        [TestMethod]
        public void TestFilterDouble() {
            _query.FilterDouble( t => t.Db, 10, 10.1 );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, result.Count );
        }

        /// <summary>
        /// 过滤可空double数值段
        /// </summary>
        [TestMethod]
        public void TestFilterDouble_Nullable() {
            _query.FilterDouble( t => t.NullableDb, 10, 10.1 );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, result.Count );
        }

        /// <summary>
        /// 过滤decimal数值段
        /// </summary>
        [TestMethod]
        public void TestFilterDecimal() {
            _query.FilterDecimal( t => t.Dec, 10M, 10.1M );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, result.Count );
        }

        /// <summary>
        /// 过滤可空decimal数值段
        /// </summary>
        [TestMethod]
        public void TestFilterDecimal_Nullable() {
            _query.FilterDecimal( t => t.NullableDec, 10M, 10.1M );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, result.Count );
        }

        #endregion

        #region 过滤日期段

        /// <summary>
        /// 过滤日期段
        /// </summary>
        [TestMethod]
        public void TestFilterDate() {
            _query.FilterDate( t => t.Birthday, Customer.Date1, Customer.Date2.Date );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 2, result.Count );
        }

        /// <summary>
        /// 过滤日期段
        /// </summary>
        [TestMethod]
        public void TestFilterDate_Nullable() {
            _query.FilterDate( t => t.NullableBirthday, Customer.Date1, Customer.Date2.Date );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 2, result.Count );
        }

        /// <summary>
        /// 过滤日期时间段
        /// </summary>
        [TestMethod]
        public void TestFilterDateTime() {
            _query.FilterDateTime( t => t.Birthday, Customer.Date1, Customer.Date2.Date );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, result.Count );
        }

        /// <summary>
        /// 过滤日期时间段
        /// </summary>
        [TestMethod]
        public void TestFilterDateTime_Nullable() {
            _query.FilterDateTime( t => t.NullableBirthday, Customer.Date1, Customer.Date2.Date );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, result.Count );
        }

        #endregion

        #region 枚举运算符操作

        /// <summary>
        /// 通过枚举方式设置条件
        /// </summary>
        [TestMethod]
        public void TestFilter_Operator_Equal() {
            _query.Filter( "Name", "A" );
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, customers.Count );
            Assert.AreEqual( "A", customers[0].Name );
        }

        /// <summary>
        /// 通过枚举方式设置条件
        /// </summary>
        [TestMethod]
        public void TestFilter_Operator_Contains() {
            //再添加一个客户
            AddCustomer();

            //模糊搜索
            _query.Filter( "Name", "A",Operator.Contains );
            _customerRepository = Ioc.Create<ICustomerRepository>();
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 2, customers.Count );
        }

        /// <summary>
        /// 新添加一个客户
        /// </summary>
        private void AddCustomer() {
            var customer = Customer.GetCustomerA();
            customer.Name = "ab";
            _customerRepository.Add( customer );
        }

        /// <summary>
        /// 测试StartsWith方法
        /// </summary>
        [TestMethod]
        public void TestFilter_Operator_Starts() {
            //再添加一个客户
            AddCustomer();

            //模糊搜索
            _query.Filter( "Name", "A", Operator.Starts );
            _customerRepository = Ioc.Create<ICustomerRepository>();
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 2, customers.Count );
        }

        /// <summary>
        /// 测试EndsWith方法
        /// </summary>
        [TestMethod]
        public void TestFilter_Operator_Ends() {
            //再添加一个客户
            AddCustomer();

            //模糊搜索
            _query.Filter( "Name", "A", Operator.Ends );
            _customerRepository = Ioc.Create<ICustomerRepository>();
            List<Customer> customers = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( 1, customers.Count );
        }



        #endregion

        #region 排序

        /// <summary>
        /// 升序
        /// </summary>
        [TestMethod]
        public void TestOrderBy_Asc_Lambda() {
            //添加C
            _customerRepository.Add( Customer.GetCustomerC() );

            //升序
            _query.OrderBy( t => t.Tel );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( "B", result.Last().Name );
        }

        /// <summary>
        /// 降序
        /// </summary>
        [TestMethod]
        public void TestOrderBy_Desc_Lambda() {
            _query.OrderBy( t => t.Tel,true );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( "A", result.Last().Name );
        }

        /// <summary>
        /// 升序
        /// </summary>
        [TestMethod]
        public void TestOrderBy_Asc_Enum() {
            //添加C
            _customerRepository.Add( Customer.GetCustomerC() );

            //升序
            _query.OrderBy( "Tel" );
            List<Customer> result = _query.GetList( _customerRepository.Find() );
            Assert.AreEqual( "B", result.Last().Name );
        }

        #endregion
    }
}
