namespace Util.Webs.Ext.Controls.Panels {
    /// <summary>
    /// 面板
    /// </summary>
    public class Panel : Panel<IPanel>, IPanel{
        /// <summary>
        /// 获取XType
        /// </summary>
        protected override string GetXType() {
            return "panel";
        }
    }
}
