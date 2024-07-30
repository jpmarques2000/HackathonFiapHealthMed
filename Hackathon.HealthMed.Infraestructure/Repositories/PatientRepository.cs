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
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Patient> FindByIdAsync(int id)
        {
            var result = await _context.Patient
                .Where(x => x.Id == id)
                .Where(x => x.Enabled == true)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IList<Patient>> ListAsync()
        {
            var result = await _context.Patient
                .Where(p => p.Enabled == true)
                .ToListAsync();

            return result;
        }
    }
}
