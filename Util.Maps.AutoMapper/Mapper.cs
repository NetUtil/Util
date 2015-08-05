using map = AutoMapper;

namespace Util.Maps.AutoMapper {
    /// <summary>
    /// AutoMapper映射器
    /// </summary>
    public class Mapper : IMap {
        /// <summary>
        /// 创建目标对象,并从源对象复制属性值
        /// </summary>
        /// <typeparam name="TSource">源对象类型</typeparam>
        /// <typeparam name="TTarget">目标对象类型</typeparam>
        /// <param name="source">源对象</param>
        public TTarget Map<TSource, TTarget>( TSource source ) {
            return map.Mapper.DynamicMap<TSource, TTarget>( source );
        }

        /// <summary>
        /// 将源对象的值赋给目标对象
        /// </summary>
        /// <typeparam name="TSource">源对象类型</typeparam>
        /// <typeparam name="TTarget">目标对象类型</typeparam>
        /// <param name="source">源对象</param>
        /// <param name="target">目标对象</param>
        public void Map<TSource, TTarget>( TSource source, TTarget target ) {
            map.Mapper.DynamicMap( source, target );
        }
    }
}
