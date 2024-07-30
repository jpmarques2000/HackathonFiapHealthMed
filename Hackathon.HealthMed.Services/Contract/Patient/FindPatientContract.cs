using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Patient
{
    public class FindPatientContract : BaseContract<Domain.Entities.Patient>
    {
        public FindPatientContract(Domain.Entities.Patient input)
        {
            Validate(input);
        }
        protected override void Validate(Domain.Entities.Patient input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Patient", "Patient Id does not exists"));
        }
    }
}
