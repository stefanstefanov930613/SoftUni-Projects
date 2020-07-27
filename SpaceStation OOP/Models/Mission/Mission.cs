using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        private IRepository<IAstronaut> astronauts;
          
        public Mission()
        {
            this.astronauts = new AstronautRepository();
             
        }

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.Oxygen > 0)
                {
                    foreach (var item in planet.Items)
                    {
                        astronaut.Breath();

                        astronaut.Bag.Items.Add(item);
                    }
                     
                }
            }
        }
    }
}
