using System.Collections.Generic;
using MXGP.Repositories.Contracts;
using System.Linq;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
      
        private readonly List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            motorcycles = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        {
            motorcycles.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return motorcycles;
        }

        public IMotorcycle GetByName(string name)
        {
            return motorcycles.FirstOrDefault(x => x.Model == name);

        }

        public bool Remove(IMotorcycle model)
        {
            return motorcycles.Remove(model);
        }
    }
}
