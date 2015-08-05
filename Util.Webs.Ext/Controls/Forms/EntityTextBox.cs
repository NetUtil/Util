using System;
using System.Linq.Expressions;

namespace Util.Webs.Ext.Controls.Forms {
    /// <summary>
    /// 实体文本框
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class EntityTextBox<TEntity,TProperty> : TextBox {
        /// <summary>
        /// 初始化实体文本框
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        public EntityTextBox( Expression<Func<TEntity, TProperty>> propertyExpression ) {
            new EntityForm<EntityTextBox<TEntity, TProperty>, TEntity, TProperty>( this, propertyExpression );
        }
    }
}
