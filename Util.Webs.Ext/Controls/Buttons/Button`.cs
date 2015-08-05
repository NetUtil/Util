using Util.Webs.Ext.Configs;
using Util.Webs.Ext.Renders;

namespace Util.Webs.Ext.Controls.Buttons {
    /// <summary>
    /// 按钮
    /// </summary>
    /// <typeparam name="T">按钮类型</typeparam>
    public class Button<T> : ComponentBase<T>,IButton<T> where T : IComponent {

        #region 字段

        /// <summary>
        /// 文本
        /// </summary>
        private string _text;

        /// <summary>
        /// 图标class
        /// </summary>
        private string _iconClass;

        /// <summary>
        /// 回调函数
        /// </summary>
        private string _handler;

        #endregion

        #region Text(设置文本)

        /// <summary>
        /// 设置文本
        /// </summary>
        /// <param name="text">文本</param>
        public T Text( string text ) {
            _text = text;
            return This();
        }

        #endregion

        #region IconClass(设置图标class)

        /// <summary>
        /// 设置图标class
        /// </summary>
        /// <param name="iconClass">图标class</param>
        public T IconClass( string iconClass ) {
            _iconClass = iconClass;
            return This();
        }

        #endregion

        #region Handler(设置回调函数)

        /// <summary>
        /// 设置回调函数
        /// </summary>
        /// <param name="handler">回调函数</param>
        public T Handler( string handler ) {
            _handler = handler;
            return This();
        }

        #endregion

        #region GetComponentName(获取组件名)

        /// <summary>
        /// 获取组件名
        /// </summary>
        internal override string GetComponentName() {
            return "Ext.Button";
        }

        #endregion

        #region GetConfig(获取配置)

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return new ButtonConfig();
        }

        #endregion

        #region InitConfig(初始化配置)

        /// <summary>
        /// 初始化配置
        /// </summary>
        protected override void InitConfig( IConfig config ) {
            base.InitConfig( config );
            var btnConfig = (ButtonConfig) config;
            btnConfig.text = _text;
            btnConfig.iconCls = _iconClass;
            btnConfig.handler = _handler;
        }

        #endregion
    }
}
