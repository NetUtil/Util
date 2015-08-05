using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 订单映射
    /// </summary>
    public class OrderMap : AggregateMapBase<Order>{
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "Orders", "Tests" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            base.MapProperties();
            Property( t => t.Id ).HasColumnName( "OrderId" ).HasDatabaseGeneratedOption( DatabaseGeneratedOption.None );
        }
    }
}
