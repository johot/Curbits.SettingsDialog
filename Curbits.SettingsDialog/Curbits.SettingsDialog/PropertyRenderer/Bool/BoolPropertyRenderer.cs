using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Curbits.SettingsDialog
{
    [PropertyRenderer(typeof(bool))]
    public class BoolPropertyRenderer : IPropertyRenderer
    {
        public UIElement CreateControl(PropertyInfo propertyInfo, object propertySource)
        {
            var checkbox = new CheckBox();
            checkbox.Content = PropertyRendererUtility.GetPropertyControlTitle(propertyInfo);

            PropertyRendererUtility.CreateControlBinding(propertyInfo, propertySource, checkbox,
                ToggleButton.IsCheckedProperty);

            return checkbox;
        }
    }
}