using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 客户映射
    /// </summary>
    public class CustomerMap : AggregateMapBase<Customer,int> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "Customers", "Tests" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            base.MapProperties();
            Property( t => t.Id ).HasColumnName( "CustomerId" ).HasDatabaseGeneratedOption( DatabaseGeneratedOption.Identity );
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected override void MapAssociations() {
            base.HasOptional( t => t.Employee )
                .WithMany( t => t.Customers )
                .HasForeignKey( t => t.EmployeeId );
        }
    }
}
