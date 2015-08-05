namespace Util.Webs.Ext.Core {
    /// <summary>
    /// 空函数
    /// </summary>
    public class NullFunction : Function{
        /// <summary>
        /// 空对象
        /// </summary>
        public override bool IsNull() {
            return true;
        }
    }
}
