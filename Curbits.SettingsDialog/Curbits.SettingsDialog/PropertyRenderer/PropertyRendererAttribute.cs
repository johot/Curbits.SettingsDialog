using System;

namespace Curbits.SettingsDialog
{
    public class PropertyRendererAttribute : Attribute
    {
        public Type PropertyPropertyType { get; }

        public PropertyRendererAttribute(Type propertyType)
        {
            PropertyPropertyType = propertyType;
        }
    }
}