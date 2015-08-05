using Util.Webs.Ext.Controls;

namespace Util.Webs.Ext.Renders {
    /// <summary>
    /// 组件XType渲染器
    /// </summary>
    internal class XTypeRender<T> : IRender where T : IComponent {
        /// <summary>
        /// 初始化组件XType渲染器
        /// </summary>
        /// <param name="component">组件</param>
        public XTypeRender( ComponentBase<T> component ) {
            _component = component;
            _component.RenderWithXType();
        }

        /// <summary>
        /// 组件
        /// </summary>
        private readonly ComponentBase<T> _component;

        /// <summary>
        /// 渲染
        /// </summary>
        public string Render() {
            var result = new Str();
            Render( result );
            return result.ToString();
        }

        /// <summary>
        /// 渲染标签
        /// </summary>
        protected virtual void Render( Str result ) {
            _component.AddConfig( result );
        }
    }
}
