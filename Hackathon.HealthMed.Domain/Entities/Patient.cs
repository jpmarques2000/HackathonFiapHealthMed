using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Domain.Entities
{
    public class Patient : Entity
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        //Campo de Test apenas para testar nossa pipeline CI/CD , remover depois
        public string Test { get; set; }
    }
}
