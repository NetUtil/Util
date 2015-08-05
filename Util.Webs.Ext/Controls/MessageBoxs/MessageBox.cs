using System.Collections.Generic;
using Util.Webs.Ext.Configs;

namespace Util.Webs.Ext.Controls.MessageBoxs {
    /// <summary>
    /// 消息框
    /// </summary>
    public class MessageBox : IMessageBox {

        #region 构造方法
        
        /// <summary>
        /// 初始化消息框
        /// </summary>
        public MessageBox() {
            ButtonTexts = new List<string>();
            _message = new Message();
        }

        #endregion

        #region 字段

        /// <summary>
        /// 提示按钮文本
        /// </summary>
        private List<string> ButtonTexts { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        private Message _message;

        #endregion

        #region Message(设置消息)

        /// <summary>
        /// 设置消息
        /// </summary>
        /// <param name="message">消息</param>
        public IMessageBox Message( Message message ) {
            _message = message;
            return this;
        }

        #endregion

        #region Id(设置消息框标识)

        /// <summary>
        /// 设置消息框标识
        /// </summary>
        /// <param name="id">消息框标识</param>
        public IMessageBox Id( string id ) {
            _message.Id = id;
            return this;
        }

        #endregion

        #region Title(设置标题)

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title">标题</param>
        public IMessageBox Title( string title ) {
            _message.Title = title;
            return this;
        }

        #endregion

        #region Content(设置内容)

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="content">内容</param>
        public IMessageBox Content( string content ) {
            _message.Content = content;
            return this;
        }

        #endregion

        #region Modal(是否以模态窗口显示)

        /// <summary>
        /// 是否以模态窗口显示
        /// </summary>
        /// <param name="showModal">true表示按模态窗显示</param>
        public IMessageBox Modal( bool showModal = true ) {
            _message.Modal = showModal;
            return this;
        }

        #endregion

        #region ShowClose(是否显示右上角的关闭按钮)

        /// <summary>
        /// 是否显示右上角的关闭按钮
        /// </summary>
        /// <param name="showClose">false表示不显示关闭按钮</param>
        public IMessageBox ShowClose( bool showClose = true ) {
            _message.ShowClose = showClose;
            return this;
        }

        #endregion

        #region Width(设置宽度)

        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度，单位：像素</param>
        public IMessageBox Width( int width ) {
            _message.Width = width;
            return this;
        }

        #endregion

        #region Button(设置提示框按钮)

        /// <summary>
        /// 设置提示框按钮
        /// </summary>
        /// <param name="button">提示框按钮类型</param>
        public IMessageBox Button( MessageBoxButton button ) {
            _message.Button = button;
            return this;
        }

        #endregion

        #region Icon(设置提示框图标)

        /// <summary>
        /// 设置提示框图标
        /// </summary>
        /// <param name="icon">提示框图标类型</param>
        public IMessageBox Icon( MessageBoxIcon icon ) {
            _message.Icon = icon;
            return this;
        }

        #endregion

        #region Handler(设置回调函数)

        /// <summary>
        /// 设置回调函数
        /// </summary>
        /// <param name="handler">回调函数</param>
        public IMessageBox Handler( string handler ) {
            _message.Handler = handler;
            return this;
        }

        #endregion

        #region Anime(设置动画效果)

        /// <summary>
        /// 设置动画效果
        /// </summary>
        /// <param name="elementId">动画起始和结束的控件Id</param>
        public IMessageBox Anime( string elementId ) {
            _message.AnimeElementId = elementId;
            return this;
        }

        #endregion

        #region Prompt(是否显示输入框)

        /// <summary>
        /// 是否显示输入框
        /// </summary>
        /// <param name="showMultiLine">true显示多行文本框</param>
        public IMessageBox Prompt( bool showMultiLine = false ) {
            _message.Prompt = true;
            _message.MultiLine = showMultiLine;
            return this;
        }

        #endregion

        #region Value(设置输入框中的值)

        /// <summary>
        /// 设置输入框中的值
        /// </summary>
        /// <param name="value">输入框中的默认值</param>
        public IMessageBox Value( string value ) {
            _message.Value = value;
            return this;
        }

        #endregion

        #region ButtonText(设置提示框按钮上的文字)

        /// <summary>
        /// 设置提示框按钮上的文字
        /// </summary>
        /// <param name="buttonType">提示框按钮类型</param>
        /// <param name="buttonText">显示的文字</param>
        public IMessageBox ButtonText( MessageBoxButtonType buttonType, string buttonText ) {
            ButtonTexts.Add( string.Format( "{0}='{1}';", buttonType.Description(), buttonText ) );
            return this;
        }

        #endregion

        #region ToHtmlString(输出Html)

        /// <summary>
        /// 输出Html
        /// </summary>
        public string ToHtmlString() {
            Str result = new Str();
            foreach( var text in ButtonTexts )
                result.Add( text );
            result.Add( "{0}Ext.Msg.show({1});", GetVar(), ToMessageConfig().ToJson() );
            return result.ToString();
        }

        /// <summary>
        /// 获取标识
        /// </summary>
        private string GetVar() {
            if ( _message.Id.IsEmpty() )
                return string.Empty;
            return string.Format( "var {0} = ", _message.Id );
        }

        /// <summary>
        /// 转换为消息
        /// </summary>
        private MessageConfig ToMessageConfig() {
            return new MessageConfig() {
                title = _message.Title,
                msg = _message.Content,
                closable = _message.ShowClose,
                modal = _message.Modal,
                width = _message.Width,
                buttons = _message.Button.Description(),
                icon = _message.Icon.Description(),
                fn = _message.Handler,
                animEl = _message.AnimeElementId,
                prompt = _message.Prompt,
                multiline = _message.MultiLine,
                value = _message.Value,
            };
        }

        #endregion
    }
}
