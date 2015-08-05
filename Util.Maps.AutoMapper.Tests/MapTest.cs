using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Maps.EmitMapper.Tests.Samples;

namespace Util.Maps.AutoMapper.Tests {
    /// <summary>
    /// 映射测试
    /// </summary>
    [TestClass]
    public class MapTest {
        /// <summary>
        /// 用户
        /// </summary>
        private User _user;
        /// <summary>
        /// 映射器
        /// </summary>
        private IMap _map;

        /// <summary>
        /// 初始化
        /// </summary>
        [TestInitialize]
        public void Init() {
            _user = UserTest.Create();
            _map = new Mapper();
        }

        /// <summary>
        /// 验证属性值
        /// </summary>
        [TestMethod]
        public void Test() {
            UserDto info = _map.Map<User, UserDto>( _user );
            Assert.AreEqual( UserTest.OrganizationId, info.OrganizationId, "OrganizationId" );
            Assert.AreEqual( UserTest.UserName, info.UserName, "UserName" );
            Assert.AreEqual( UserTest.Password, info.Password, "Password" );
            Assert.AreEqual( UserTest.SafePassword, info.SafePassword, "SafePassword" );
            Assert.AreEqual( UserTest.Email, info.Email, "Email" );
            Assert.AreEqual( UserTest.MobilePhone, info.MobilePhone, "MobilePhone" );
            Assert.AreEqual( UserTest.Question, info.Question, "Question" );
            Assert.AreEqual( UserTest.Answer, info.Answer, "Answer" );
            Assert.AreEqual( UserTest.IsLock, info.IsLock, "IsLock" );
            Assert.AreEqual( UserTest.LockBeginTime, info.LockBeginTime, "LockBeginTime" );
            Assert.AreEqual( UserTest.LockTime, info.LockTime, "LockTime" );
            Assert.AreEqual( UserTest.LockMessage, info.LockMessage, "LockMessage" );
            Assert.AreEqual( UserTest.LastLoginTime, info.LastLoginTime, "LastLoginTime" );
            Assert.AreEqual( UserTest.LastLoginIp, info.LastLoginIp, "LastLoginIp" );
            Assert.AreEqual( UserTest.CurrentLoginTime, info.CurrentLoginTime, "CurrentLoginTime" );
            Assert.AreEqual( UserTest.CurrentLoginIp, info.CurrentLoginIp, "CurrentLoginIp" );
            Assert.AreEqual( UserTest.LoginTimes, info.LoginTimes, "LoginTimes" );
            Assert.AreEqual( UserTest.LoginFailTimes, info.LoginFailTimes, "LoginFailTimes" );
            Assert.AreEqual( UserTest.Note, info.Note, "Note" );
            Assert.AreEqual( UserTest.Enabled, info.Enabled, "Enabled" );
            Assert.AreEqual( UserTest.DisableTime, info.DisableTime, "DisableTime" );
            Assert.AreEqual( UserTest.CreateTime, info.CreateTime, "CreateTime" );
            Assert.AreEqual( UserTest.RegisterIp, info.RegisterIp, "RegisterIp" );
        }

        /// <summary>
        /// 验证赋值
        /// </summary>
        [TestMethod]
        public void TestAssign() {
            var info = new UserDto();
            _map.Map( _user, info );
            Assert.AreEqual( UserTest.OrganizationId, info.OrganizationId, "OrganizationId" );
            Assert.AreEqual( UserTest.UserName, info.UserName, "UserName" );
            Assert.AreEqual( UserTest.Password, info.Password, "Password" );
            Assert.AreEqual( UserTest.SafePassword, info.SafePassword, "SafePassword" );
            Assert.AreEqual( UserTest.Email, info.Email, "Email" );
            Assert.AreEqual( UserTest.MobilePhone, info.MobilePhone, "MobilePhone" );
            Assert.AreEqual( UserTest.Question, info.Question, "Question" );
            Assert.AreEqual( UserTest.Answer, info.Answer, "Answer" );
            Assert.AreEqual( UserTest.IsLock, info.IsLock, "IsLock" );
            Assert.AreEqual( UserTest.LockBeginTime, info.LockBeginTime, "LockBeginTime" );
            Assert.AreEqual( UserTest.LockTime, info.LockTime, "LockTime" );
            Assert.AreEqual( UserTest.LockMessage, info.LockMessage, "LockMessage" );
            Assert.AreEqual( UserTest.LastLoginTime, info.LastLoginTime, "LastLoginTime" );
            Assert.AreEqual( UserTest.LastLoginIp, info.LastLoginIp, "LastLoginIp" );
            Assert.AreEqual( UserTest.CurrentLoginTime, info.CurrentLoginTime, "CurrentLoginTime" );
            Assert.AreEqual( UserTest.CurrentLoginIp, info.CurrentLoginIp, "CurrentLoginIp" );
            Assert.AreEqual( UserTest.LoginTimes, info.LoginTimes, "LoginTimes" );
            Assert.AreEqual( UserTest.LoginFailTimes, info.LoginFailTimes, "LoginFailTimes" );
            Assert.AreEqual( UserTest.Note, info.Note, "Note" );
            Assert.AreEqual( UserTest.Enabled, info.Enabled, "Enabled" );
            Assert.AreEqual( UserTest.DisableTime, info.DisableTime, "DisableTime" );
            Assert.AreEqual( UserTest.CreateTime, info.CreateTime, "CreateTime" );
            Assert.AreEqual( UserTest.RegisterIp, info.RegisterIp, "RegisterIp" );
        }

        /// <summary>
        /// 性能测试 - AutoMapper映射器
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestPerformance_AutoMapper() {
            for ( int i = 0; i < 10000; i++ ) {
                UserDto dto = _map.Map<User, UserDto>( _user );
                _user = _map.Map<UserDto, User>( dto );
            }
        }

        /// <summary>
        /// 性能测试 - 硬编码
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestPerformance_HardCode() {
            for ( int i = 0; i < 1000000; i++ ) {
                UserDto dto = new UserDto( _user );
                _user = dto.ToEntity();
            }
        }
    }
}
