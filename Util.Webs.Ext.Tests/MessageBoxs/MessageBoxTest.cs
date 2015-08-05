using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Controls.MessageBoxs;

namespace Util.Webs.Ext.Tests.MessageBoxs {
    /// <summary>
    /// 消息框测试
    /// </summary>
    [TestClass]
    public class MessageBoxTest {
        /// <summary>
        /// ext服务
        /// </summary>
        private IMessageBox _messageBox;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _messageBox = new MessageBox();
        }

        /// <summary>
        /// 获取消息框输出结果，仅设置标题为A
        /// </summary>
        public static string GetResult_Title_A() {
            Str result = new Str();
            result.Add( "Ext.Msg.show({" );
            result.Add( "\"title\":\"a\"," );
            result.Add( "\"msg\":null," );
            result.Add( "\"buttons\":Ext.MessageBox.OK," );
            result.Add( "\"closable\":true," );
            result.Add( "\"modal\":true," );
            result.Add( "\"icon\":Ext.MessageBox.INFO" );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 获取消息框输出结果，设置标题为A,设置内容为B
        /// </summary>
        public static string GetResult_TitleA_ContentB() {
            Str result = new Str();
            result.Add( "Ext.Msg.show({" );
            result.Add( "\"title\":\"a\"," );
            result.Add( "\"msg\":\"b\"," );
            result.Add( "\"buttons\":Ext.MessageBox.OK," );
            result.Add( "\"closable\":true," );
            result.Add( "\"modal\":true," );
            result.Add( "\"icon\":Ext.MessageBox.INFO" );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 获取输出结果，设置标题为A,设置内容为B，回调为C
        /// </summary>
        public static string GetResult_TitleA_ContentB_CallbackC() {
            Str result = new Str();
            result.Add( "Ext.Msg.show({" );
            result.Add( "\"title\":\"a\"," );
            result.Add( "\"msg\":\"b\"," );
            result.Add( "\"buttons\":Ext.MessageBox.OK," );
            result.Add( "\"fn\":c," );
            result.Add( "\"closable\":true," );
            result.Add( "\"modal\":true," );
            result.Add( "\"icon\":Ext.MessageBox.INFO" );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        public static string GetResult_All() {
            Str result = new Str();
            result.Add( "Ext.Msg.show({" );
            result.Add( "\"title\":\"a\"," );
            result.Add( "\"msg\":\"b\"," );
            result.Add( "\"width\":100," );
            result.Add( "\"buttons\":Ext.MessageBox.YESNOCANCEL," );
            result.Add( "\"fn\":c," );
            result.Add( "\"animEl\":\"div1\"," );
            result.Add( "\"closable\":false," );
            result.Add( "\"modal\":false," );
            result.Add( "\"prompt\":true," );
            result.Add( "\"multiline\":true," );
            result.Add( "\"icon\":Ext.MessageBox.ERROR," );
            result.Add( "\"value\":\"d\"" );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 获取结果，带返回变量
        /// </summary>
        public static string GetResult_VariableName() {
            Str result = new Str();
            result.Add( "var msg = Ext.Msg.show({" );
            result.Add( "\"title\":\"a\"," );
            result.Add( "\"msg\":null," );
            result.Add( "\"buttons\":Ext.MessageBox.OK," );
            result.Add( "\"closable\":true," );
            result.Add( "\"modal\":true," );
            result.Add( "\"icon\":Ext.MessageBox.INFO" );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 获取结果，带按钮文本
        /// </summary>
        public static string GetResult_ButtonText() {
            Str result = new Str();
            result.Add( "Ext.Msg.buttonText.cancel='不干了';" );
            result.Add( "Ext.Msg.show({" );
            result.Add( "\"title\":\"a\"," );
            result.Add( "\"msg\":null," );
            result.Add( "\"buttons\":Ext.MessageBox.OK," );
            result.Add( "\"closable\":true," );
            result.Add( "\"modal\":true," );
            result.Add( "\"icon\":Ext.MessageBox.INFO" );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 获取隐藏消息框结果
        /// </summary>
        public static string GetResult_Hide() {
            return "Ext.Msg.hide();";
        }

        /// <summary>
        /// 仅设置标题
        /// </summary>
        [TestMethod]
        public void TestMsg_Title() {
            _messageBox.Title( "a" );
            Assert.AreEqual( GetResult_Title_A(), _messageBox.ToHtmlString() );
        }

        /// <summary>
        /// 设置标题和内容
        /// </summary>
        [TestMethod]
        public void TestMsg_Title_Content() {
            _messageBox.Title( "a" );
            _messageBox.Content( "b" );
            Assert.AreEqual( GetResult_TitleA_ContentB(), _messageBox.ToHtmlString() );
        }

        /// <summary>
        /// 设置标题、内容、回调
        /// </summary>
        [TestMethod]
        public void TestMsg_Title_Content_Callback() {
            _messageBox.Title( "a" );
            _messageBox.Content( "b" );
            _messageBox.Handler( "c" );
            Assert.AreEqual( GetResult_TitleA_ContentB_CallbackC(), _messageBox.ToHtmlString() );
        }

        /// <summary>
        /// 设置所有选项
        /// </summary>
        [TestMethod]
        public void TestMsg_All() {
            _messageBox.Title( "a" );
            _messageBox.Content( "b" );
            _messageBox.Handler( "c" );
            _messageBox.Width( 100 );
            _messageBox.Anime( "div1" );
            _messageBox.Button( MessageBoxButton.YesNoCancel );
            _messageBox.Icon( MessageBoxIcon.Error );
            _messageBox.Modal( false );
            _messageBox.ShowClose( false );
            _messageBox.Prompt( true );
            _messageBox.Value( "d" );
            Assert.AreEqual( GetResult_All(), _messageBox.ToHtmlString() );
        }

        /// <summary>
        /// 设置返回的变量
        /// </summary>
        [TestMethod]
        public void TestMsg_Id() {
            _messageBox.Title( "a" );
            _messageBox.Id( "msg" );
            Assert.AreEqual( GetResult_VariableName(), _messageBox.ToHtmlString() );
        }

        /// <summary>
        /// 设置按钮文本
        /// </summary>
        [TestMethod]
        public void TestMsg_ButtonText() {
            _messageBox.Title( "a" );
            _messageBox.ButtonText( MessageBoxButtonType.Cancel, "不干了" );
            Assert.AreEqual( GetResult_ButtonText(), _messageBox.ToHtmlString() );
        }
    }
}
