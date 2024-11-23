using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed1.Models.Cars
{
    public abstract class Car
    {
        private const int HalfIndex = 50;

        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int HorsePower { get; set; }
        public int Acceleration { get; set; }
        public int Suspension { get; set; }
        public int Durability { get; set; }

        protected Car(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
        {
            Brand = brand;
            Model = model;
            YearOfProduction = yearOfProduction;
            HorsePower = horsePower;
            Acceleration = acceleration;
            Suspension = suspension;
            Durability = durability;
        }

        public virtual void Tune (int tuneIndex, string addOn)
        {
            HorsePower += tuneIndex;
            Suspension += tuneIndex * HalfIndex / 100;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Brand} {Model} {YearOfProduction}")
                .AppendLine($"{HorsePower} HP, 100 m/h in {Acceleration} s")
                .Append($"{Suspension} Suspension force, {Durability} Durability");

            return sb.ToString();
        }
    }
}
