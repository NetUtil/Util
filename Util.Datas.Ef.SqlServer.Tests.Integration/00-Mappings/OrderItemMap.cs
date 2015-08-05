using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 订单项映射
    /// </summary>
    public class OrderItemMap : EntityMapBase<OrderItem> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "OrderItems", "Tests" );
        }

        /// <summary>
        /// 映射标识
        /// </summary>
        protected override void MapId() {
            HasKey( t => new { t.Id, t.OrderId } );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            Property( t => t.Id ).HasColumnName( "ItemId" );
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected override void MapAssociations() {
            HasRequired( t => t.Order )
                .WithMany( t => t.Items )
                .HasForeignKey( t => t.OrderId );
        }
    }
}
