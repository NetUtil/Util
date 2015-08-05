using Util.Webs.Ext.Factories;
using Util.Webs.Mvc;

namespace Util.Webs.Ext.Services.Impl {
    /// <summary>
    /// Ext框架服务
    /// </summary>
    public partial class ExtService : MvcBase, IExtService {

        #region IExtFactory(Ext工厂)

        /// <summary>
        /// Ext工厂
        /// </summary>
        private IExtFactory _factory;

        /// <summary>
        /// 获取Ext工厂
        /// </summary>
        private IExtFactory GetFactory() {
            if ( _factory != null )
                return _factory;
            _factory = CreateFactory();
            return _factory;
        }

        /// <summary>
        /// 创建Ext工厂
        /// </summary>
        protected virtual IExtFactory CreateFactory() {
            return new ExtFactory();
        }

        #endregion

        #region IMessageBox(消息框)

        /// <summary>
        /// 消息框
        /// </summary>
        private IMessageBox _messageBox;

        /// <summary>
        /// 获取消息框
        /// </summary>
        private IMessageBox GetMessageBox() {
            if ( _messageBox != null )
                return _messageBox;
            _messageBox = GetFactory().CreateMessageBox();
            return _messageBox;
        }

        #endregion

        #region IProgressBar(进度条)

        /// <summary>
        /// 进度条
        /// </summary>
        private IProgressBar _progressBar;

        /// <summary>
        /// 获取进度条
        /// </summary>
        private IProgressBar GetProgressBar() {
            if ( _progressBar != null )
                return _progressBar;
            _progressBar = GetFactory().CreateProgressBar();
            return _progressBar;
        }

        #endregion

        #region IToolBar(工具栏)

        /// <summary>
        /// 工具栏
        /// </summary>
        private IToolbar _toolbar;

        /// <summary>
        /// 获取工具栏
        /// </summary>
        private IToolbar GetToolbar() {
            if ( _toolbar != null )
                return _toolbar;
            _toolbar = GetFactory().CreateToolbar();
            return _toolbar;
        }

        #endregion
    }
}
