using System;
using System.ComponentModel.DataAnnotations;

namespace Util.Domains.Tests.Sample {
    public class Test1 : EntityBase<Test1,Guid>{
        public Test1():base(Guid.NewGuid()) {
        }

        [MobilePhone]
        public string MobilePhone { get; set; }
    }
}
