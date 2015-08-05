using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 员工映射
    /// </summary>
    public class EmployeeMap : AggregateMapBase<Employee> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "Employees", "Tests" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            base.MapProperties();
            Property( t => t.Id ).HasColumnName( "EmployeeId" ).HasDatabaseGeneratedOption( DatabaseGeneratedOption.None );
        }
    }
}
