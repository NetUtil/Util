using Util.Webs.Ext.Controls;

namespace Util.Webs.Ext.Renders {
    /// <summary>
    /// 组件标签渲染器
    /// </summary>
    internal class TagRender<T> : IRender where T : IComponent {
        /// <summary>
        /// 初始化组件标签渲染器
        /// </summary>
        /// <param name="component">组件</param>
        public TagRender( ComponentBase<T> component ) {
            _component = component;
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
            _component.AddMethod( result );
            return result.ToString();
        }

        /// <summary>
        /// 渲染标签
        /// </summary>
        protected virtual void Render( Str result ) {
            result.Add( "var {0} = new {1}(", _component.GetVarName(), _component.GetComponentName() );
            _component.AddConfig( result );
            result.Add( ");" );
        }
    }
}
