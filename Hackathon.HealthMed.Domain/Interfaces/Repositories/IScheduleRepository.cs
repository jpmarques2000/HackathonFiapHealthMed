using Hackathon.HealthMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Domain.Interfaces.Repositories
{
    public interface IScheduleRepository : IBaseRepository<Schedule>
    {
        Task<IList<Schedule>> FindByMedicIdAsync(int id);
        Task<IList<Schedule>> FindByPatientIdAsync(int id);
        Task<Schedule> SearchScheduleByTimeAndMedicId(string time, int docId);
        Task<Schedule> FindByIdAsync(int id);
    }
}
