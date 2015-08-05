using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Tests.MessageBoxs;

namespace Util.Webs.Ext.Tests.ExtServices {
    /// <summary>
    /// 消息框测试
    /// </summary>
    public partial class ExtServiceTest {
        /// <summary>
        /// 获取Alert结果，设置标题为A，内容为B
        /// </summary>
        /// <param name="func">回调函数</param>
        public static string GetResult_Alert_TitleA_ContentB( string func = "" ) {
            Str result = new Str();
            result.Add( "Ext.Msg.show({" );
            result.Add( "\"title\":\"a\"," );
            result.Add( "\"msg\":\"b\"," );
            result.Add( "\"buttons\":Ext.MessageBox.OK," );
            if ( func.IsEmpty() == false )
                result.Add( "\"fn\":{0},", func );
            result.Add( "\"closable\":true," );
            result.Add( "\"modal\":true," );
            result.Add( "\"icon\":Ext.MessageBox.INFO" );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 获取Confirm输出结果
        /// </summary>
        public static string GetResult_Confirm() {
            return "Ext.Msg.confirm(\"a\",\"b\",c);";
        }

        /// <summary>
        /// 获取Prompt输出结果
        /// </summary>
        public static string GetReuslt_Prompt( bool isMultiLine ) {
            Str result = new Str();
            result.Add( "Ext.Msg.show({" );
            result.Add( "\"title\":\"a\"," );
            result.Add( "\"msg\":\"b\"," );
            result.Add( "\"width\":400," );
            result.Add( "\"buttons\":Ext.MessageBox.OKCANCEL," );
            result.Add( "\"fn\":c," );
            result.Add( "\"closable\":true," );
            result.Add( "\"modal\":true," );
            result.Add( "\"prompt\":true," );
            result.Add( "\"multiline\":{0},", isMultiLine.ToString().ToLower() );
            result.Add( "\"icon\":Ext.MessageBox.INFO" );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 测试Alert弹出消息框
        /// </summary>
        [TestMethod]
        public void TestAlert() {
            Assert.AreEqual( GetResult_Alert_TitleA_ContentB(), _service.Alert( "a", "b" ).ToString() );
        }

        /// <summary>
        /// 测试Alert弹出消息框,带回调函数
        /// </summary>
        [TestMethod]
        public void TestAlert_Callback() {
            Assert.AreEqual( GetResult_Alert_TitleA_ContentB( "func" ), _service.Alert( "a", "b", "func" ).ToString() );
        }

        /// <summary>
        /// 测试Prompt弹出输入确认框-单行文本框
        /// </summary>
        [TestMethod]
        public void TestPrompt() {
            Assert.AreEqual( GetReuslt_Prompt(false), _service.Prompt( "a", "b", "c" ).ToString() );
        }

        /// <summary>
        /// 测试Prompt弹出输入确认框-多行文本框
        /// </summary>
        [TestMethod]
        public void TestPrompt_Multiline() {
            Assert.AreEqual( GetReuslt_Prompt( true ), _service.Prompt( "a", "b", "c", true ).ToString() );
        }

        /// <summary>
        /// 测试Confirm弹出确认框
        /// </summary>
        [TestMethod]
        public void TestConfirm() {
            Assert.AreEqual( GetResult_Confirm(), _service.Confirm( "a", "b", "c" ).ToString() );
        }

        /// <summary>
        /// 仅设置标题
        /// </summary>
        [TestMethod]
        public void TestMsg_Title() {
            Assert.AreEqual( MessageBoxTest.GetResult_Title_A(), _service.Msg( "a", null ).ToHtmlString() );
            Assert.AreEqual( MessageBoxTest.GetResult_Title_A(), _service.Msg( new Message() { Title = "a" } ).ToHtmlString() );
        }

        /// <summary>
        /// 设置标题和内容
        /// </summary>
        [TestMethod]
        public void TestMsg_Title_Content() {
            Assert.AreEqual( MessageBoxTest.GetResult_TitleA_ContentB(), _service.Msg( new Message() { Title = "a", Content = "b" } ).ToHtmlString() );
        }

        /// <summary>
        /// 设置标题、内容、回调
        /// </summary>
        [TestMethod]
        public void TestMsg_Title_Content_Handler() {
            string actual = _service.Msg( new Message() { Title = "a", Content = "b", Handler = "c" } ).ToHtmlString();
            Assert.AreEqual( MessageBoxTest.GetResult_TitleA_ContentB_CallbackC(), actual );
        }

        /// <summary>
        /// 设置所有选项
        /// </summary>
        [TestMethod]
        public void TestMsg_All() {
            string actual = _service.Msg( new Message() {
                Title = "a",
                Content = "b",
                Handler = "c",
                Width = 100,
                AnimeElementId = "div1",
                Button = MessageBoxButton.YesNoCancel,
                Icon = MessageBoxIcon.Error,
                Modal = false,
                ShowClose = false,
                Prompt = true,
                MultiLine = true,
                Value = "d"
            } ).ToHtmlString();
            Assert.AreEqual( MessageBoxTest.GetResult_All(), actual );
        }

        /// <summary>
        /// 隐藏消息框
        /// </summary>
        [TestMethod]
        public void TestHideMsg() {
            Assert.AreEqual( MessageBoxTest.GetResult_Hide(), _service.HideMsg().ToString() );
        }
    }
}
