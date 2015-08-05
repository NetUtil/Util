using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 测试字符串标识实体
    /// </summary>
    [TestClass]
    public class StringEntityTest {
        /// <summary>
        /// 部门
        /// </summary>
        private Department _department;
        /// <summary>
        /// 部门仓储
        /// </summary>
        private IDepartmentRepository _departmentRepository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _department = Department.GetDepartment();
            _departmentRepository = Ioc.Create<IDepartmentRepository>();
        }

        /// <summary>
        /// 测试添加部门 - 字符串类型标识
        /// </summary>
        [TestMethod]
        public void TestAddDepartment() {
            _departmentRepository.Add( _department );
            Assert.IsNotNull( _departmentRepository.Find( _department.Id ) ); 
        }
    }
}
