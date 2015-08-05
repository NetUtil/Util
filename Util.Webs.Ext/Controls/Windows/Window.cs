using Util.Webs.Ext.Configs;
using Util.Webs.Ext.Controls.Panels;

namespace Util.Webs.Ext.Controls.Windows {
    /// <summary>
    /// 窗口
    /// </summary>
    public class Window : Panel<IWindow> , IWindow {

        #region 字段

        /// <summary>
        /// 限制窗口
        /// </summary>
        private bool? _constrain;

        /// <summary>
        /// 允许改变窗口大小
        /// </summary>
        private bool? _resizable;

        /// <summary>
        /// 允许拖动
        /// </summary>
        private bool? _draggable;

        /// <summary>
        /// 模态窗
        /// </summary>
        private bool? _modal;

        #endregion

        #region Constrain(限制窗口在可视范围内)

        /// <summary>
        /// 限制窗口在可视范围内
        /// </summary>
        public IWindow Constrain() {
            _constrain = true;
            return this;
        }

        #endregion

        #region Resizable(允许改变窗口大小)

        /// <summary>
        /// 允许改变窗口大小
        /// </summary>
        /// <param name="resizable">是否允许改变窗口大小</param>
        public IWindow Resizable( bool resizable = true ) {
            _resizable = resizable;
            return this;
        }

        #endregion

        #region Draggable(允许拖动)

        /// <summary>
        /// 允许拖动
        /// </summary>
        /// <param name="draggable">是否允许拖动</param>
        public IWindow Draggable( bool draggable = true ) {
            _draggable = draggable;
            return this;
        }

        #endregion

        #region Modal(模态窗)

        /// <summary>
        /// 模态窗
        /// </summary>
        public IWindow Modal() {
            _modal = true;
            return this;
        }

        #endregion

        #region GetComponentName(获取组件名)

        /// <summary>
        /// 获取组件名
        /// </summary>
        internal override string GetComponentName() {
            return "Ext.Window";
        }

        #endregion

        #region GetConfig(获取配置)

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return new WindowConfig();
        }

        #endregion

        #region InitConfig(初始化配置)

        /// <summary>
        /// 初始化配置
        /// </summary>
        protected override void InitConfig( IConfig config ) {
            base.InitConfig( config );
            var windowConfig = config as WindowConfig;
            if ( windowConfig == null )
                return;
            windowConfig.constrain = _constrain;
            windowConfig.resizable = _resizable;
            windowConfig.draggable = _draggable;
            windowConfig.modal = _modal;
        }

        #endregion
    }
}
