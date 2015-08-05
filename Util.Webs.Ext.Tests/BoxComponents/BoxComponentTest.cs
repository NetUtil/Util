using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Controls.BoxComponents;

namespace Util.Webs.Ext.Tests.BoxComponents {
    /// <summary>
    /// BoxComponent测试
    /// </summary>
    [TestClass]
    public class BoxComponentTest {

        #region 测试初始化

        /// <summary>
        /// 盒子组件
        /// </summary>
        private BoxComponent _box;

        /// <summary>
        /// 预期
        /// </summary>
        private Str _result;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _box = new BoxComponent();
            _box.Id( "box" );
            _result = new Str();
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        private void CreateResult( Action<Str> handler ) {
            _result.Add( "var box = new Ext.BoxComponent({" );
            _result.Add( "\"id\":\"box\"," );
            handler.Invoke( _result );
            _result.Add( "});" );
        }

        /// <summary>
        /// 断言
        /// </summary>
        private void AssertEqual() {
            Assert.AreEqual( _result.ToString(), _box.ToHtmlString() );
        }

        #endregion

        #region TestLoadContent(加载内容)

        /// <summary>
        /// 测试加载内容
        /// </summary>
        [TestMethod]
        public void TestLoadContent() {
            _box.LoadContent( "div1" );
            CreateResult( t => t.Add( "\"el\":\"div1\"" ) );
            AssertEqual();
        }

        #endregion

        #region TestRegion(区域)

        /// <summary>
        /// 测试区域
        /// </summary>
        [TestMethod]
        public void TestRegion() {
            _box.Region( Region.Left );
            CreateResult( t => t.Add( "\"region\":\"west\"" ) );
            AssertEqual();
        }

        #endregion
    }
}
