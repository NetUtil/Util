namespace Util.Webs.Ext.Controls.Forms {
    /// <summary>
    /// 文本框
    /// </summary>
    public class TextBox : TextBox<ITextBox>, ITextBox {
        /// <summary>
        /// 获取XType
        /// </summary>
        protected override string GetXType() {
            return "textfield";
        }
    }
}
