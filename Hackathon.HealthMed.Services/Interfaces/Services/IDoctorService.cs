using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Interfaces.Services
{
    public interface IDoctorService
    {
        Task<DoctorResult> AddAsync(DoctorInsertInput input);
        Task<bool> DeleteAsync(int id);
        Task<DoctorResult> FindByIdAsync(int id);
        Task<IList<DoctorResult>> ListAsync();
        Task<DoctorResult> UpdateAsync(DoctorUpdateInput input);
    }
}
