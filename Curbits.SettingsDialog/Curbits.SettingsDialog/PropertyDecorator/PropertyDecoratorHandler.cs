using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Curbits.SettingsDialog
{
    public class PropertyDecoratorHandler
    {
        private IEnumerable<IPropertyDecorator> _propertyDecorators;

        public UIElement DecoratePropertyControl(PropertyInfo propertyInfo, UIElement propertyControl)
        {
            if (_propertyDecorators == null)
            {
                var propertyDecoratorTypes = this.GetType().Assembly.GetTypes().Where(
                    t => IsPropertyDecorator(t)).ToList();

                _propertyDecorators = propertyDecoratorTypes.Select(t => (IPropertyDecorator)Activator.CreateInstance(t));
            }

            var attributes = propertyInfo.GetCustomAttributes(true);

            foreach (Attribute attribute in attributes)
            {
                var propertyDecorator = SelectPropertyDecorator(attribute);

                if (propertyDecorator != null)
                {
                    propertyControl = propertyDecorator.DecoratePropertyControl(attribute, propertyControl);
                }
            }
            
            return propertyControl;
        }

        private IPropertyDecorator SelectPropertyDecorator(Attribute attribute)
        {
            foreach (var propertyDecorator in _propertyDecorators)
            {
                var propertyDecoratorAttribute = (PropertyDecoratorAttribute)propertyDecorator.GetType().GetCustomAttributes().First(pd => pd is PropertyDecoratorAttribute);

                if (propertyDecoratorAttribute.AttributeType == attribute.GetType())
                {
                    return propertyDecorator;
                }
            }

            // No match
            return null;
        }

        private bool IsPropertyDecorator(Type t)
        {
            if (t.GetInterfaces().Contains(typeof(IPropertyDecorator)))
            {
                return t.GetCustomAttributes(true).Any(a => a is PropertyDecoratorAttribute);
            }

            return false;
        }
    }
}
