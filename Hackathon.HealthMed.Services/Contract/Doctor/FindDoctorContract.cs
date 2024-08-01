using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Doctor
{
    public class FindDoctorContract : BaseContract<Domain.Entities.Doctor>
    {
        public FindDoctorContract(Domain.Entities.Doctor input)
        {
            Validate(input);
        }
        protected override void Validate(Domain.Entities.Doctor input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Doctor", "Doctor Id does not exists"));
        }
    }
}
