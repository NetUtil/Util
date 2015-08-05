namespace Util.Webs.Ext.Core {
    /// <summary>
    /// 函数
    /// </summary>
    public class Function : NullObject, IFunction{
        /// <summary>
        /// 初始化函数
        /// </summary>
        public Function() {
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <param name="name">函数名</param>
        public Function( string name ) {
            Name = name;
        }

        /// <summary>
        /// 函数名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取脚本
        /// </summary>
        public string GetScript() {
            return Name;
        }

        /// <summary>
        /// 空函数
        /// </summary>
        public static IFunction Null {
            get { return new NullFunction();}
        }
    }
}
