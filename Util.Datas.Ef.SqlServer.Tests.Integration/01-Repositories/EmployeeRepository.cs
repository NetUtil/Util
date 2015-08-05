using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 员工仓储
    /// </summary>
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository {
        /// <summary>
        /// 初始化员工仓储
        /// </summary>
        /// <param name="context">数据上下文</param>
        public EmployeeRepository( IUnitOfWork context ) 
            : base( context ){
        }
    }
}
