using NeedForSpeed1.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed1.Models.Races
{
    public class CircuitRace : CasualRace
    {

        public int Laps { get; set; }
        public CircuitRace(int length, string route, int prizePool, int laps)
            : base(length, route, prizePool)
        {
            Laps = laps;
        }

        public override string StartRace()
        {
            for (int i = 0; i < Laps; i++)
            {
                foreach (KeyValuePair<int, Car> car in Participants)
                {
                    car.Value.Durability -= Length * Length;
                }
            }

            Dictionary<int, int> reaceResults = new Dictionary<int, int>();
            foreach (KeyValuePair<int, Car> car in Participants )
            {
                int carPoints = GetPoints(car.Key);
                reaceResults.Add(car.Key, carPoints);
            }

            Dictionary<int, int> winners = reaceResults
                .OrderByDescending(c => c.Value)
                .Take(4)
                .ToDictionary(k => k.Value, v => v.Value);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Route} - {Length * Laps}");
            int position = 1;
            foreach (KeyValuePair<int , int> winner in winners)
            {
                Car car = Participants[winner.Key];
                sb.AppendLine($"{position}. {car.Brand} {car.Model} {winner.Value}PP - ${GetPrize()[position - 1]}");
                position++;
            }
            return sb.ToString().Trim();
        }

        public override List<int> GetPrize()
        {
            List<int> prizes = new List<int>();
            prizes.Add(PrizePool * 40 / 100);
            prizes.Add(PrizePool * 30 / 100);
            prizes.Add(PrizePool * 20 / 100);
            prizes.Add(PrizePool * 10 / 100);

            return prizes;
        }
    }
}
