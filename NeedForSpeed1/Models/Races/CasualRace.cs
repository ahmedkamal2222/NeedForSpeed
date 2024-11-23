using NeedForSpeed1.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed1.Models.Races
{
    public class CasualRace : Race
    {
        public CasualRace(int length, string route, int prizePool)
            : base(length, route, prizePool)
        {
        }

        public override int GetPoints(int carId)
        {
            Car car = Participants[carId];
            return (car.HorsePower / car.Acceleration) + (car.Suspension + car.Durability);
        }
    }
}
