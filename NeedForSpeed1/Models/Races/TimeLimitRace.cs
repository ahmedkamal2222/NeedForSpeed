using NeedForSpeed1.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed1.Models.Races
{
    public class TimeLimitRace : Race
    {
        private const int SilverTimePrize = 50;
        private const int BronzeTimePrize = 30;


        public int GoldTime { get; set; }
        public TimeLimitRace(int length, string route, int prizePool, int goldTime)
            : base(length, route, prizePool)
        {
            GoldTime = goldTime;
        }

        public override void AddParticipants(int carId, Car car)
        {
            if (this.Participants.Count == 0)
            {
                base.Participants.Add(carId, car);
            }
        }

        public override int GetPoints(int carId)
        {
            Car car = Participants[carId];
            return Length * ((car.HorsePower / 100) * car.Acceleration);
        }

        public override string StartRace()
        {
            KeyValuePair<int, Car> car = Participants.ElementAt(0);
            int time = GetPoints(car.Key);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Route} - {Length}")
                .AppendLine($"{car.Value.Brand}  {car.Value.Model} - {time} s.");

            if (time <= GoldTime)
            {
                sb.Append($"Gold Time, ${PrizePool}.");
            }
            else if (time <= GoldTime + 15)
            {
                sb.Append($"Silver Time, ${PrizePool * SilverTimePrize / 100}.");
            }
            else if (time > GoldTime + 15)
            {
                sb.Append($"Bronze Time, ${PrizePool * BronzeTimePrize / 100}.");
            }

            return sb.ToString();
        }


    }
}
