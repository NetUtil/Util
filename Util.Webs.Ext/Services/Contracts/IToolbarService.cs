namespace Util.Webs.Ext.Services.Contracts {
    /// <summary>
    /// 工具栏服务
    /// </summary>
    public interface IToolbarService {
        /// <summary>
        /// 工具栏
        /// </summary>
        /// <param name="id">工具栏Id</param>
        /// <param name="renderToId">渲染目标Id</param>
        IToolbar Toolbar( string id = "",string renderToId = "" );
    }
}
