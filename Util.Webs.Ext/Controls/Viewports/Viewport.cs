using Util.Webs.Ext.Configs;

namespace Util.Webs.Ext.Controls.Viewports {
    /// <summary>
    /// 视区
    /// </summary>
    public class Viewport : ContainerBase<IViewport>, IViewport {
        /// <summary>
        /// 初始化视区
        /// </summary>
        public Viewport() {
            Id( "viewport" );
        }

        /// <summary>
        /// 获取组件名
        /// </summary>
        internal override string GetComponentName() {
            return "Ext.Viewport";
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return new ViewportConfig();
        }
    }
}
