using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using MXGP.Utilities;
namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;
        private bool canParticipate;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value.Length < 5 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.RiderNameException, value));
                }
                name = value;
            }
        }


        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get { return this.canParticipate; }

            private set
            {
                canParticipate = false;
            }
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle is null)
            {
                throw new ArgumentNullException(ExceptionMessages.NullMotorException);
            }
            this.Motorcycle = motorcycle;
            this.canParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
