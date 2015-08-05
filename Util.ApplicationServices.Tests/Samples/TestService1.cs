using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.ApplicationServices.Tests.Samples {
    public class TestService1 : ITestService{
        public TestService1() {
        }
        public string GetResult() {
            return "TestService1";
        }
    }
}
