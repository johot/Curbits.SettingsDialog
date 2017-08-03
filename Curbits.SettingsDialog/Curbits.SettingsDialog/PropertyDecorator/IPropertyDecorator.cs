using System;
using System.Windows;

namespace Curbits.SettingsDialog
{
    public interface IPropertyDecorator
    {
        UIElement DecoratePropertyControl(Attribute attribute, UIElement propertyControl);
    }
}