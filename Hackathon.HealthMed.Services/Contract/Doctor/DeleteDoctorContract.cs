using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Doctor
{
    public class DeleteDoctorContract : BaseContract<DeleteInput>
    {
        public DeleteDoctorContract(DeleteInput input)
        {
            Validate(input);
        }
        protected override void Validate(DeleteInput input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input.Id, "Doctor", "Parameters is null")
                .IsGreaterThan(input.Id, 0, "Doctor", "The Id field must be greater than 0"));
        }
    }
}
