using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Interfaces.Services
{
    public interface IScheduleService
    {
        Task<ScheduleResult> AddAsync(ScheduleInsertInput input);
        Task<bool> DeleteAsync(int id);
        Task<IList<ScheduleResult>> FindByMedicIdAsync(int id);
        Task<IList<ScheduleResult>> FindByPatientIdAsync(int id);
        Task<ScheduleResult> UpdateAsync(ScheduleUpdateInput input);
        Task<ScheduleResult> ScheduleAppointment(ScheduleAppointmentInput input);
    }
}
