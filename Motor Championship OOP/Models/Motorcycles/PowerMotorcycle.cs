namespace MXGP.Models.Motorcycles
{
    using System;
    using MXGP.Utilities;

    public class PowerMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 450;

        private int horsePower;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, CUBIC_CENTIMETERS)
        {
            
        }


        public override int HorsePower
        {
            get { return this.horsePower; }
            protected set
            {
                if (value < 70 || value > 100)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.MotorInvalidHp, value));
                }

                horsePower = value;
            }
        }

    }
}
