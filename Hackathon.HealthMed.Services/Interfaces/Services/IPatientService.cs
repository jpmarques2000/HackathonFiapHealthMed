using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Interfaces.Services
{
    public interface IPatientService
    {
        Task<PatientResult> AddAsync(PatientInsertInput input);
        Task<bool> DeleteAsync(int id);
        Task<PatientResult> FindByIdAsync(int id);
        Task<IList<PatientResult>> ListAsync();
        Task<PatientResult> UpdateAsync(PatientUpdateInput input);
    }
}
