using System.ComponentModel.DataAnnotations.Schema;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 部门映射
    /// </summary>
    public class DepartmentMap : AggregateMapBase<Department,string>{
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "Departments", "Tests" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            base.MapProperties();
            Property( t => t.Id ).HasColumnName( "DepartmentId" ).HasDatabaseGeneratedOption( DatabaseGeneratedOption.None );
        }
    }
}
