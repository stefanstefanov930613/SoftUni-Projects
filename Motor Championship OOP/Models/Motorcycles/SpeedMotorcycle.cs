namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Utilities;

    public class SpeedMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 125;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CUBIC_CENTIMETERS)
        {
           

        }

        public override int HorsePower
        {
            get { return this.horsePower; }
            protected set
            {
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.MotorInvalidHp, value));
                }

                horsePower = value;
            }
        }
    }
}
