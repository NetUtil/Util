using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Webs.Ext.Tests.Toolbars {
    /// <summary>
    /// 工具栏按钮测试
    /// </summary>
    public partial class ToolbarTest {
        /// <summary>
        /// 创建1个按钮 - 重载1
        /// </summary>
        [TestMethod]
        public void TestButton_1_1() {
            _toolbar.Button( "新建", "showBox" );
            Assert.AreEqual( GetButtonScript_1(), _toolbar.ToHtmlString() );
        }

        /// <summary>
        /// 获取脚本
        /// </summary>
        public static string GetButtonScript_1() {
            Str result = new Str();
            result.Add( "var toolbar = new Ext.Toolbar({\"id\":\"toolbar\"});" );
            result.Add( "toolbar.add(" );
            result.Add( "{\"text\":\"新建\",\"handler\":showBox}" );
            result.Add( ");" );
            return result.ToString();
        }


        /// <summary>
        /// 创建1个按钮 - 重载3
        /// </summary>
        [TestMethod]
        public void TestButton_1_3() {
            _toolbar.Button( "新建", "showBox", "a" );
            Assert.AreEqual( GetButtonScript_1_2(), _toolbar.ToHtmlString() );
        }

        /// <summary>
        /// 获取脚本
        /// </summary>
        public static string GetButtonScript_1_2() {
            Str result = new Str();
            result.Add( "var toolbar = new Ext.Toolbar({\"id\":\"toolbar\"});" );
            result.Add( "toolbar.add(" );
            result.Add( "{\"text\":\"新建\",\"iconCls\":\"a\",\"handler\":showBox}" );
            result.Add( ");" );
            return result.ToString();
        }

        /// <summary>
        /// 创建2个按钮
        /// </summary>
        [TestMethod]
        public void TestButton_2() {
            _toolbar.Button( "新建", "new" );
            _toolbar.Button( "修改", "update" );
            Assert.AreEqual( GetButtonScript_2(), _toolbar.ToHtmlString() );
        }

        /// <summary>
        /// 获取脚本
        /// </summary>
        public static string GetButtonScript_2() {
            Str result = new Str();
            result.Add( "var toolbar = new Ext.Toolbar({\"id\":\"toolbar\"});" );
            result.Add( "toolbar.add(" );
            result.Add( "{\"text\":\"新建\",\"handler\":new}," );
            result.Add( "{\"text\":\"修改\",\"handler\":update}" );
            result.Add( ");" );
            return result.ToString();
        }

        /// <summary>
        /// 设置渲染目标Id
        /// </summary>
        [TestMethod]
        public void TestButton_Render() {
            _toolbar.RenderTo( "div1" );
            _toolbar.Button( "新建", "new" );
            Str result = new Str();
            result.Add( "var toolbar = new Ext.Toolbar({\"id\":\"toolbar\",\"renderTo\":\"div1\"});" );
            result.Add( "toolbar.add(" );
            result.Add( "{\"text\":\"新建\",\"handler\":new}" );
            result.Add( ");" );
            Assert.AreEqual( result.ToString(), _toolbar.ToHtmlString() );
        }
    }
}
