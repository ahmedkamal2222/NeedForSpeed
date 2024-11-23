using NeedForSpeed1.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed1.Models.Races
{
    public class DriftRace : Race
    {
        public DriftRace(int length, string route, int prizePool)
            : base(length, route, prizePool)
        {
        }

        public override int GetPoints(int carId)
        {
            Car car = Participants[carId];
            return car.Suspension + car.Durability;
        }
    }
}
