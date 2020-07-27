namespace MXGP.Utilities
{
   public static class ExceptionMessages
    {
        public static string MotorModelNameException = "Model {0} cannot be less than 4 symbols.";
        public static string MotorInvalidHp = "Invalid horse power: {0}.";
        public static string RiderNameException = "Name {0} cannot be less than 5 symbols.";
        public static string NullMotorException = "Motorcycle cannot be null.";
        public static string LapsException = "Laps cannot be less than 1.";
        public static string NullRiderException = "Rider cannot be null.";
        public static string RiderWithNOMotorException = "Rider {0} could not participate in race.";
        public static string RiderAlreadyExists = "Rider {0} is already added in {1} race.";
    }
}
