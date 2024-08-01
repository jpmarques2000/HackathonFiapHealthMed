using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Schedule
{
    public class ScheduleAppointmentContract : BaseContract<ScheduleAppointmentInput>
    {
        public ScheduleAppointmentContract(ScheduleAppointmentInput input)
        {
            Validate(input);
        }
        protected override void Validate(ScheduleAppointmentInput input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Schedule", "Parameters is null"));
        }
    }
}
