using NeedForSpeed1.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed1.Models.Races
{
    public abstract class Race
    {

        public int Length { get; set; }
        public string Route { get; set; }
        public int PrizePool { get; set; }
        public Dictionary<int, Car> Participants { get; set; }

        public Race(int length, string route, int prizePool)
        {
            Length = length;
            Route = route;
            PrizePool = prizePool;
            Participants = new Dictionary<int, Car>();
        }

        public abstract int GetPoints(int carId);

        public virtual void AddParticipants (int carId, Car car)
        {
            Participants.Add(carId, car);
        }

        public virtual string StartRace ()
        {
            Dictionary<int, int> raceResualts = new Dictionary<int, int>();

            foreach (KeyValuePair<int, Car> car in Participants)
            {
                int carPoints = GetPoints(car.Key);
                raceResualts.Add(car.Key, carPoints);
            }

            Dictionary<int, int> winners = raceResualts
                .OrderByDescending(r => r.Value)
                .Take(3)
                .ToDictionary(k => k.Key, v => v.Value);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Route} - {Length}");
            int position = 1;
            foreach (KeyValuePair<int, int> winner in winners)
            {
                Car car = Participants[winner.Key];
                sb.AppendLine($"{position}. {car.Brand} {car.Model} {winner.Value}PP - ${GetPrize()[position - 1]}");
                position++;
            }

            return sb.ToString().Trim();
        }

        public virtual List<int> GetPrize()
        {
            List<int> prizes = new List<int>();
            prizes.Add(this.PrizePool * 50 / 100);
            prizes.Add(this.PrizePool * 30 / 100);
            prizes.Add(this.PrizePool * 20 / 100);
            return prizes;
        }
    }
}
