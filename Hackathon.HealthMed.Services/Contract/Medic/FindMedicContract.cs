using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Medic
{
    public class FindMedicContract : BaseContract<Domain.Entities.Medic>
    {
        public FindMedicContract(Domain.Entities.Medic input)
        {
            Validate(input);
        }
        protected override void Validate(Domain.Entities.Medic input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Medic", "Medic Id does not exists"));
        }
    }
}
