using NeedForSpeed1.Models.Cars;
using NeedForSpeed1.Models.Garage;
using NeedForSpeed1.Models.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed1.Controller
{
    internal class CarManager
    {
        private Dictionary<int, Car> Cars;
        private Dictionary<int, Race> Races;
        private Garage Garage;
        private List<int> IdClosedRace;

        public CarManager()
        {
            Cars = new Dictionary<int, Car>();
            Races = new Dictionary<int, Race>();
            Garage = new Garage();
            IdClosedRace = new List<int>();
        }

        public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
        {
            switch (type)
            {
                case "Performance":
                    PerformanceCar performanceCar = new PerformanceCar(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability);
                    Cars.Add(id, performanceCar);
                    break;

                case "ShowCar":
                    ShowCar showCar = new ShowCar(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability);
                    Cars.Add(id, showCar);
                    break;
            }
        }

        public string Check (int id)
        {
            return Cars[id].ToString();
        }

        public void Open(int id, string type, int length, string route, int prizePool)
        {
            switch (type)
            {
                case "Casual":
                    CasualRace casualRace = new CasualRace(length, route, prizePool);
                    Races.Add(id, casualRace);
                    break;

                case "DrageRace":
                    DragRace dragRace = new DragRace(length, route, prizePool);
                    Races.Add(id, dragRace);
                    break;

                case "DriftRace":
                    DriftRace driftRace = new DriftRace(length, route, prizePool);
                    Races.Add(id, driftRace);
                    break;
            }
        }

        public void Participate (int carId, int raceId)
        {
            if (!Garage.ParkedCars.Contains(Cars[carId]))
            {
                if (!IdClosedRace.Contains(raceId))
                {
                    Races[raceId].AddParticipants(carId, Cars[carId]);
                }
            }
        }

        public string Start (int id)
        {
            if (Races[id].Participants.Count() == 0 )
            {
                return "Cannot start the race with zero participants.";
            }

            IdClosedRace.Add(id);

            return Races[id].StartRace();
        }

        public void Park (int id)
        {
            foreach (KeyValuePair<int, Race> race in Races.Where( r => !IdClosedRace.Contains(r.Key)))
            {
                if (race.Value.Participants.ContainsKey(id))
                {
                    return;
                }
            }
            Garage.ParkedCars.Add(Cars[id]);
        }

        public void Unpark (int id)
        {
            Garage.ParkedCars.Remove(Cars[id]);
        }

        public void Tune(int tuneIndex, string addOn)
        {
            foreach (Car car in Garage.ParkedCars)
            {
                car.Tune(tuneIndex, addOn);
            }
        }

        public void OpenSpecialRace(int id, string type, int length, string route, int prizePool, int extraParameter)
        {
            switch (type)
            {
                case "TimeLimit":
                    TimeLimitRace timeLimitRace = new TimeLimitRace(length, route, prizePool, extraParameter);
                    Races.Add(id, timeLimitRace);
                    break;

                case "Circuit":
                    CircuitRace circuitRace = new CircuitRace(length, route, prizePool, extraParameter);
                    Races.Add(id, circuitRace);
                    break;
            }
        }
    }
}
