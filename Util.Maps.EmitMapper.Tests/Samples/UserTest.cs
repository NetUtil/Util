namespace Util.Maps.EmitMapper.Tests.Samples {
    public class UserTest {

        #region 测试数据

        /// <summary>
        /// 用户编号
        /// </summary>
        public static readonly System.Guid UserId = "366a7e9f-acab-4707-9130-295409aed0ad".ToGuid();
        /// <summary>
        /// 机构编号
        /// </summary>
        public static readonly System.Guid OrganizationId = "366a7e9f-acab-4707-9130-295409aed0ad".ToGuid();
        /// <summary>
        /// 用户名
        /// </summary>
        public static readonly string UserName = "UserName";
        /// <summary>
        /// 密码
        /// </summary>
        public static readonly string Password = "Password";
        /// <summary>
        /// 安全码
        /// </summary>
        public static readonly string SafePassword = "SafePassword";
        /// <summary>
        /// 安全邮箱
        /// </summary>
        public static readonly string Email = "Email";
        /// <summary>
        /// 安全手机
        /// </summary>
        public static readonly string MobilePhone = "MobilePhone";
        /// <summary>
        /// 密码问题
        /// </summary>
        public static readonly string Question = "Question";
        /// <summary>
        /// 密码答案
        /// </summary>
        public static readonly string Answer = "Answer";
        /// <summary>
        /// 锁定
        /// </summary>
        public static readonly bool IsLock = true;
        /// <summary>
        /// 锁定起始时间
        /// </summary>
        public static readonly System.DateTime? LockBeginTime = Conv.ToDate( "2014/9/21 10:00:34" );
        /// <summary>
        /// 锁定持续时间
        /// </summary>
        public static readonly int? LockTime = 1;
        /// <summary>
        /// 锁定提示消息
        /// </summary>
        public static readonly string LockMessage = "LockMessage";
        /// <summary>
        /// 上次登陆时间
        /// </summary>
        public static readonly System.DateTime? LastLoginTime = Conv.ToDate( "2014/9/21 10:00:34" );
        /// <summary>
        /// 上次登陆Ip
        /// </summary>
        public static readonly string LastLoginIp = "LastLoginIp";
        /// <summary>
        /// 本次登陆时间
        /// </summary>
        public static readonly System.DateTime? CurrentLoginTime = Conv.ToDate( "2014/9/21 10:00:34" );
        /// <summary>
        /// 本次登陆Ip
        /// </summary>
        public static readonly string CurrentLoginIp = "CurrentLoginIp";
        /// <summary>
        /// 登陆次数
        /// </summary>
        public static readonly int? LoginTimes = 1;
        /// <summary>
        /// 登陆失败次数
        /// </summary>
        public static readonly int? LoginFailTimes = 1;
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Note = "Note";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 冻结时间
        /// </summary>
        public static readonly System.DateTime? DisableTime = Conv.ToDate( "2014/9/21 10:00:34" );
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly System.DateTime CreateTime = Conv.ToDate( "2014/9/21 10:00:34" );
        /// <summary>
        /// 注册Ip
        /// </summary>
        public static readonly string RegisterIp = "RegisterIp";

        #endregion

        #region 创建实体

        /// <summary>
        /// 创建用户实体
        /// </summary>
        public static User Create() {
            return new User() {
                OrganizationId = OrganizationId,
                UserName = UserName,
                Password = Password,
                SafePassword = SafePassword,
                Email = Email,
                MobilePhone = MobilePhone,
                Question = Question,
                Answer = Answer,
                IsLock = IsLock,
                LockBeginTime = LockBeginTime,
                LockTime = LockTime,
                LockMessage = LockMessage,
                LastLoginTime = LastLoginTime,
                LastLoginIp = LastLoginIp,
                CurrentLoginTime = CurrentLoginTime,
                CurrentLoginIp = CurrentLoginIp,
                LoginTimes = LoginTimes,
                LoginFailTimes = LoginFailTimes,
                Note = Note,
                Enabled = Enabled,
                DisableTime = DisableTime,
                CreateTime = CreateTime,
                RegisterIp = RegisterIp
            };
        }

        #endregion
    }
}
