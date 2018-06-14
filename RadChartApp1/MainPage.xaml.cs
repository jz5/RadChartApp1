using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RadChartApp1
{
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<DataPoint> _source = new ObservableCollection<DataPoint>();

        public MainPage()
        {
            this.InitializeComponent();

            _source.Add(new DataPoint { Category = "A", Value = 10 });
            _source.Add(new DataPoint { Category = "B", Value = 20 });
            _source.Add(new DataPoint { Category = "C", Value = 30 });

            DataContext = _source;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentViewId = ApplicationView.GetForCurrentView().Id;
            await CoreApplication.CreateNewView().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                Window.Current.Content = new Frame();
                ((Frame)Window.Current.Content).Navigate(typeof(SecondPage));
                Window.Current.Activate();
                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                    ApplicationView.GetApplicationViewIdForWindow(Window.Current.CoreWindow),
                    ViewSizePreference.Default,
                    currentViewId,
                    ViewSizePreference.Default);
            });
        }
    }
}
