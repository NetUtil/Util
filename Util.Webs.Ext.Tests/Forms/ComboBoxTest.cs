using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Controls.Forms;

namespace Util.Webs.Ext.Tests.Forms {
    /// <summary>
    /// 组合框测试
    /// </summary>
    [TestClass]
    public class ComboBoxTest {

        #region 测试初始化

        /// <summary>
        /// 预期
        /// </summary>
        private Str _result;

        /// <summary>
        /// 文本框
        /// </summary>
        private ComboBox _combo;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _result = new Str();
            _combo = new ComboBox();
        }

        /// <summary>
        /// 创建预期结果
        /// </summary>
        private void CreateResult( Action<Str> handler ) {
            _result.Add( "{\"xtype\":\"combo\"," );
            handler( _result );
            _result.Add( "}" );
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertEqual() {
            Assert.AreEqual( _result.ToString(), _combo.ToHtmlString() );
        }

        #endregion

        #region TestLabel(标签文本)

        /// <summary>
        /// 测试标签文本
        /// </summary>
        [TestMethod]
        public void TestLabel() {
            _combo.Label( "a" );
            CreateResult( t => t.Add( "\"fieldLabel\":\"a\"" ) );
            AssertEqual();
        }

        #endregion
    }
}
