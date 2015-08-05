using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 测试单数据库事务
    /// </summary>
    [TestClass]
    public class SingleDbTest {
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee;
        /// <summary>
        /// 员工仓储
        /// </summary>
        private IEmployeeRepository _employeeRepository;
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
            _employeeRepository = new EmployeeRepository( context );
            _department = Department.GetDepartment();
            _departmentRepository = new DepartmentRepository( context );
            _context = _departmentRepository.GetUnitOfWork();
        }

        /// <summary>
        /// 使用相同数据上下文，通过BeginTransaction和Commit即可控制事务
        /// </summary>
        [TestMethod]
        public void TestTransaction_SameContext() {
            try {
                _context.Start();
                _employeeRepository.Add( _employee );
                throw new Exception();
                _departmentRepository.Add( _department );
                _context.Commit();
            }
            catch {
                _employeeRepository = Ioc.Create<IEmployeeRepository>();
                Assert.IsNull( _employeeRepository.Find( _employee.Id ) );
            }
        }

        /// <summary>
        /// 使用不同数据上下文，使用TransactionScope控制事务,全部失败
        /// </summary>
        [TestMethod]
        public void TestTransaction_DifferentContext_AllFail() {
            _departmentRepository = new DepartmentRepository( Helper.GetEfContext() );
            try {
                using ( TransactionScope scope = new TransactionScope() ) {
                    _employeeRepository.Add( _employee );
                    throw new Exception();
                    _departmentRepository.Add( _department );
                    scope.Complete();
                }
            }
            catch {
                _employeeRepository = Ioc.Create<IEmployeeRepository>();
                Assert.IsNull( _employeeRepository.Find( _employee.Id ) );
            }
        }

        /// <summary>
        /// 使用不同数据上下文，使用TransactionScope控制事务,全部保存成功
        /// </summary>
        [TestMethod]
        public void TestTransaction_DifferentContext_AllSuccess() {
            _departmentRepository = new DepartmentRepository( Helper.GetEfContext() );
            using ( TransactionScope scope = new TransactionScope() ) {
                _employeeRepository.Add( _employee );
                _departmentRepository.Add( _department );
                scope.Complete();
            }
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            Assert.IsNotNull( _employeeRepository.Find( _employee.Id ) );
            _departmentRepository = Ioc.Create<IDepartmentRepository>();
            Assert.IsNotNull( _departmentRepository.Find( _department.Id ) );
        }
    }
}
