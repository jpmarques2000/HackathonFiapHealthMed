using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Result
{
    public class DoctorResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<ScheduleResult> Schedules { get; set; }

    }
}
