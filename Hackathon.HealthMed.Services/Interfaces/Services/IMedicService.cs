using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Interfaces.Services
{
    public interface IMedicService
    {
        Task<MedicResult> AddAsync(MedicInsertInput input);
        Task<bool> DeleteAsync(int id);
        Task<MedicResult> FindByIdAsync(int id);
        Task<IList<MedicResult>> ListAsync();
        Task<MedicResult> UpdateAsync(MedicUpdateInput input);
    }
}
