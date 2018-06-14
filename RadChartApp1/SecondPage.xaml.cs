using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace RadChartApp1
{
    public sealed partial class SecondPage : Page
    {
        private ObservableCollection<DataPoint> _source = new ObservableCollection<DataPoint>();

        public SecondPage()
        {
            this.InitializeComponent();

            _source.Add(new DataPoint { Category = "D", Value = 10 });
            _source.Add(new DataPoint { Category = "E", Value = 20 });
            _source.Add(new DataPoint { Category = "F", Value = 30 });

            DataContext = _source;
        }
    }
}
