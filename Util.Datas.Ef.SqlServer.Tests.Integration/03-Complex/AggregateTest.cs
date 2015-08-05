using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 聚合测试
    /// </summary>
    [TestClass]
    public class AggregateTest {

        #region 测试初始化

        /// <summary>
        /// 订单仓储
        /// </summary>
        private IOrderRepository _orderRepository;

        /// <summary>
        /// 订单
        /// </summary>
        private Order _order;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _orderRepository = Ioc.Create<IOrderRepository>();
            _order = CreateOrder();
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        private Order CreateOrder( Guid? orderId = null, Guid? itemId = null , Guid? itemId2 = null) {
            Order order;
            if ( orderId == null )
                order = new Order();
            else
                order = new Order( orderId.SafeValue() );
            order.Name = "order";

            //添加订单项1
            OrderItem orderItem;
            if( itemId == null )
                orderItem = new OrderItem();
            else
                orderItem = new OrderItem( order.Id, itemId.SafeValue() );
            orderItem.Name = "a";
            order.Add( orderItem );

            //添加订单项2
            OrderItem orderItem2;
            if ( itemId == null )
                orderItem2 = new OrderItem();
            else
                orderItem2 = new OrderItem( order.Id, itemId2.SafeValue() );
            orderItem2.Name = "b";
            order.Add( orderItem2 );

            return order;
        }

        #endregion

        #region 添加聚合对象

        /// <summary>
        /// 添加聚合对象
        /// </summary>
        [TestMethod]
        public void TestAdd() {
            //添加
            _orderRepository.Add( _order );

            //查找
            _orderRepository = Ioc.Create<IOrderRepository>();
            _order = _orderRepository.Find( _order.Id );

            //验证
            Assert.AreEqual( 2, _order.Items.Count );
        }

        #endregion

        #region 移除聚合子对象

        /// <summary>
        /// 移除聚合子对象
        /// </summary>
        [TestMethod]
        public void TestRemoveSub() {
            //添加
            _orderRepository.Add( _order );

            //查找
            _orderRepository = Ioc.Create<IOrderRepository>();
            _order = _orderRepository.Find( _order.Id );

            //移除第一个子项
            var item = _order.Items.First( t => t.Name == "a" );
            _order.Items.Remove( item );
            _orderRepository.Save();

            //查找
            _orderRepository = Ioc.Create<IOrderRepository>();
            _order = _orderRepository.Find( _order.Id );

            //验证
            Assert.AreEqual( 1, _order.Items.Count );
            Assert.AreEqual( "b", _order.Items.First().Name );
        }

        #endregion

        #region 批量操作

        /// <summary>
        /// 测试批量集合操作，批量添加、修改、删除子对象
        /// </summary>
        [TestMethod]
        public void TestSet_Batch() {
            //清空
            _orderRepository.Clear();

            //常量定义
            Guid? orderId = Sys.Guid;
            Guid? itemId = new Guid( "59BBE3D4-53C2-468F-AA11-3F9ED2C3A33A" );
            Guid? itemId2 = new Guid( "CACC3EF1-1C8A-4948-BF78-646D826B1BCA" );
            Guid? itemId3 = new Guid( "31EFBD08-3E57-4E82-BF3A-FE979B915972" );

            //初始化订单并添加
            var order = CreateOrder( orderId, itemId, itemId2 );
            _orderRepository.Add( order );

            //构造新订单,item1被删除，item2被修改，item3被新增
            _order = CreateOrder( orderId, itemId2, itemId3 );
            _order.Name = "order2";

            //更新订单
            _orderRepository = Ioc.Create<IOrderRepository>();
            var context = _orderRepository.GetUnitOfWork();
            context.Start();
            _orderRepository.Update( _order );
            context.Commit();

            //查找
            _orderRepository = Ioc.Create<IOrderRepository>();
            _order = _orderRepository.Find( orderId.SafeValue() );

            //验证
            Assert.AreEqual( "order2", _order.Name );
            Assert.AreEqual( 2, _order.Items.Count );
            Assert.AreEqual( "a", _order.Items.First( t => t.Id == itemId2 ).Name );
            Assert.AreEqual( "b", _order.Items.First( t => t.Id == itemId3 ).Name );
        }

        #endregion
    }
}
