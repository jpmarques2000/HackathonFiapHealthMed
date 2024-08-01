using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Schedule
{
    public class AddScheduleContract : BaseContract<ScheduleInsertInput>
    {
        public AddScheduleContract(ScheduleInsertInput input)
        {
            Validate(input);
        }
        protected override void Validate(ScheduleInsertInput input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Schedule", "Parameters is null")
                .IsNotNullOrWhiteSpace(input.Time, "Time", "The Time field cannot be empty")
                .IsGreaterThan(input.DoctorId, 0, "DoctorId", "The DoctorId field must be greater than 0"));
        }
    }
}
