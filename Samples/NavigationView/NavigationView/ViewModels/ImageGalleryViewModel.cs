using Caliburn.Micro;

using DemoProject.Core.Models;
using DemoProject.Core.Services;
using DemoProject.Helpers;
using DemoProject.Services;

namespace DemoProject.ViewModels
{
    public class ImageGalleryViewModel : Screen
    {
        public const string ImageGallerySelectedIdKey = "ImageGallerySelectedIdKey";

        private readonly INavigationService _navigationService;
        private readonly IConnectedAnimationService _connectedAnimationService;

        public BindableCollection<SampleImage> Source { get; } = new BindableCollection<SampleImage>();

        public ImageGalleryViewModel(INavigationService navigationService, IConnectedAnimationService connectedAnimationService)
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

        public void OnImageSelected(SampleImage image)
        {
            ImagesNavigationHelper.AddImageId(ImageGallerySelectedIdKey, image.ID);
            _connectedAnimationService.SetListDataItemForNextConnectedAnimation(image);
            _navigationService.For<ImageGalleryDetailViewModel>()
                .WithParam(v => v.ID, image.ID)
                .Navigate();
        }
    }
}
