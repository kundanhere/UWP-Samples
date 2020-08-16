using Caliburn.Micro;
using DemoProject.Core.Models;
using DemoProject.Core.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DemoProject.ViewModels
{
    public class ChartViewModel : Screen
    {
        public ObservableCollection<DataPoint> Source { get; } = new ObservableCollection<DataPoint>();

        public ChartViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            var data = await SampleDataService.GetChartDataAsync();
            foreach (var item in data)
            {
                Source.Add(item);
            }
        }
    }
}