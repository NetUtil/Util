using Util.Webs.Ext.Configs;
using Util.Webs.Ext.Controls.Buttons;

namespace Util.Webs.Ext.Controls.Toolbars {
    /// <summary>
    /// 工具栏按钮
    /// </summary>
    public class ToolbarButton : Button<IToolbarButton>, IToolbarButton {
        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return new ToolbarButtonConfig();
        }

        /// <summary>
        /// 输出Html
        /// </summary>
        public override string ToHtmlString() {
            RenderWithXType();
            return base.ToHtmlString();
        }
    }
}
