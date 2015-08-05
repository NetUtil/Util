using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 测试在同一实例上的多数据库事务
    /// </summary>
    [TestClass]
    public class MultiDbTest {
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee;
        /// <summary>
        /// 员工仓储
        /// </summary>
        private IEmployeeRepository _employeeRepository;
        /// <summary>
        /// 员工2
        /// </summary>
        private Employee _employee2;
        /// <summary>
        /// 员工仓储2
        /// </summary>
        private IEmployeeRepository _employeeRepository2;
        /// <summary>
        /// 部门
        /// </summary>
        private Department _department;
        /// <summary>
        /// 部门仓储
        /// </summary>
        private IDepartmentRepository _departmentRepository;
        /// <summary>
        /// 数据上下文
        /// </summary>
        private IUnitOfWork _context;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            var context = Helper.GetEfContext();
            _employee = Employee.GetEmployee();
            _employee2 = Employee.GetEmployee2();
            _employeeRepository = new EmployeeRepository( context );
            _employeeRepository2 = new EmployeeRepository( Helper.GetEfContext2() );
            _department = Department.GetDepartment();
            _departmentRepository = new DepartmentRepository( context );
            _context = _employeeRepository.GetUnitOfWork();
        }

        /// <summary>
        /// 不在同一事务中,前一部分提交成功
        /// </summary>
        [TestMethod]
        public void TestTransaction_PartialSuccess() {
            try {
                _context.Start();
                _employeeRepository.Add( _employee );
                _departmentRepository.Add( _department );
                _context.Commit();
                throw new Exception();
                _employeeRepository2.Add( _employee2 );
            }
            catch {
                _employeeRepository = Ioc.Create<IEmployeeRepository>();
                _departmentRepository = Ioc.Create<IDepartmentRepository>();
                Assert.IsNotNull( _employeeRepository.Find( _employee.Id ) );
                Assert.IsNotNull( _departmentRepository.Find( _department.Id ) );
            }
        }

        /// <summary>
        /// 在同一事务中,所有操作失败
        /// </summary>
        [TestMethod]
        public void TestTransaction_AllFail() {
            try {
                using( TransactionScope scope = new TransactionScope() ) {
                    _context.Start();
                    _employeeRepository.Add( _employee );
                    _departmentRepository.Add( _department );
                    _context.Commit();
                    throw new Exception();
                    _employeeRepository2.Add( _employee2 );
                    scope.Complete();
                }
            }
            catch {
                _employeeRepository = Ioc.Create<IEmployeeRepository>();
                Assert.IsNull( _employeeRepository.Find( _employee.Id ) );
            }
        }

        /// <summary>
        /// 在同一事务中,所有操作成功
        /// </summary>
        [TestMethod]
        public void TestTransaction_AllSuccess() {
            using ( TransactionScope scope = new TransactionScope() ) {
                _context.Start();
                _employeeRepository.Add( _employee );
                _departmentRepository.Add( _department );
                _context.Commit();
                _employeeRepository2.Add( _employee2 );
                scope.Complete();
            }
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            Assert.IsNotNull( _employeeRepository.Find( _employee.Id ) );
            _employeeRepository2 = new EmployeeRepository( Helper.GetEfContext2() );
            Assert.IsNotNull( _employeeRepository2.Find( _employee2.Id ) );
        }
    }
}
