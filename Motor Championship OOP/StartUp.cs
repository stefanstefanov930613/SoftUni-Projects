using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core;
    using MXGP.Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            // Motorcycle varche = new PowerMotorcycle("12214235", 75);
            // Console.WriteLine(varche.HorsePower);
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
