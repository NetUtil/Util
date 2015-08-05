using Util.Webs.Ext.Configs;
using Util.Webs.Ext.Renders;

namespace Util.Webs.Ext.Controls.Forms {
    /// <summary>
    /// 文本框
    /// </summary>
    public class TextBox<T> : ComponentBase<T>, ITextBox<T> where T : IComponent<T> {
        /// <summary>
        /// 允许为空
        /// </summary>
        private bool? _allowBlank;
        /// <summary>
        /// 必填项错误消息
        /// </summary>
        private string _blankText;

        /// <summary>
        /// 设置为必填项
        /// </summary>
        /// <param name="error">错误消息</param>
        public T Required( string error = "" ) {
            _allowBlank = true;
            if ( error.IsEmpty() )
                error = string.Format( "{0}不能为空",GetLabel() );
            _blankText = error;
            return This();
        }

        /// <summary>
        /// 获取标签渲染器
        /// </summary>
        protected override IRender GetTagRender() {
            return new XTypeRender<T>( this );
        }

        /// <summary>
        /// 获取配置
        /// </summary>
        protected override IConfig GetConfig() {
            return new TextBoxConfig();
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        protected override void InitConfig( IConfig config ) {
            base.InitConfig( config );
            var textBoxConfig = (TextBoxConfig) config;
            textBoxConfig.allowBlank = _allowBlank;
            textBoxConfig.blankText = _blankText;
        }
    }
}
