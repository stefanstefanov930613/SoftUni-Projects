using System;
using System.Text;
using System.Collections.Generic;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.astronauts;

        public void Add(IAstronaut model)
        {
            this.astronauts.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            var astronaut = this.astronauts.FirstOrDefault(a => a.Name == name);

            return astronaut;
        }

        public bool Remove(IAstronaut model)
        {
            return this.astronauts.Remove(model);
        }
    }
}
