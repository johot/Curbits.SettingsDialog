using System;
using System.Windows;
using System.Windows.Controls;

namespace Curbits.SettingsDialog
{
    [PropertyDecorator(typeof(DescriptionAttribute))]
    public class DescriptionPropertyDecorator : IPropertyDecorator
    {
        public UIElement DecoratePropertyControl(Attribute attribute, UIElement propertyControl)
        {
            var descriptionAttribute = (DescriptionAttribute) attribute;
            var inStackPanel = PropertyRendererUtility.GroupIntoStackPanel(propertyControl);

            inStackPanel.Children.Add(new TextBlock
            {
                Margin = new Thickness(0, 3.0d, 0.0d, 0.0d),
                Text = descriptionAttribute.Text
            });

            return inStackPanel;
        }
    }
}