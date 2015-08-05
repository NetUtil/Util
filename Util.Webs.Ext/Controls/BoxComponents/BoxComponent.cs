using Util.Webs.Ext.Configs;

namespace Util.Webs.Ext.Controls.BoxComponents {
    /// <summary>
    /// BoxComponent
    /// </summary>
    public class BoxComponent : ContainerBase<IBoxComponent>, IBoxComponent {
        /// <summary>
        /// 初始化BoxComponent
        /// </summary>
        public BoxComponent() {
            _config = new BoxComponentConfig();
        }

        /// <summary>
        /// 配置
        /// </summary>
        private readonly BoxComponentConfig _config;

        /// <summary>
        /// 设置区域
        /// </summary>
        /// <param name="region">区域</param>
        public IBoxComponent Region( Region region ) {
            _config.region = region.Description();
            return this;
        }
        /// <summary>
        /// 加载内容
        /// </summary>
        /// <param name="elementId">元素Id</param>
        public IBoxComponent LoadContent( string elementId ) {
            _config.el = elementId;
            return this;
        }

        /// <summary>
        /// 获取组件名
        /// </summary>
        internal override string GetComponentName() {
            return "Ext.BoxComponent";
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return _config;
        }

        /// <summary>
        /// 获取XType
        /// </summary>
        protected override string GetXType() {
            return "box";
        }
    }
}
