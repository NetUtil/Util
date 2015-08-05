using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 订单仓储
    /// </summary>
    public class OrderRepository : Repository<Order>,IOrderRepository {
        /// <summary>
        /// 初始化订单仓储
        /// </summary>
        /// <param name="context">数据上下文</param>
        public OrderRepository( IUnitOfWork context )
            : base( context ){
        }

        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="entity">订单</param>
        public override void Update( Order entity ) {
            var dbEntity = Find( entity.Id );
            dbEntity.Merge( entity );
            ChangeGrouping<OrderItem> grouping = new ChangeGrouping<OrderItem>( entity.Items, dbEntity.Items );
            dbEntity.Add( grouping.GetNewEntities() );
            dbEntity.Remove( grouping.GetDeleteEntities() );
            dbEntity.Update( grouping.GetUpdateEntities() );
        }

        /// <summary>
        /// 清空
        /// </summary>
        public override void Clear() {
            UnitOfWork.Start();
            base.Clear();
            foreach( var item in UnitOfWork.Set<OrderItem>() )
                UnitOfWork.Set<OrderItem>().Remove( item );
            UnitOfWork.Commit();
        }
    }
}
