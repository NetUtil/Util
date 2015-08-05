namespace Util.Webs.Ext.Controls.Toolbars {
    /// <summary>
    /// 工具栏文本
    /// </summary>
    public class ToolbarHtml : IToolbarItem{
        /// <summary>
        /// 初始化工具栏文本
        /// </summary>
        /// <param name="html">工具栏文本</param>
        public ToolbarHtml( string html ) {
            Html = html;
        }

        /// <summary>
        /// 工具栏文本
        /// </summary>
        public string Html { get; set; }

        /// <summary>
        /// 输出Html
        /// </summary>
        public override string ToString() {
            return string.Format( "\"{0}\"",Html );
        }
    }
}
