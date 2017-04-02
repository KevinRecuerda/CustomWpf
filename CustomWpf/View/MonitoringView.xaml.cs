using CustomWpf.ViewModel;
using System.Windows.Controls;

namespace CustomWpf.View
{
    public partial class MonitoringView : UserControl
    {
        public MonitoringView()
        {
            this.InitializeComponent();

            this.DataContext = new MonitoringViewModel();
        }
    }
}
