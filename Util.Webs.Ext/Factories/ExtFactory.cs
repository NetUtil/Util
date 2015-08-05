using Util.Webs.Ext.Controls.BoxComponents;
using Util.Webs.Ext.Controls.Buttons;
using Util.Webs.Ext.Controls.Forms;
using Util.Webs.Ext.Controls.MessageBoxs;
using Util.Webs.Ext.Controls.Panels;
using Util.Webs.Ext.Controls.ProgressBars;
using Util.Webs.Ext.Controls.TabPanels;
using Util.Webs.Ext.Controls.Toolbars;
using Util.Webs.Ext.Controls.Viewports;
using Util.Webs.Ext.Controls.Windows;

namespace Util.Webs.Ext.Factories {
    /// <summary>
    /// Ext工厂
    /// </summary>
    public class ExtFactory : IExtFactory{
        /// <summary>
        /// 创建消息框
        /// </summary>
        public virtual IMessageBox CreateMessageBox() {
            return new MessageBox();
        }

        /// <summary>
        /// 创建进度条
        /// </summary>
        public virtual IProgressBar CreateProgressBar() {
            return new ProgressBar();
        }

        /// <summary>
        /// 创建工具栏
        /// </summary>
        public virtual IToolbar CreateToolbar() {
            return new Toolbar();
        }

        /// <summary>
        /// 创建视区
        /// </summary>
        public virtual IViewport CreateViewport() {
            return new Viewport();
        }

        /// <summary>
        /// 创建面板
        /// </summary>
        public IPanel CreatePanel() {
            return new Panel();
        }

        /// <summary>
        /// 创建BoxComponent
        /// </summary>
        public IBoxComponent CreateBoxComponent() {
            return new BoxComponent();
        }

        /// <summary>
        /// 创建选项卡面板
        /// </summary>
        public ITabPanel CreateTabPanel() {
            return new TabPanel();
        }

        /// <summary>
        /// 创建窗口
        /// </summary>
        public IWindow CreateWindow() {
            return new Window();
        }

        /// <summary>
        /// 创建按钮
        /// </summary>
        public IButton CreateButton() {
            return new Button();
        }

        /// <summary>
        /// 创建文本框
        /// </summary>
        public ITextBox CreateTextBox() {
            return new TextBox();
        }

        /// <summary>
        /// 创建组合框
        /// </summary>
        public IComboBox CreateComboBox() {
            return new ComboBox();
        }

        /// <summary>
        /// 创建文本区
        /// </summary>
        public ITextArea CreateTextArea() {
            return new TextArea();
        }
    }
}
