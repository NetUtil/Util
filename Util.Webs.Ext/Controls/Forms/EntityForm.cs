using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Util.Webs.Ext.Controls.Forms {
    /// <summary>
    /// 实体表单
    /// </summary>
    internal class EntityForm<TComponent, TEntity, TProperty> where TComponent : ITextBox<IComponent> {
        /// <summary>
        /// 初始化实体表单
        /// </summary>
        /// <param name="component">组件</param>
        /// <param name="propertyExpression">属性表达式</param>
        public EntityForm( TComponent component, Expression<Func<TEntity, TProperty>> propertyExpression ) {
            _component = component;
            _expression = propertyExpression;
            InitDisplay();
            InitValidations();
        }

        /// <summary>
        /// 组件
        /// </summary>
        private readonly TComponent _component;
        /// <summary>
        /// 属性表达式
        /// </summary>
        private readonly Expression<Func<TEntity, TProperty>> _expression;

        /// <summary>
        /// 初始化标签文本
        /// </summary>
        private void InitDisplay() {
            var attribute = Lambda.GetAttribute<TEntity, TProperty, DisplayAttribute>( _expression );
            _component.Label( attribute.Name );
        }

        /// <summary>
        /// 初始化验证
        /// </summary>
        private void InitValidations() {
            var attributes = Lambda.GetAttributes<TEntity, TProperty, ValidationAttribute>( _expression );
            foreach ( var attribute in attributes ) {
                InitRequired( attribute as RequiredAttribute );
            }
        }

        /// <summary>
        /// 初始化必填项验证
        /// </summary>
        private void InitRequired( RequiredAttribute attribute ) {
            if ( attribute == null )
                return;
            _component.Required( attribute.GetErrorMessage() );
        }
    }
}
