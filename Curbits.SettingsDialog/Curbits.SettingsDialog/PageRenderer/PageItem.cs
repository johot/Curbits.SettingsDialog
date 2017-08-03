using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Curbits.SettingsDialog
{
    public class PageItem : TreeViewItem
    {
        public PageItem(string text, ImageSource iconSource, UIElement pageContent)
        {
            Header = GenerateContent(text, iconSource);
            PageContent = pageContent;
        }

        private object GenerateContent(string text, ImageSource iconSource)
        {
            var stackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };

            var icon = new Image()
            {
                Source = iconSource,
                Margin = new Thickness(0, 0, 5, 0),
                Height = 16
            };

            var label = new TextBlock()
            {
                Text = text
            };

            Title = text;

            stackPanel.Children.Add(icon);
            stackPanel.Children.Add(label);

            return stackPanel;
        }

        public string Title { get; set; }

        public UIElement PageContent { get; set; }
    }
}
