using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Curbits.SettingsDialog
{
    /// <summary>
    ///     Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SettingsPanel : UserControl
    {
        #region Fields

        private readonly PageRendererHandler _pageRendererHandler;

        #endregion

        public SettingsPanel()
        {
            _pageRendererHandler = new PageRendererHandler(
                new PropertyRendererHandler(),
                new PropertyDecoratorHandler());

            InitializeComponent();

            Pages.SelectedItemChanged += Pages_SelectedItemChanged;

            OK.Click += OK_Click;

            DataContextChanged += SettingsPanel_DataContextChanged;
        }

        private void BuildGUI(object settingsData)
        {
            // For all class properties we create the different pages
            var classProperties = settingsData.GetType().GetProperties().Where(p => p.PropertyType.IsClass);

            foreach (var classProperty in classProperties)
            {
                var pageItem = _pageRendererHandler.CreatePageItem(classProperty, classProperty.GetValue(settingsData));

                Pages.Items.Add(pageItem);
            }

            // Select top item
            ((TreeViewItem) Pages.Items[0]).IsSelected = true;
        }
        
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            var settings = DataContext;
        }

        private void Pages_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = (PageItem) e.NewValue;

            PageContent.Content = selectedItem.PageContent;
            PageHeader.Text = selectedItem.Title;
        }

        private void SettingsPanel_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            BuildGUI(e.NewValue);
        }
    }
}