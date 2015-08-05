using Util.Webs.Ext.Controls;

namespace Util.Webs.Ext {
    /// <summary>
    /// 选项卡面板
    /// </summary>
    public interface ITabPanel : IContainer<ITabPanel> {
        /// <summary>
        /// 设置激活选项卡索引
        /// </summary>
        /// <param name="index">激活选项卡索引,第一个选项卡的索引为0</param>
        ITabPanel ActiveTabIndex( int? index );
        /// <summary>
        /// 设置选项卡位置
        /// </summary>
        /// <param name="position">选项卡位置</param>
        ITabPanel TabPosition( TabPosition position );
        /// <summary>
        /// 添加选项卡
        /// </summary>
        /// <param name="item">选项卡</param>
        ITabPanel AddItem( IPanel item );
        /// <summary>
        /// 启用选项卡滚动,当选项卡位置为top时有效
        /// </summary>
        ITabPanel EnableTabScroll();
        /// <summary>
        /// 设置选项卡宽度
        /// </summary>
        /// <param name="width">选项卡宽度</param>
        ITabPanel TabWidth( int width );
    }
}
