using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Controls.Forms;

namespace Util.Webs.Ext.Tests.Forms {
    /// <summary>
    /// 文本框测试
    /// </summary>
    [TestClass]
    public class TextBoxTest {

        #region 测试初始化

        /// <summary>
        /// 预期
        /// </summary>
        private Str _result;

        /// <summary>
        /// 文本框
        /// </summary>
        private TextBox _textBox;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _result = new Str();
            _textBox = new TextBox();
        }

        /// <summary>
        /// 创建预期结果
        /// </summary>
        private void CreateResult( Action<Str> handler ) {
            _result.Add( "{\"xtype\":\"textfield\"," );
            handler( _result );
            _result.Add( "}" );
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertEqual() {
            Assert.AreEqual( _result.ToString(), _textBox.ToHtmlString() );
        }

        #endregion

        #region TestLabel(标签文本)

        /// <summary>
        /// 测试标签文本
        /// </summary>
        [TestMethod]
        public void TestLabel() {
            _textBox.Label( "a" );
            CreateResult( t => t.Add( "\"fieldLabel\":\"a\"" ) );
            AssertEqual();
        }

        /// <summary>
        /// 测试标签文本
        /// </summary>
        [TestMethod]
        public void TestLabel_Separator() {
            _textBox.Label( "a","b" );
            CreateResult( t => {
                t.Add( "\"fieldLabel\":\"a\"," );
                t.Add( "\"labelSeparator\":\"b\"" );
            } );
            AssertEqual();
        }

        /// <summary>
        /// 测试标签文本
        /// </summary>
        [TestMethod]
        public void TestLabel_Blank() {
            _textBox.Label( " " );
            CreateResult( t => t.Add( "\"fieldLabel\":\" \"" ) );
            AssertEqual();
        }

        #endregion

        #region TestValidation(验证)

        /// <summary>
        /// 验证允许为空
        /// </summary>
        [TestMethod]
        public void TestValidation_Required() {
            _textBox.Required( "a" );
            CreateResult( t => {
                t.Add( "\"allowBlank\":true," );
                t.Add( "\"blankText\":\"a\"" );
            } );
            AssertEqual();
        }

        #endregion
    }
}
