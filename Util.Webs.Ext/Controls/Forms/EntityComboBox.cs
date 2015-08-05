using System;
using System.Linq.Expressions;

namespace Util.Webs.Ext.Controls.Forms {
    /// <summary>
    /// 实体组合框
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class EntityComboBox<TEntity, TProperty> : ComboBox {
        /// <summary>
        /// 初始化实体组合框
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        public EntityComboBox( Expression<Func<TEntity, TProperty>> propertyExpression ) {
            new EntityForm<EntityComboBox<TEntity, TProperty>, TEntity, TProperty>( this, propertyExpression );
        }
    }
}
