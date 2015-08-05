namespace Util.Maps.EmitMapper.Tests.Samples {
    public class User {
        /// <summary>
        /// 机构编号
        /// </summary>
        public System.Guid OrganizationId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 安全码
        /// </summary>
        public string SafePassword { get; set; }
        /// <summary>
        /// 安全邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 安全手机
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 密码问题
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// 密码答案
        /// </summary>
        public string Answer { get; set; }
        /// <summary>
        /// 锁定
        /// </summary>
        public bool IsLock { get; set; }
        /// <summary>
        /// 锁定起始时间
        /// </summary>
        public System.DateTime? LockBeginTime { get; set; }
        /// <summary>
        /// 锁定持续时间
        /// </summary>
        public int? LockTime { get; set; }
        /// <summary>
        /// 锁定提示消息
        /// </summary>
        public string LockMessage { get; set; }
        /// <summary>
        /// 上次登陆时间
        /// </summary>
        public System.DateTime? LastLoginTime { get; set; }
        /// <summary>
        /// 上次登陆Ip
        /// </summary>
        public string LastLoginIp { get; set; }
        /// <summary>
        /// 本次登陆时间
        /// </summary>
        public System.DateTime? CurrentLoginTime { get; set; }
        /// <summary>
        /// 本次登陆Ip
        /// </summary>
        public string CurrentLoginIp { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        public int? LoginTimes { get; set; }
        /// <summary>
        /// 登陆失败次数
        /// </summary>
        public int? LoginFailTimes { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 冻结时间
        /// </summary>
        public System.DateTime? DisableTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>
        /// 注册Ip
        /// </summary>
        public string RegisterIp { get; set; }
    }
}
