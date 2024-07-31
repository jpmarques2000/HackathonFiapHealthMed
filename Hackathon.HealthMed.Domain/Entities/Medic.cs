using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Domain.Entities
{
    public class Medic : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //Campo de Test apenas para testar nossa pipeline CI/CD , remover depois
        public string Test { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
