using System;
using System.Windows;
using System.Windows.Controls;

namespace Curbits.SettingsDialog
{
    [PropertyDecorator(typeof(SectionHeaderAttribute))]
    public class SectionHeaderPropertyDecorator : IPropertyDecorator
    {
        public UIElement DecoratePropertyControl(Attribute attribute, UIElement propertyControl)
        {
            var sectionHeaderAttribute = (SectionHeaderAttribute) attribute;
            var inStackPanel = PropertyRendererUtility.GroupIntoStackPanel(propertyControl);

            inStackPanel.Children.Insert(0, CreateTextBlock(sectionHeaderAttribute));

            return inStackPanel;
        }

        private static TextBlock CreateTextBlock(SectionHeaderAttribute sectionHeaderAttribute)
        {
            return new TextBlock
            {
                Text = sectionHeaderAttribute.Text,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 0, 0, 5.0d)
            };
        }
    }
}