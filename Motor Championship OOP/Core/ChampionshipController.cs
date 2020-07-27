using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using MXGP.Utilities.Messages;
using MXGP.Models.Riders;
using MXGP.Models.Motorcycles;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using MXGP.Models.Races;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IRider> riders;
        private IRepository<IRace> races;
        private IRepository<IMotorcycle> motorcycles;

        public ChampionshipController()
        {
            riders = new RiderRepository();
            races = new RaceRepository();
            motorcycles = new MotorcycleRepository();

        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riders.GetByName(riderName);
            var bike = motorcycles.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (bike == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }
           
            rider.AddMotorcycle(bike);
            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);

        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = races.GetByName(raceName);
            var rider = riders.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);
            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
           var motorcycle = motorcycles.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            motorcycles.Add(motorcycle);
            return string.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);

        }

        public string CreateRace(string name, int laps)
        {
            var race = races.GetByName(name);
            if (race != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }
            race = new Race(name, laps);
            races.Add(race);
            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            var searchedRider = riders.GetByName(riderName);

            if (searchedRider != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            searchedRider = new Rider(riderName);
            riders.Add(searchedRider);
            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName,3));
            }

            StringBuilder sb = new StringBuilder();

            var currentRace = race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).Take(3).ToArray();

            sb.AppendLine($"Rider {currentRace[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Rider {currentRace[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Rider {currentRace[2].Name} is third in {race.Name} race.");

            races.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
