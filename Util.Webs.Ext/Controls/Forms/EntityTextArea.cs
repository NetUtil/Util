using System;
using System.Linq.Expressions;

namespace Util.Webs.Ext.Controls.Forms {
    /// <summary>
    /// 实体文本区
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class EntityTextArea<TEntity,TProperty> : TextArea {
        /// <summary>
        /// 初始化实体文本区
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        public EntityTextArea( Expression<Func<TEntity, TProperty>> propertyExpression ) {
            new EntityForm<EntityTextArea<TEntity, TProperty>, TEntity, TProperty>( this, propertyExpression );
        }
    }
}
