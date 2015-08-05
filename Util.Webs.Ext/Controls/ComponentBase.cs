using Util;
using Util.Webs.Ext.Configs;
using Util.Webs.Ext.Renders;

namespace Util.Webs.Ext.Controls {
    /// <summary>
    /// 基组件
    /// </summary>
    public abstract class ComponentBase<T> : IComponent<T> where T : IComponent {

        #region 构造方法

        /// <summary>
        /// 初始化基组件
        /// </summary>
        protected ComponentBase() {
            Var( string.Format( "ext{0}", Str.Unique() ) );
            _method = new Str();
        }

        #endregion

        #region 字段

        /// <summary>
        /// 组件变量名
        /// </summary>
        private string _varName;
        /// <summary>
        /// 标识
        /// </summary>
        private string _id;
        /// <summary>
        /// 宽度
        /// </summary>
        private int? _width;
        /// <summary>
        /// 高度
        /// </summary>
        private int? _height;
        /// <summary>
        /// 渲染目标标识
        /// </summary>
        private string _renderToId;
        /// <summary>
        /// 以xtype方式渲染
        /// </summary>
        private bool? _renderWithXType;
        /// <summary>
        /// 禁用
        /// </summary>
        private bool? _disabled;
        /// <summary>
        /// 方法调用
        /// </summary>
        private readonly Str _method;
        /// <summary>
        /// 锚点布局
        /// </summary>
        private string _anchor;
        /// <summary>
        /// 外边距
        /// </summary>
        private string _margin;
        /// <summary>
        /// 标签文本
        /// </summary>
        private string _label;
        /// <summary>
        /// 标签文本分隔符
        /// </summary>
        private string _labelSeparator;
        /// <summary>
        /// 绝对布局的left
        /// </summary>
        private int? _x;
        /// <summary>
        /// 绝对布局的top
        /// </summary>
        private int? _y;

        #endregion

        #region GetId(获取标识)

        /// <summary>
        /// 获取标识
        /// </summary>
        public string GetId() {
            return _id;
        }

        #endregion

        #region GetVarName(获取组件变量名)

        /// <summary>
        /// 获取组件变量名
        /// </summary>
        public string GetVarName() {
            return _varName;
        }

        #endregion

        #region GetLabel(获取标签文本)

        /// <summary>
        /// 获取标签文本
        /// </summary>
        protected string GetLabel() {
            return _label;
        }

        #endregion

        #region IsRenderWithXType(是否以xtype方式渲染)

        /// <summary>
        /// 是否以xtype方式渲染
        /// </summary>
        public bool IsRenderWithXType {
            get { return _renderWithXType.SafeValue(); }
        }

        #endregion

        #region Var(设置组件变量名)

        /// <summary>
        /// 设置组件变量名
        /// </summary>
        /// <param name="varName">组件变量名</param>
        public T Var( string varName ) {
            _varName = varName;
            return This();
        }

        #endregion

        #region Id(设置标识)

        /// <summary>
        /// 设置标识
        /// </summary>
        /// <param name="id">标识</param>
        public T Id( string id ) {
            _id = id;
            return Var( id );
        }

        #endregion

        #region Width(设置宽度)

        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="width">宽度</param>
        public T Width( int? width ) {
            _width = width;
            return This();
        }

        #endregion

        #region Height(设置高度)

        /// <summary>
        /// 设置高度
        /// </summary>
        /// <param name="height">高度</param>
        public T Height( int? height ) {
            _height = height;
            return This();
        }

        #endregion

        #region RenderTo(渲染到目标)

        /// <summary>
        /// 渲染到目标
        /// </summary>
        /// <param name="id">渲染目标标识</param>
        public T RenderTo( string id ) {
            _renderToId = id;
            return This();
        }

        #endregion

        #region RenderWithXType(以xtype方式渲染)

        /// <summary>
        /// 以xtype方式渲染
        /// </summary>
        public T RenderWithXType() {
            _renderWithXType = true;
            return This();
        }

        #endregion

        #region Disable(禁用)

        /// <summary>
        /// 禁用
        /// </summary>
        public T Disable() {
            _disabled = true;
            return This();
        }

        #endregion

        #region Show(显示)

        /// <summary>
        /// 显示
        /// </summary>
        public T Show() {
            AddMethod( "{0}.show();", GetVarName() );
            return This();
        }

        #endregion

        #region Hide(隐藏)

        /// <summary>
        /// 隐藏
        /// </summary>
        public T Hide() {
            AddMethod( "{0}.hide();", GetVarName() );
            return This();
        }

        #endregion

        #region Anchor(设置锚点布局)

        /// <summary>
        /// 设置锚点布局
        /// </summary>
        /// <param name="width">宽度，可以是百分比或偏移量，范例1："50%",范例2: "-50"</param>
        /// <param name="height">高度，可以是百分比或偏移量，范例1："50%",范例2: "-50"</param>
        public T Anchor( string width, string height = "" ) {
            if( height.IsEmpty() )
                _anchor = string.Format( "{0}", width );
            else
                _anchor = string.Format( "{0} # {1}", width, height );
            return This();
        }

