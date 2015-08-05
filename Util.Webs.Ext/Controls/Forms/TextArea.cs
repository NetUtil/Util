namespace Util.Webs.Ext.Controls.Forms {
    /// <summary>
    /// 文本区
    /// </summary>
    public class TextArea : TextBox<ITextArea>, ITextArea {
        /// <summary>
        /// 获取XType
        /// </summary>
        protected override string GetXType() {
            return "textarea";
        }
    }
}
