using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Schedule
{
    public class DeleteScheduleContract : BaseContract<DeleteInput>
    {
        public DeleteScheduleContract(DeleteInput input)
        {
            Validate(input);
        }
        protected override void Validate(DeleteInput input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input.Id, "Schedule", "Parameters is null")
                .IsGreaterThan(input.Id, 0, "Schedule", "The Id field must be greater than 0"));
        }
    }
}
