using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Domains.Tests.Sample;
using Util.Validations;

namespace Util.Domains.Tests.Validations {
    /// <summary>
    /// 必填项测试
    /// </summary>
    [TestClass]
    public class RequiredTest {
        /// <summary>
        /// 客户
        /// </summary>
        private Customer _customer;
        /// <summary>
        /// 验证操作
        /// </summary>
        private IValidation _validation;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _customer = Customer.GetCustomer();
            _validation = new Validation();
        }

        /// <summary>
        /// 验证必填项，通过字符串设置错误消息
        /// </summary>
        [TestMethod]
        public void TestValidateEnglishName_Required_ErrorMessage() {
            _customer.EnglishName = null;
            var result = _validation.Validate( _customer );
            Assert.AreEqual( "英文名不能为空", result.First().ErrorMessage );
        }

        /// <summary>
        /// 验证必填项，通过字符串设置错误消息
        /// </summary>
        [TestMethod]
        public void TestValidateEnglishName_Required_ErrorMessage_2() {
            _validation = new Validation2();
            _customer.EnglishName = null;
            var result = _validation.Validate( _customer );
            Assert.AreEqual( "英文名不能为空", result.First().ErrorMessage );
        }

        /// <summary>
        /// 验证必填项，通过资源文件设置错误消息
        /// </summary>
        [TestMethod]
        public void TestValidateName_Required_ErrorMessageResource() {
            _customer.Name = "  ";
            var result = _validation.Validate( _customer );
            Assert.AreEqual( TestDomainResource.CustomerNameIsEmpty, result.First().ErrorMessage ); 
        }

        /// <summary>
        /// 验证必填项，通过资源文件设置错误消息
        /// </summary>
        [TestMethod]
        public void TestValidateAge_Required() {
            _customer.Age = null;
            var result = _validation.Validate( _customer );
            Assert.AreEqual( TestDomainResource.AgeIsEmpty, result.First().ErrorMessage );
        }

        /// <summary>
        /// 验证个数
        /// </summary>
        [TestMethod]
        public void TestValidate_Count() {
            _customer.EnglishName = null;
            _customer.Name = "  ";
            _customer.Age = null;
            var result = _validation.Validate( _customer );
            Assert.AreEqual( 3, result.Count );
        }
    }
}
