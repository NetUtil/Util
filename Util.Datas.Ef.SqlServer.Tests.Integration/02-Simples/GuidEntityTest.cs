using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 测试Guid标识实体
    /// </summary>
    [TestClass]
    public class GuidEntityTest {
        /// <summary>
        /// 员工
        /// </summary>
        private Employee _employee;
        /// <summary>
        /// 员工仓储
        /// </summary>
        private IEmployeeRepository _employeeRepository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _employee = Employee.GetEmployee();
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
        }

        /// <summary>
        /// 添加，标识查找，索引器查找，移除对象
        /// </summary>
        [TestMethod]
        public void TestAdd_Find_Index_Remove() {
            //添加
            _employeeRepository.Add( _employee );

            //标识查找
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            _employee = _employeeRepository.Find( _employee.Id );
            Assert.IsNotNull( _employee );

            //移除
            _employeeRepository.Remove( _employee );

            //索引器查找
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            Assert.IsNull( _employeeRepository[_employee.Id] );
        }

        /// <summary>
        /// 按标识移除实体
        /// </summary>
        [TestMethod]
        public void TestRemove_Id() {
            //添加
            _employeeRepository.Add( _employee );

            //标识查找
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            Assert.IsNotNull( _employeeRepository.Find( _employee.Id ) );

            //移除
            _employeeRepository.Remove( _employee.Id );

            //索引器查找
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            Assert.IsNull( _employeeRepository[_employee.Id] );
        }

        /// <summary>
        /// 修改实体，第1种方法，通过查找方式修改
        /// </summary>
        [TestMethod]
        public void TestUpdate_1() {
            //添加
            _employeeRepository.Add( _employee );

            //标识查找
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            _employee = _employeeRepository.Find( _employee.Id );

            //修改并提交
            _employee.Name = "A";
            _employeeRepository.Save();

            //标识查找
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            _employee = _employeeRepository.Find( _employee.Id );

            //验证
            Assert.AreEqual( "A", _employee.Name );
        }

        /// <summary>
        /// 修改实体，第2种方法，通过附加方式修改
        /// </summary>
        [TestMethod]
        public void TestUpdate_2() {
            //添加
            _employeeRepository.Add( _employee );

            //创建新对象并附加
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            _employee = _employee.Copy();
            _employee.Name = "A";
            _employeeRepository.Update( _employee );

            //标识查找
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            _employee = _employeeRepository.Find( _employee.Id );

            //验证
            Assert.AreEqual( "A", _employee.Name );
        }

        /// <summary>
        /// 修改实体，验证先查找后附加
        /// </summary>
        [TestMethod]
        public void TestUpdate_3() {
            //添加
            _employeeRepository.Add( _employee );

            //标识查找
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            _employee = _employeeRepository.Find( _employee.Id );

            //修改并提交
            _employee.Name = "A";
            _employeeRepository.Update( _employee );

            //标识查找
            _employeeRepository = Ioc.Create<IEmployeeRepository>();
            _employee = _employeeRepository.Find( _employee.Id );

            //验证
            Assert.AreEqual( "A", _employee.Name );
        }
    }
}
