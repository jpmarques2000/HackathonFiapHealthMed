using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Input
{
    public class PatientUpdateInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
    }
}
