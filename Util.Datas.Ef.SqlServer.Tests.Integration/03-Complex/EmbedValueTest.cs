using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 嵌入值映射测试
    /// </summary>
    [TestClass]
    public class EmbedValueTest {
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
        /// 测试添加嵌入值
        /// </summary>
        [TestMethod]
        public void TestAddEmbedValue() {
            _department.Init();
            _department.Address = new Address( "1", "2" );
            _departmentRepository.Add( _department );
            Assert.AreEqual( "1", _departmentRepository.Find( _department.Id ).Address.City );
        }
    }
}
