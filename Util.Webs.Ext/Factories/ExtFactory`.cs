using System;
using System.Linq.Expressions;
using Util.Webs.Ext.Controls.Forms;

namespace Util.Webs.Ext.Factories {
    /// <summary>
    /// Ext工厂
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class ExtFactory<TEntity> : ExtFactory,IExtFactory<TEntity> {
        /// <summary>
        /// 创建文本框
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="perpertyExpression">属性表达式</param>
        public ITextBox CreateTextBox<TProperty>( Expression<Func<TEntity, TProperty>> perpertyExpression ) {
            return new EntityTextBox<TEntity, TProperty>( perpertyExpression );
        }

        /// <summary>
        /// 创建组合框
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="perpertyExpression">属性表达式</param>
        public IComboBox CreateComboBox<TProperty>( Expression<Func<TEntity, TProperty>> perpertyExpression ) {
            return new EntityComboBox<TEntity, TProperty>( perpertyExpression );
        }

        /// <summary>
        /// 创建文本区
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="perpertyExpression">属性表达式</param>
        public ITextArea CreateTextArea<TProperty>( Expression<Func<TEntity, TProperty>> perpertyExpression ) {
            return new EntityTextArea<TEntity, TProperty>( perpertyExpression );
        }
    }
}
