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
    public class MedicRepository : BaseRepository<Medic>, IMedicRepository
    {
        public MedicRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IList<Medic>> ListAsync()
        {
            var result = await _context.Medics
                .Include(x => x.Schedules)
                .Where(x => x.Enabled == true)
                .ToListAsync();

            return result;
        }

        public async Task<Medic> FindByIdAsync(int id)
        {
            var result = await _context.Medics
                .Include(x => x.Schedules)
                .Where(x => x.Id == id)
                .Where(x => x.Enabled == true)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
