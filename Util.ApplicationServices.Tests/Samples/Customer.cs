using System;
using Util.Domains;

namespace Util.ApplicationServices.Tests.Samples {
    public class Customer : AggregateRoot<Customer> {
        public Customer( Guid id ) : base( id ) {
        }
    }
}
