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
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IList<Doctor>> ListAsync()
        {
            var result = await _context.Doctors
                .Include(x => x.Schedules)
                .Where(x => x.Enabled == true)
                .ToListAsync();

            return result;
        }

        public async Task<Doctor> FindByIdAsync(int id)
        {
            var result = await _context.Doctors
                .Include(x => x.Schedules)
                .Where(x => x.Id == id)
                .Where(x => x.Enabled == true)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
