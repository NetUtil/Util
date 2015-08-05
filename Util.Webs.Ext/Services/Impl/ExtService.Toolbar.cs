namespace Util.Webs.Ext.Services.Impl {
    /// <summary>
    /// Ext服务
    /// </summary>
    public partial class ExtService {
        /// <summary>
        /// 工具栏
        /// </summary>
        /// <param name="id">工具栏Id</param>
        /// <param name="renderToId">渲染目标Id</param>
        public IToolbar Toolbar( string id = "", string renderToId = "" ) {
            return GetToolbar().Id( id ).RenderTo( renderToId );
        }
    }
}
