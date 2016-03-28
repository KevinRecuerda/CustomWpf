using System.Collections.ObjectModel;
using CustomWpf.Model;
using GalaSoft.MvvmLight;

namespace CustomWpf.ViewModel
{
    public class CarManagementViewModel : ViewModelBase
    {
        private ObservableCollection<CarView> cars;

        public ObservableCollection<CarView> Cars
        {
            get { return this.cars; }
            set { this.Set(ref this.cars, value); }
        }

        public CarManagementViewModel()
        {
            this.Cars = new ObservableCollection<CarView>()
            {
                new CarView(new Car("Ford", "Focus RS", 350, 290)),
                new CarView(new Car("Ford", "Fiesta RS", 220, 250)),
                new CarView(new Car("Lamborghini", "Aventador", 600, 340)),
                new CarView(new Car("Audi", "R8", 550, 320)),
                new CarView(new Car("BMW", "M6", 550, 310)),
                new CarView(new Car("BMW", "M4", 450, 300))
            };

            this.Cars[0].ArePropertiesModified["TopSpeed"] = true;
        }
    }
}