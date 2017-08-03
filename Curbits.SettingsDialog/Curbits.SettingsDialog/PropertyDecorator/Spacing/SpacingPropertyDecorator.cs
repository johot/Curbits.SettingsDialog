using System;
using System.Windows;
using System.Windows.Controls;

namespace Curbits.SettingsDialog
{
    [PropertyDecorator(typeof(SpacingAttribute))]
    public class SpacingPropertyDecorator : IPropertyDecorator
    {
        public UIElement DecoratePropertyControl(Attribute attribute, UIElement propertyControl)
        {
            var spacingAttribute = (SpacingAttribute) attribute;
            var border = GroupIntoBorder(propertyControl);
            
            border.Margin = new Thickness(0.0d, spacingAttribute.SpacingTop, 0.0d, spacingAttribute.SpacingBottom);

            return border;
        }
        
        private Border GroupIntoBorder(UIElement propertyControl)
        {
            var border = new Border();

            border.Child = propertyControl;

            return border;
        }
    }
}