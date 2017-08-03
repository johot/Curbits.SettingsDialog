using System;

namespace Curbits.SettingsDialog
{
    public class PropertyDecoratorAttribute : Attribute
    {
        public Type AttributeType { get; }

        public PropertyDecoratorAttribute(Type type)
        {
            AttributeType = type;
        }
    }
}