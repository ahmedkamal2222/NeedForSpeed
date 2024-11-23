    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed1.Models.Cars
{
    internal class PerformanceCar : Car
    {
        private const int IncreaseHorsePower = 50;
        private const int DecreaseSuspension = 25;

        public List<string> AddOns { get; set; }   

        public PerformanceCar(string brand, string model, int yearOfProduction, int horePower, int acceleration, int suspension, int durability)
            : base(brand, model, yearOfProduction, horePower, acceleration, suspension, durability)
        {
            AddOns = new List<string>();
            HorsePower += HorsePower * IncreaseHorsePower / 100;
            Suspension -= Suspension * DecreaseSuspension / 100;
        }

        public override void Tune(int tuneIndex, string addOn)
        {
            base.Tune(tuneIndex, addOn);
            AddOns.Add(addOn);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (this.AddOns.Count == 0)
            {
                sb.Append("Add-ons: None");
            }
            else
            {
                sb.Append($"Add-ons: {string.Join(", ", AddOns)}");
            }
            return sb.ToString();
        }
    }
}
