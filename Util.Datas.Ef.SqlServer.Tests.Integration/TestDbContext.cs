using System.Data.Entity;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 测试数据上下文
    /// </summary>
    public class TestDbContext : EfUnitOfWork {
        /// <summary>
        /// 设置数据上下文初始设定项
        /// </summary>
        static TestDbContext() {
            Database.SetInitializer<TestDbContext>( null );
        }

        /// <summary>
        /// 初始化测试数据上下文
        /// </summary>
        public TestDbContext()
            : base( "Test" ) {
        }

        /// <summary>
        /// 客户集合
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// 员工集合
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// 部门集合
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// 订单集合
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// 订单项集合
        /// </summary>
        public DbSet<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// 添加模型映射
        /// </summary>
        /// <param name="builder">模型生成器</param>
        protected override void OnModelCreating( DbModelBuilder builder ) {
            base.OnModelCreating( builder );
            builder.Ignore<NullCustomer>();
        }
    }
}
