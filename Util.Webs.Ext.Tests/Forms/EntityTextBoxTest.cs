using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Factories;
using Util.Webs.Ext.Tests.Forms.Samples;

namespace Util.Webs.Ext.Tests.Forms {
    /// <summary>
    /// 实体文本框测试
    /// </summary>
    [TestClass]
    public class EntityTextBoxTest {
        /// <summary>
        /// 预期
        /// </summary>
        private Str _result;

        /// <summary>
        /// 文本框
        /// </summary>
        private ITextBox _textBox;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _result = new Str();
            _textBox = new ExtFactory<User>().CreateTextBox( t => t.Name ).Width( 100 );
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertEqual() {
            Assert.AreEqual( _result.ToString(), _textBox.ToHtmlString() );
        }

        /// <summary>
        /// 测试
        /// </summary>
        [TestMethod]
        public void Test() {
            _result.Add( "{" );
            _result.Add( "\"xtype\":\"textfield\"," );
            _result.Add( "\"width\":100," );
            _result.Add( "\"fieldLabel\":\"名称\"," );
            _result.Add( "\"allowBlank\":true," );
            _result.Add( "\"blankText\":\"用户名称不能为空\"" );
            _result.Add( "}" );
            AssertEqual();
        }
    }
}
