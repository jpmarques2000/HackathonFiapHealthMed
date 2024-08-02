using Hackathon.HealthMed.Domain.Entities;
using Hackathon.HealthMed.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Infraestructure.Repositories
{
    public class ScheduleRepository : BaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IList<Schedule>> FindByMedicIdAsync(int id)
        {
            var result = await _context.Schedules
                .Include(x => x.Doctor)
                .Where(x => x.DoctorId == id)
                .Where(x => x.Enabled == true)
                .Where(x => x.isScheduled == false)
                .ToListAsync();

            return result;
        }

        public async Task<IList<Schedule>> FindByPatientIdAsync(int id)
        {
            var result = await _context.Schedules
                .Where(x => x.PatientId == id)
                .Where(x => x.Enabled == true)
                .ToListAsync();

            return result;
        }

        public async Task<Schedule> FindByIdAsync(int id)
        {
            var result = await _context.Schedules
                .Include(x => x.Doctor)
                .Where(x => x.Id == id)
                .Where(x => x.Enabled == true)
                .Where(x => x.isScheduled == false)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<Schedule> SearchScheduleByTimeAndMedicId(string time, int docId)
        {
            var result = await _context.Schedules
                .Include(x => x.Doctor)
                .Where(x => x.DoctorId == docId)
                .Where(x => x.Enabled == true)
                .Where(x => x.Time == time)
                .FirstOrDefaultAsync();

                return result;
        }
    }
}
