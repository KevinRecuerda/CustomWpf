namespace CustomWpf.Model
{
    public class Car
    {
        public string Make;
        public string Name;
        public int Power;
        public int TopSpeed;

        public Car(string make, string name, int power, int topSpeed)
        {
            this.Make = make;
            this.Name = name;
            this.Power = power;
            this.TopSpeed = topSpeed;
        }

        public Car(Car car)
            : this(car.Make, car.Name, car.Power, car.TopSpeed)
        {
        }
    }
}