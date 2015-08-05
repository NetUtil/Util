using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 部门仓储
    /// </summary>
    public class DepartmentRepository : Repository<Department,string>, IDepartmentRepository{
        /// <summary>
        /// 初始化部门仓储
        /// </summary>
        /// <param name="context">数据上下文</param>
        public DepartmentRepository( IUnitOfWork context )
            : base( context ) {
        }
    }
}
