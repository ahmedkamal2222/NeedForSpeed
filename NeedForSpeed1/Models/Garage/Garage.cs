using NeedForSpeed1.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed1.Models.Garage
{
    internal class Garage
    {

        public List<Car> ParkedCars { get; set; }
        public Garage()
        {
            ParkedCars = new List<Car>();
        }
    }
}
