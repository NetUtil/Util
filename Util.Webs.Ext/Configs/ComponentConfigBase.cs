using Json.Net;

namespace Util.Webs.Ext.Configs {
    /// <summary>
    /// 组件配置
    /// </summary>
    internal abstract class ComponentConfigBase : ConfigBase {
        /// <summary>
        /// 标识
        /// </summary>
        [Json( Order = 0, NullValueHandling = NullValueHandling.Ignore )]
        public string id { get; set; }
        /// <summary>
        /// xtype
        /// </summary>
        [Json( Order = 1, NullValueHandling = NullValueHandling.Ignore )]
        public string xtype { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        [Json( Order = 2, NullValueHandling = NullValueHandling.Ignore )]
        public int? width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        [Json( Order = 3, NullValueHandling = NullValueHandling.Ignore )]
        public int? height { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        [Json( Order = 4, NullValueHandling = NullValueHandling.Ignore )]
        public bool? disabled { get; set; }
        /// <summary>
        /// 绝对布局的left
        /// </summary>
        [Json( Order = 93, NullValueHandling = NullValueHandling.Ignore )]
        public int? x { get; set; }
        /// <summary>
        /// 绝对布局的top
        /// </summary>
        [Json( Order = 94, NullValueHandling = NullValueHandling.Ignore )]
        public int? y { get; set; }
        /// <summary>
        /// 标签文本
        /// </summary>
        [Json( Order = 95, NullValueHandling = NullValueHandling.Ignore )]
        public string fieldLabel { get; set; }
        /// <summary>
        /// 标签文本分隔符
        /// </summary>
        [Json( Order = 96, NullValueHandling = NullValueHandling.Ignore )]
        public string labelSeparator { get; set; }
        /// <summary>
        /// 外边距
        /// </summary>
        [Json( Order = 97, NullValueHandling = NullValueHandling.Ignore )]
        public string margins { get; set; }
        /// <summary>
        /// 锚点布局
        /// </summary>
        [Json( Order = 98, NullValueHandling = NullValueHandling.Ignore )]
        public string anchor { get; set; }
        /// <summary>
        /// 渲染目标
        /// </summary>
        [Json( Order = 99, NullValueHandling = NullValueHandling.Ignore )]
        public string renderTo { get; set; }
    }
}
