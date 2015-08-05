using Json.Net;

namespace Util.Webs.Ext.Configs {
    /// <summary>
    /// 容器配置
    /// </summary>
    internal class ContainerConfigBase : ComponentConfigBase{
        /// <summary>
        /// 布局
        /// </summary>
        [Json( Order = 100,NullValueHandling = NullValueHandling.Ignore )]
        public string layout { get; set; }
        /// <summary>
        /// 子组件
        /// </summary>
        [Json( false, Order = 101,NullValueHandling = NullValueHandling.Ignore )]
        public string items { get; set; }
        /// <summary>
        /// 表单标签宽度
        /// </summary>
        [Json( false, Order = 102, NullValueHandling = NullValueHandling.Ignore )]
        public int? labelWidth { get; set; }
    }
}
