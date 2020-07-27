using MXGP.Core.Contracts;
using System;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string input = string.Empty;
            IChampionshipController championship = new ChampionshipController();

            while ((input = Console.ReadLine())!="End")
            {
                string[] command = input.Split();
                try
                {
                    if (command[0] == "CreateRider")
                    {
                        Console.WriteLine(championship.CreateRider(command[1]));
                    }
                    else if (command[0] == "CreateMotorcycle")
                    {
                        Console.WriteLine(championship.CreateMotorcycle(command[1], command[2], int.Parse(command[3])));
                    }
                    else if (command[0] == "CreateRace")
                    {
                        Console.WriteLine(championship.CreateRace(command[1], int.Parse(command[2])));
                    }
                    else if (command[0] == "AddMotorcycleToRider")
                    {
                        Console.WriteLine(championship.AddMotorcycleToRider(command[1], command[2]));
                    }
                    else if (command[0] == "StartRace")
                    {
                        Console.WriteLine(championship.StartRace(command[1]));
                    }
                    else if (command[0] == "AddRiderToRace")
                    {
                        Console.WriteLine(championship.AddRiderToRace(command[1], command[2]));
                    }
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            
            }
        }
    }
}
