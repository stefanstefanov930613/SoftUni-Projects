using System.Collections.Generic;
using MXGP.Repositories.Contracts;
using System.Linq;
using MXGP.Models;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider> 
        
      
    {
        private readonly List<IRider> riders;

        public RiderRepository()
        {
            riders = new List<IRider>();
        }
        public void Add(IRider model)
        {
            riders.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return riders;
        }

        public IRider GetByName(string name)
        {
           return riders.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRider model)
        {
            return riders.Remove(model);
        }
    }
}
