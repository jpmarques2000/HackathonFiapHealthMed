﻿using System;
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
        public int PatientId { get; set; }
        public bool isScheduled { get; set; }

        public Doctor Doctor { get; set; }
    }
}
