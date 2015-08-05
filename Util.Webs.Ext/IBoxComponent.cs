using Util.Webs.Ext.Controls;

namespace Util.Webs.Ext {
    /// <summary>
    /// BoxComponent
    /// </summary>
    public interface IBoxComponent : IContainer<IBoxComponent> {
        /// <summary>
        /// 设置区域
        /// </summary>
        /// <param name="region">区域</param>
        IBoxComponent Region( Region region );
        /// <summary>
        /// 加载内容
        /// </summary>
        /// <param name="elementId">元素Id</param>
        IBoxComponent LoadContent( string elementId );
    }
}
