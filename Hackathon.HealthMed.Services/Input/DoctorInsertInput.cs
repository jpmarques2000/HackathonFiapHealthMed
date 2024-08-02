using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Input
{
    public class DoctorInsertInput
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
        //public string Email { get; set; }

        public int ProfileId { get; set; }
    }
}
