using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Webs.Ext.Services.Impl;

namespace Util.Webs.Ext.Tests.ExtServices {
    /// <summary>
    /// Ext服务测试
    /// </summary>
    [TestClass]
    public partial class ExtServiceTest {
        /// <summary>
        /// ext服务
        /// </summary>
        private IExtService _service;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _service = new ExtService();
        }
    }
}
