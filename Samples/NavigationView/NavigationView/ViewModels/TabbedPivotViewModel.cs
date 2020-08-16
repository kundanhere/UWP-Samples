using Caliburn.Micro;

using DemoProject.Helpers;

namespace DemoProject.ViewModels
{
    public class TabbedPivotViewModel : Conductor<Screen>.Collection.OneActive
    {
        public TabbedPivotViewModel()
        {
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            // WTS Add view models to the Items collection to display them in the Tabs
            Items.Add(new ExampleTabViewModel { DisplayName = "TabbedPivotExampleTabPage1_DisplayName".GetLocalized() });
            Items.Add(new ExampleTabViewModel { DisplayName = "TabbedPivotExampleTabPage2_DisplayName".GetLocalized() });
        }
    }
}
