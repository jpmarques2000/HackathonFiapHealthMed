using Hackathon.HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Domain.Interfaces.Repositories
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Task<Doctor> FindByIdAsync(int id);
        Task<IList<Doctor>> ListAsync();
    }
}
