using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Domain.Entities
{
    public class Schedule : Entity
    {
        public string Time { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public bool ScheduleTime { get; set; }
    }
}
