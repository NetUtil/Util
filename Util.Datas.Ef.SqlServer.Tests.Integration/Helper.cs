namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 辅助操作
    /// </summary>
    public class Helper {
        /// <summary>
        /// 获取数据上下文
        /// </summary>
        public static EfUnitOfWork GetEfContext() {
            return new TestDbContext();
        }

        /// <summary>
        /// 获取数据上下文2
        /// </summary>
        public static EfUnitOfWork GetEfContext2() {
            return new TestDbContext2();
        }
    }
}
