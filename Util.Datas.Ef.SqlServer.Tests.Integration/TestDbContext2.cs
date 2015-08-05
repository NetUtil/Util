using System;
using System.Data.Entity;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 测试数据上下文2
    /// </summary>
    public class TestDbContext2 : EfUnitOfWork {
        /// <summary>
        /// 设置数据上下文初始设定项
        /// </summary>
        static TestDbContext2() {
            Database.SetInitializer<TestDbContext2>( null );
        }

        /// <summary>
        /// 初始化测试数据上下文
        /// </summary>
        public TestDbContext2()
            : base( "Test2" ) {
            Console.WriteLine( "创建工作单元:{0}",Guid.NewGuid() );
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
        /// 添加模型映射
        /// </summary>
        /// <param name="builder">模型生成器</param>
        protected override void OnModelCreating( DbModelBuilder builder ) {
            builder.Configurations.Add( new CustomerMap() );
            builder.Configurations.Add( new EmployeeMap() );
            builder.Ignore<NullCustomer>();
        }
    }
}
