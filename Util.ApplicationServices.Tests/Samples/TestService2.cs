using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.ApplicationServices.Tests.Samples {
    public class TestService2 : ITestService{
        public TestService2() {
        }

        public string GetResult() {
            return "TestService2";
        }
    }
}
