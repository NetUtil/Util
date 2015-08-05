using Autofac;
using Util.DI.Autofac;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 依赖注入配置
    /// </summary>
    public class IocConfig : ConfigBase {
        protected override void Load( ContainerBuilder builder ) {
            base.Load( builder );
            builder.RegisterType<TestDbContext>().As<IUnitOfWork>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
        }
    }
}
