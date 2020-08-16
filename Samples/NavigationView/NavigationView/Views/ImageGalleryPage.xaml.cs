using DemoProject.ViewModels;

using Windows.UI.Xaml.Controls;

namespace DemoProject.Views
{
    public sealed partial class ImageGalleryPage : Page
    {
        public ImageGalleryPage()
        {
            InitializeComponent();
        }

        private ImageGalleryViewModel ViewModel
        {
            get { return DataContext as ImageGalleryViewModel; }
        }
    }
}