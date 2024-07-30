using Hackathon.HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Domain.Interfaces.Repositories
{
    public interface IMedicRepository : IBaseRepository<Medic>
    {
        Task<Medic> FindByIdAsync(int id);
        Task<IList<Medic>> ListAsync();
    }
}
