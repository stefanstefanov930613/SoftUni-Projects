using System.Collections.Generic;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using MXGP.Utilities;
using System.Linq;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            riders = new List<IRider>();
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value.Length<5 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.RiderNameException, value));
                }
                name = value;
            }
        }
        public int Laps
        {
            get { return this.laps; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.LapsException);
                }

                laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders;

        public void AddRider(IRider rider)
        {
            if(rider == null)
            {
                throw new ArgumentNullException(ExceptionMessages.NullRiderException);
            }
            if (!rider.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderWithNOMotorException, rider.Name));
            }
            if (riders.Any(x => x.Name == rider.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderAlreadyExists, rider.Name, this.name));
            }
            riders.Add(rider);
        }
    }
}
