using System.Windows.Controls;

using CustomWpf.ViewModel;

namespace CustomWpf.View
{
    public partial class CarManagementView : UserControl
    {
        public CarManagementView()
        {
            this.InitializeComponent();

            this.DataContext = new CarManagementViewModel();
        }
    }
}
