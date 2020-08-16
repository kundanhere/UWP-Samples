using Caliburn.Micro;
using DemoProject.Core.Models;
using DemoProject.Core.Services;
using DemoProject.Helpers;
using DemoProject.Services;
using System.Linq;
using Windows.System;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace DemoProject.ViewModels
{
    public class ImageGalleryDetailViewModel : Screen
    {
        private readonly INavigationService _navigationService;
        private readonly IConnectedAnimationService _connectedAnimationService;
        private SampleImage _selectedImage;

        public SampleImage SelectedImage
        {
            get => _selectedImage;
            set
            {
                Set(ref _selectedImage, value);
                ImagesNavigationHelper.UpdateImageId(ImageGalleryViewModel.ImageGallerySelectedIdKey, SelectedImage.ID);
            }
        }

        public string ID { get; set; }

        public BindableCollection<SampleImage> Source { get; } = new BindableCollection<SampleImage>();

        public ImageGalleryDetailViewModel(INavigationService navigationService, IConnectedAnimationService connectedAnimationService)
        {
            _navigationService = navigationService;
            _connectedAnimationService = connectedAnimationService;
        }

        protected override async void OnInitialize()
        {
            base.OnInitialize();
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            Source.AddRange(await SampleDataService.GetImageGalleryDataAsync("ms-appx:///Assets"));
        }

        public void Initialize(NavigationMode navigationMode)
        {
            if (!string.IsNullOrEmpty(ID) && navigationMode == NavigationMode.New)
            {
                SelectedImage = Source.First(i => i.ID == ID);
            }
            else
            {
                var selectedImageId = ImagesNavigationHelper.GetImageId(ImageGalleryViewModel.ImageGallerySelectedIdKey);
                if (!string.IsNullOrEmpty(selectedImageId))
                {
                    SelectedImage = Source.FirstOrDefault(i => i.ID == selectedImageId);
                }
            }
        }

        public void OnPageKeyDown(KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Escape && _navigationService.CanGoBack)
            {
                _navigationService.GoBack();
                e.Handled = true;
            }
        }

        public void UpdateConnectedAnimation()
        {
            _connectedAnimationService.SetListDataItemForNextConnectedAnimation(SelectedImage);
            ImagesNavigationHelper.RemoveImageId(ImageGalleryViewModel.ImageGallerySelectedIdKey);
        }
    }
}
