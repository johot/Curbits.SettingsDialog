using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Curbits.SettingsDialog
{
    public static class PropertyRendererUtility
    {
        public static void CreateControlBinding(PropertyInfo propertyInfo, object propertySource, UIElement control,
            DependencyProperty dependencyProperty)
        {
            var binding = new Binding();
            binding.Source = propertySource;
            binding.Path = new PropertyPath(propertyInfo.Name);
            BindingOperations.SetBinding(control, dependencyProperty, binding);
        }

        private static string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + string.Join("", input.Skip(1));
        }

        private static string FormatPropertyName(string input)
        {
            var text = Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();

            text = FirstCharToUpper(text.ToLowerInvariant());

            return text;
        }

        public static string GetPropertyControlTitle(PropertyInfo propertyInfo)
        {
            var titleAttribute = propertyInfo.GetCustomAttributes(true).FirstOrDefault(a => a is TitleAttribute);

            if (titleAttribute == null)
                return FormatPropertyName(propertyInfo.Name);
            return ((TitleAttribute) titleAttribute).Title;
        }

        public static StackPanel GroupIntoStackPanel(UIElement propertyControl)
        {
            var stackPanel = new StackPanel();

            stackPanel.Children.Add(propertyControl);

            return stackPanel;
        }
    }
}