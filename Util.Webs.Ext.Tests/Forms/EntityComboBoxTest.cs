using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Factories;
using Util.Webs.Ext.Tests.Forms.Samples;

namespace Util.Webs.Ext.Tests.Forms {
    /// <summary>
    /// 实体组合框测试
    /// </summary>
    [TestClass]
    public class EntityComboBoxTest {
        /// <summary>
        /// 预期
        /// </summary>
        private Str _result;

        /// <summary>
        /// 文本框
        /// </summary>
        private IComboBox _combo;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _result = new Str();
            _combo = new ExtFactory<User>().CreateComboBox( t => t.Name );
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertEqual() {
            Assert.AreEqual( _result.ToString(), _combo.ToHtmlString() );
        }

        /// <summary>
        /// 测试
        /// </summary>
        [TestMethod]
        public void Test() {
            _result.Add( "{\"xtype\":\"combo\"," );
            _result.Add( "\"fieldLabel\":\"名称\"," );
            _result.Add( "\"allowBlank\":true," );
            _result.Add( "\"blankText\":\"用户名称不能为空\"" );
            _result.Add( "}" );
            AssertEqual();
        }
    }
}
