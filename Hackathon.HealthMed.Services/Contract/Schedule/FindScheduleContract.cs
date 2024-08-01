using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Schedule
{
    public class FindScheduleContract : BaseContract<Domain.Entities.Schedule>
    {
        public FindScheduleContract(Domain.Entities.Schedule input)
        {
            Validate(input);
        }
        protected override void Validate(Domain.Entities.Schedule input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Schedule", "Schedule Id does not exists or is already scheduled"));
        }
    }
}