        /// <summary>
        /// 以百分比方式设置锚点布局
        /// </summary>
        /// <param name="width">表示当前组件占父容器的百分比宽度，范例：50，表示50%</param>
        /// <param name="height">表示当前组件占父容器的百分比高度，范例：50，表示50%</param>
        public T AnchorByPercent( int width, int? height = null ) {
            Anchor( width + "%", GetHeightPercent( height ) );
            return This();
        }

        /// <summary>
        /// 获取高度百分比
        /// </summary>
        private string GetHeightPercent( int? height = null ) {
            if ( height == null )
                return string.Empty;
            return height + "%";
        }

        /// <summary>
        /// 以偏移量方式设置锚点布局
        /// </summary>
        /// <param name="width">表示当前组件相对父容器的宽度偏移量，范例:-50,表示父容器宽度-50</param>
        /// <param name="height">表示当前组件相对父容器的高度偏移量，范例:-50,表示父容器高度-50</param>
        public T AnchorByOffset( int width, int? height = null ) {
            Anchor( "-" + width, GetHeightOffset(height) );
            return This();
        }

        /// <summary>
        /// 获取高度偏移量
        /// </summary>
        private string GetHeightOffset( int? height = null ) {
            if ( height == null )
                return string.Empty;
            return "-" + height;
        }

        #endregion

        #region Margin(设置外边距)

        /// <summary>
        /// 设置外边距
        /// </summary>
        /// <param name="top">上边距</param>
        /// <param name="right">右边距</param>
        /// <param name="bottom">下边距</param>
        /// <param name="left">左边距</param>
        public T Margin( int top, int right = 0, int bottom = 0, int left = 0 ) {
            _margin = string.Format( "{0} {1} {2} {3}", top, right, bottom, left );
            return This();
        }

        #endregion

        #region Label(设置标签文本)

        /// <summary>
        /// 设置表单标签文本
        /// </summary>
        /// <param name="text">表单标签文本</param>
        /// <param name="separator">表单标签分隔符</param>
        public T Label( string text, string separator = "" ) {
            _label = text;
            _labelSeparator = separator;
            return This();
        }

        #endregion

        #region Absolute(设置绝对布局)

        /// <summary>
        /// 设置绝对布局
        /// </summary>
        /// <param name="left">左边距</param>
        /// <param name="top">上边距</param>
        public T Absolute( int? left, int? top ) {
            _x = left;
            _y = top;
            return This();
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 返回组件
        /// </summary>
        protected T This() {
            return (T)( (object)this );
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="method">方法语句</param>
        /// <param name="args">参数</param>
        protected void AddMethod( string method, params object[] args ) {
            _method.Add( method, args );
        }

        #endregion

        #region AddConfig(添加配置)

        /// <summary>
        /// 添加配置
        /// </summary>
        internal void AddConfig( Str result ) {
            var config = GetConfig();
            if ( config == null )
                return;
            InitConfig( config );
            result.Add( config.ToJson().Replace( "\\", "" ) );
        }

        /// <summary>
        /// 获取配置对象
        /// </summary>
        protected virtual IConfig GetConfig() {
            return null;
        }

        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="config">配置</param>
        protected virtual void InitConfig( IConfig config ) {
            var configBase = config as ComponentConfigBase;
            if ( configBase == null )
                return;
            configBase.id = _id;
            configBase.width = _width;
            configBase.height = _height;
            configBase.renderTo = _renderToId;
            configBase.disabled = _disabled;
            if( IsRenderWithXType )
                configBase.xtype = GetXType();
            configBase.anchor = _anchor;
            configBase.margins = _margin;
            configBase.fieldLabel = _label;
            configBase.labelSeparator = _labelSeparator;
            configBase.x = _x;
            configBase.y = _y;
        }

        /// <summary>
        /// 获取XType
        /// </summary>
        protected virtual string GetXType() {
            return string.Empty;
        }

        /// <summary>
        /// 获取组件名
        /// </summary>
        internal virtual string GetComponentName() {
            return string.Empty;
        }

        /// <summary>
        /// 添加方法调用
        /// </summary>
        internal void AddMethod( Str result ) {
            result.Add( _method.ToString() );
        }

        #endregion

        #region ToHtmlString(输出Html)

        /// <summary>
        /// 输出Html
        /// </summary>
        public virtual string ToHtmlString() {
            var render = GetRender();
            return render.Render();
        }

        /// <summary>
        /// 获取渲染器
        /// </summary>
        private IRender GetRender() {
            if ( _renderWithXType == true )
                return GetXTypeRender();
            return GetTagRender();
        }

        /// <summary>
        /// 获取XType渲染器
        /// </summary>
        protected virtual IRender GetXTypeRender() {
            return new XTypeRender<T>( this );
        }

        /// <summary>
        /// 获取标签渲染器
        /// </summary>
        protected virtual IRender GetTagRender() {
            return new TagRender<T>( this );
        }

        #endregion

        #region ToString(输出Html)

        /// <summary>
        /// 输出Html
        /// </summary>
        public override string ToString() {
            return ToHtmlString();
        }

        #endregion
    }
}
