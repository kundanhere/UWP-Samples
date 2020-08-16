using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NavigationHistory
{
    public sealed partial class MainPage : Page
    {
        #region default constructor

        public MainPage()
        {
            this.InitializeComponent();
            // by default frame navigates to BlankPage1
            frame.Navigate(typeof(BlankPage1));
            // Register event to handle back request
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
        }

        #endregion default constructor

        #region Methods

        private async Task GoBackAsync()
        {
            // handle back request
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (frame != null && frame.CanGoBack) frame.GoBack();
            });
        }

        private async Task GoForwardAsync()
        {
            // handle forward request
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                if (frame != null && frame.CanGoForward) frame.GoForward();
            });
        }

        #endregion Methods

        #region Events

        private void OnNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            // Each time a navigation event occurs, update the Back button's visibility
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = ((Frame)sender).CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;

            // change padding of "app name container"
            appNameContainer.Padding = frame.CanGoBack ? new Thickness(62, 0, 0, 0) : new Thickness(12, 0, 0, 0);

            // Toggle next and previous button
            next.IsEnabled = frame.CanGoForward;
            prev.IsEnabled = frame.CanGoBack;
        }

        private async void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            await GoBackAsync();
            e.Handled = true;
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(BlankPage1));
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(BlankPage2));
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(typeof(BlankPage3));
        }

        private async void Back_Click(object sender, RoutedEventArgs e)
        {
            await GoBackAsync();
        }

        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            await GoForwardAsync();
        }

        #endregion Events
    }
}