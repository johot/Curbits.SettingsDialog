using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Curbits.SettingsDialog.Common;
using FontAwesome.WPF;

namespace Curbits.SettingsDialog
{
    public class PageRendererHandler
    {
        #region Fields

        private const double SPACING_BETWEEN_ITEMS = 5.0d;

        private readonly PropertyDecoratorHandler _propertyDecoratorHandler;
        private readonly PropertyRendererHandler _propertyRendererHandler;

        #endregion

        public PageRendererHandler(PropertyRendererHandler propertyRendererHandler,
            PropertyDecoratorHandler propertyDecoratorHandler)
        {
            _propertyRendererHandler = propertyRendererHandler;
            _propertyDecoratorHandler = propertyDecoratorHandler;
        }

        private UIElement CreatePageContent(object settingsData)
        {
            var pageContent = new StackPanel();

            // Get properties
            var properties = settingsData.GetType().GetProperties();

            foreach (var propertyInfo in properties)
            {
                var propertyControl = _propertyRendererHandler.CreateControl(propertyInfo, settingsData);

                propertyControl = _propertyDecoratorHandler.DecoratePropertyControl(propertyInfo, propertyControl);

                // We add a small spacing between all items
                if (propertyControl is FrameworkElement)
                {
                    var propertyControlFrameworkElement = (FrameworkElement) propertyControl;
                    propertyControlFrameworkElement.Margin = new Thickness(propertyControlFrameworkElement.Margin.Left,
                        propertyControlFrameworkElement.Margin.Top, propertyControlFrameworkElement.Margin.Right,
                        propertyControlFrameworkElement.Margin.Bottom + SPACING_BETWEEN_ITEMS);
                }

                if (propertyControl != null)
                    pageContent.Children.Add(propertyControl);
            }

            return pageContent;
        }

        public PageItem CreatePageItem(PropertyInfo propertyInfo, object propertySource)
        {
            var pageContent = CreatePageContent(propertySource);

            ImageSource iconSource = null;

            var fontAwesomeIcon = ReflectionUtility.TryGetAttribute<FontAwesomeIconAttribute>(propertyInfo);

            if (fontAwesomeIcon != null)
                iconSource = ImageAwesome.CreateImageSource(fontAwesomeIcon.FontAwesomeIcon, Brushes.Black);

            return new PageItem(PropertyRendererUtility.GetPropertyControlTitle(propertyInfo), iconSource, pageContent);
        }
    }
}