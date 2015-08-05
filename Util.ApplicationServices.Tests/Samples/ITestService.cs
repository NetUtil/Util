using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.ApplicationServices.Tests.Samples {
    public interface ITestService: IDependency {
        string GetResult();
    }
}
