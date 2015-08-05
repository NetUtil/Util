using System.Collections.Generic;
using System.Linq;
using Util.Webs.Ext.Configs;

namespace Util.Webs.Ext.Controls {
    /// <summary>
    /// 基容器
    /// </summary>
    public abstract class ContainerBase<T> : ComponentBase<T>, IContainer<T> where T : IComponent {

        #region 构造方法

        /// <summary>
        /// 初始化基容器
        /// </summary>
        protected ContainerBase() {
            _layout = Ext.Layout.None;
            _childs = new List<IComponent>();
        }

        #endregion

        #region 字段

        /// <summary>
        /// 布局方式
        /// </summary>
        private Layout _layout;

        /// <summary>
        /// 组件集合
        /// </summary>
        private readonly List<IComponent> _childs;

        /// <summary>
        /// 标签宽度
        /// </summary>
        private int? _labelWidth;

        #endregion

        #region Layout(设置布局方式)

        /// <summary>
        /// 设置布局方式
        /// </summary>
        /// <param name="layout">布局方式</param>
        public T Layout( Layout layout ) {
            _layout = layout;
            return This();
        }

        #endregion

        #region Add(添加子组件)

        /// <summary>
        /// 添加子组件
        /// </summary>
        /// <param name="childs">组件</param>
        public T Add( params IComponent[] childs ) {
            if ( childs == null || childs.Length == 0 )
                return This();
            foreach ( var child in childs ) {
                var component = (IComponent<IComponent>)child;
                component.RenderWithXType();
                _childs.Add( child );
            }
            return This();
        }

        #endregion

        #region LabelWidth(设置表单标签宽度)

        /// <summary>
        /// 设置表单标签宽度
        /// </summary>
        /// <param name="width">表单标签宽度</param>
        public T LabelWidth( int width ) {
            _labelWidth = width;
            return This();
        }

        #endregion

        #region GetChilds(获取子组件)

        /// <summary>
        /// 获取子组件
        /// </summary>
        internal List<IComponent> GetChilds() {
            return _childs;
        }

        #endregion

        #region InitConfig(初始化配置)

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="config">配置</param>
        protected override void InitConfig( IConfig config ) {
            base.InitConfig( config );
            var configBase = (ContainerConfigBase)config;
            InitItems( configBase );
            configBase.layout = _layout.Description();
            configBase.labelWidth = _labelWidth;
        }

        /// <summary>
        /// 初始化子组件配置
        /// </summary>
        private void InitItems( ContainerConfigBase configBase ) {
            if ( _childs.Count == 0 )
                return;
            configBase.items = string.Format( "[{0}]", _childs.ToList().Splice() );
        }

        #endregion
    }
}
