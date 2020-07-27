using MXGP.Models.Motorcycles.Contracts;
using System;
using MXGP.Utilities;
namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
      
        private string model;

        protected  Motorcycle(string model,int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if(value.Length<4 || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.MotorModelNameException,value));
                }

                model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            double racePoints = this.CubicCentimeters / this.HorsePower * laps;

            return racePoints;
        }
    }
}
