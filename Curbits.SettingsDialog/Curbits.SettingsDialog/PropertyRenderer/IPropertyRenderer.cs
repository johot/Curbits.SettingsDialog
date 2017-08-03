using System.Reflection;
using System.Windows;

namespace Curbits.SettingsDialog
{
    public interface IPropertyRenderer
    {
        UIElement CreateControl(PropertyInfo property, object propertySource);
    }
}