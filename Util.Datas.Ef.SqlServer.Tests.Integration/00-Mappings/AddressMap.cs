using Util.Domains.Tests.Sample;

namespace Util.Datas.Ef.SqlServer.Tests.Integration {
    /// <summary>
    /// 地址映射
    /// </summary>
    public class AddressMap : ValueObjectMapBase<Address> {
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            base.Property( t => t.City ).HasColumnName( "City" );
            base.Property( t => t.Street ).HasColumnName( "Street" );
        }
    }
}
