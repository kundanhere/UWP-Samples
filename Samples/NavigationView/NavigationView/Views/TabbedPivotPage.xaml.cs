using DemoProject.ViewModels;

using Windows.UI.Xaml.Controls;

namespace DemoProject.Views
{
    public sealed partial class TabbedPivotPage : Page
    {
        public TabbedPivotPage()
        {
            InitializeComponent();
        }

        private TabbedPivotViewModel ViewModel
        {
            get { return DataContext as TabbedPivotViewModel; }
        }
    }
}