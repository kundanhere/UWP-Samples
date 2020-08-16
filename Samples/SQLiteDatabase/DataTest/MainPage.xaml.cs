using DataAccessLibrary;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPDataTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Output.ItemsSource = DataAccess.GetData();
        }

        private void AddData(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Input_Box.Text))
            {
                DataAccess.AddData(Input_Box.Text);

                Output.ItemsSource = DataAccess.GetData();
            }
        }
    }
}