﻿namespace Util.Webs.Ext {
    /// <summary>
    /// Ext工厂
    /// </summary>
    public interface IExtFactory {
        /// <summary>
        /// 创建消息框
        /// </summary>
        IMessageBox CreateMessageBox();
        /// <summary>
        /// 创建进度条
        /// </summary>
        IProgressBar CreateProgressBar();
        /// <summary>
        /// 创建工具栏
        /// </summary>
        IToolbar CreateToolbar();
        /// <summary>
        /// 创建视区
        /// </summary>
        IViewport CreateViewport();
        /// <summary>
        /// 创建面板
        /// </summary>
        IPanel CreatePanel();
        /// <summary>
        /// 创建BoxComponent
        /// </summary>
        IBoxComponent CreateBoxComponent();
        /// <summary>
        /// 创建选项卡面板
        /// </summary>
        ITabPanel CreateTabPanel();
        /// <summary>
        /// 创建窗口
        /// </summary>
        IWindow CreateWindow();
        /// <summary>
        /// 创建按钮
        /// </summary>
        IButton CreateButton();
        /// <summary>
        /// 创建文本框
        /// </summary>
        ITextBox CreateTextBox();
        /// <summary>
        /// 创建组合框
        /// </summary>
        IComboBox CreateComboBox();
        /// <summary>
        /// 创建文本区
        /// </summary>
        ITextArea CreateTextArea();
    }
}
