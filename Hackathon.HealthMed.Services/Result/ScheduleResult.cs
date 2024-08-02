using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Result
{
    public class ScheduleResult
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public int DoctorId { get; set; }
    }
}
