using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;
using Util.Exceptions;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 测试单线程多次提交的情况
    /// </summary>
    [TestClass]
    public class MultiSubmitTest {
        /// <summary>
        /// 部门
        /// </summary>
        private Department _department;
        /// <summary>
        /// 部门仓储
        /// </summary>
        private IDepartmentRepository _repository;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _department = Department.GetDepartment();
            _repository = Ioc.Create<IDepartmentRepository>();
            _repository.Clear();
            _repository.Add( _department );
        }

        /// <summary>
        /// 1. 目标：测试单线程多次提交
        /// 2. 场景：从仓储中获取实体，修改实体并提交，再次修改实体并提交
        /// 3. 预期：引发异常
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ConcurrencyException ) )]
        public void Test() {
            //查找部门
            _repository = Ioc.Create<IDepartmentRepository>();
            _department = _repository.Find( _department.Id );

            //复制部门
            Department department = _department.Copy();
            Department department2 = _department.Copy();

            //修改第一个部门并提交
            _repository = Ioc.Create<IDepartmentRepository>();
            department.Name = "A";
            _repository.Update( department );

            //修改第2个部门并提交
            _repository = Ioc.Create<IDepartmentRepository>();
            department2.Name = "B";
            _repository.Update( department2 );
        }

        /// <summary>
        /// 通过修改属性的方式不会引发乐观并发异常
        /// </summary>
        [TestMethod]
        public void Test_2() {
            //查找部门
            _repository = Ioc.Create<IDepartmentRepository>();
            _department = _repository.Find( _department.Id );

            //复制部门
            Department department = _department.Copy();

            //修改部门
            _department.Name = "A";
            _repository.Save();

            //修改第一个部门并提交
            _repository = Ioc.Create<IDepartmentRepository>();
            var dbEntity = _repository.Find( department.Id );
            dbEntity.Name = "B";
            dbEntity.Version = department.Version;
            _repository.Save();
        }

        /// <summary>
        /// 通过CurrentValues.SetValues的方式不会引发乐观并发异常
        /// </summary>
        [TestMethod]
        public void Test_3() {
            //查找部门
            _repository = Ioc.Create<IDepartmentRepository>();
            _department = _repository.Find( _department.Id );

            //复制部门
            Department department = _department.Copy();

            //修改部门
            _department.Name = "A";
            _repository.Save();

            //修改第一个部门并提交
            _repository = Ioc.Create<IDepartmentRepository>();
            var dbEntity = _repository.Find( department.Id );
            dbEntity.Name = "B";
            _repository.Update( department, dbEntity );
        }
    }
}
