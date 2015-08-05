using Util.Domains;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体键类型</typeparam>
    public class RepositoryBase<TEntity, TKey> : Repository<TEntity, TKey> where TEntity : AggregateRoot<TEntity, TKey> {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="context">数据上下文</param>
        public RepositoryBase( IUnitOfWork context )
            : base( context ) {
            Context = (TestDbContext)context;
        }

        /// <summary>
        /// 数据上下文
        /// </summary>
        protected TestDbContext Context { get; set; }
    }
}
