using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Doctor
{
    public class FindScheduleTimeExistsContract : BaseContract<Domain.Entities.Schedule>
    {
        public FindScheduleTimeExistsContract(Domain.Entities.Schedule input)
        {
            Validate(input);
        }
        protected override void Validate(Domain.Entities.Schedule input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Schedule", "Schedule Time already exists"));
        }
    }
}
