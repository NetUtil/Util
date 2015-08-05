using System;
using System.Linq.Expressions;

namespace Util.Webs.Ext {
    /// <summary>
    /// Ext工厂
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IExtFactory<TEntity> : IExtFactory {
        /// <summary>
        /// 创建文本框
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="perpertyExpression">属性表达式</param>
        ITextBox CreateTextBox<TProperty>( Expression<Func<TEntity, TProperty>> perpertyExpression );
        /// <summary>
        /// 创建组合框
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="perpertyExpression">属性表达式</param>
        IComboBox CreateComboBox<TProperty>( Expression<Func<TEntity, TProperty>> perpertyExpression );
        /// <summary>
        /// 创建文本区
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="perpertyExpression">属性表达式</param>
        ITextArea CreateTextArea<TProperty>( Expression<Func<TEntity, TProperty>> perpertyExpression );
    }
}
