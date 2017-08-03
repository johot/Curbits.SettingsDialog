using System;
using System.Linq;
using System.Reflection;

namespace Curbits.SettingsDialog.Common
{
    public static class ReflectionUtility
    {
        public static T TryGetAttribute<T>(PropertyInfo propertyInfo) where T : Attribute
        {
            var attribute = propertyInfo.GetCustomAttributes(true).FirstOrDefault(a => a is T);

            return (T) attribute;
        }
    }
}
