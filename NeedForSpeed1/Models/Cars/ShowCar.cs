using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed1.Models.Cars
{
    public class ShowCar : Car
    {

        public int Stars { get; set; }

        public ShowCar(string brand, string model, int yearOfProduction, int horePower, int acceleration, int suspension, int durability)
            : base(brand, model, yearOfProduction, horePower, acceleration, suspension, durability)
        {
            Stars = 0;
        }

        public override void Tune(int tuneIndex, string addOn)
        {
            base.Tune(tuneIndex, addOn);
            Stars += tuneIndex;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString())
                .Append($"{this.Stars} *");
            return sb.ToString();
        }
    }
}
