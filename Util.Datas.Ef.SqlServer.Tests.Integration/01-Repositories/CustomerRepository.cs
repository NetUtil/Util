using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 客户仓储
    /// </summary>
    public class CustomerRepository : RepositoryBase<Customer, int>, ICustomerRepository {
        /// <summary>
        /// 初始化客户仓储
        /// </summary>
        /// <param name="context">数据上下文</param>
        public CustomerRepository( IUnitOfWork context )
            : base( context ) {
        }

        /// <summary>
        /// 添加客户,并且未提交
        /// </summary>
        /// <param name="customer">客户</param>
        public void AddCustomerByNotCommit( Customer customer ) {
            Context.Customers.Add( customer );
        }
    }
}
