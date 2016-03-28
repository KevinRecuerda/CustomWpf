using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DeepEqual.Syntax;
using GalaSoft.MvvmLight;

namespace CustomWpf.Model
{
    public class CarView : AlterableObservableObject<Car>
    {
        public CarView(Car car)
            : base()
        {
            this.Item = car;
            this.ItemBeforeChanges = new Car(car);
        }
        
        public string Make
        {
            get { return this.Item.Make; }
            set { this.Set(ref this.Item.Make, value); }
        }
        public string Name
        {
            get { return this.Item.Name; }
            set { this.Set(ref this.Item.Name, value); }
        }
        public int Power
        {
            get { return this.Item.Power; }
            set { this.Set(ref this.Item.Power, value); }
        }
        public int TopSpeed
        {
            get { return this.Item.TopSpeed; }
            set { this.Set(ref this.Item.TopSpeed, value); }
        }
    }
}