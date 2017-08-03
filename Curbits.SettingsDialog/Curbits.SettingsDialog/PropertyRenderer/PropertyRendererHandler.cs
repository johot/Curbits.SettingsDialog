using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Linq;

namespace Curbits.SettingsDialog
{
    public class PropertyRendererHandler
    {
        private IEnumerable<IPropertyRenderer> _propertyRenderers;

        public UIElement CreateControl(PropertyInfo propertyInfo, object propertySource)
        {
            if (_propertyRenderers == null)
            {
                var propertyRendererTypes = this.GetType().Assembly.GetTypes().Where(
                    t => IsPropertyRenderer(t)).ToList();

                _propertyRenderers = propertyRendererTypes.Select(t => (IPropertyRenderer)Activator.CreateInstance(t));
            }

            var propertyRenderer = SelectPropertyRenderer(propertyInfo);
            
            return propertyRenderer?.CreateControl(propertyInfo, propertySource);
        }

        private IPropertyRenderer SelectPropertyRenderer(PropertyInfo propertyInfo)
        {
            foreach (var propertyRenderer in _propertyRenderers)
            {
                var propertyRendererAttribute = (PropertyRendererAttribute)propertyRenderer.GetType().GetCustomAttributes().First(pr => pr is PropertyRendererAttribute);

                if (propertyInfo.PropertyType == propertyRendererAttribute.PropertyPropertyType)
                {
                    return propertyRenderer;
                }
            }

            // No match
            return null;
        }

        private static bool IsPropertyRenderer(Type t)
        {
            if (t.GetInterfaces().Contains(typeof(IPropertyRenderer)))
            {
                return t.GetCustomAttributes(true).Any(a => a is PropertyRendererAttribute);
            }

            return false;
        }


    }
}