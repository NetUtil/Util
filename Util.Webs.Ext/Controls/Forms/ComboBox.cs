namespace Util.Webs.Ext.Controls.Forms {
    /// <summary>
    /// 组合框
    /// </summary>
    public class ComboBox : TextBox<IComboBox>,IComboBox {
        /// <summary>
        /// 获取XType
        /// </summary>
        protected override string GetXType() {
            return "combo";
        }
    }
}
