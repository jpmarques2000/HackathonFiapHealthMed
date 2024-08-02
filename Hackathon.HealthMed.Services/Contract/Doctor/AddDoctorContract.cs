using Flunt.Extensions.Br.Validations;
using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Doctor
{
    public class AddDoctorContract : BaseContract<DoctorInsertInput>
    {
        public AddDoctorContract(DoctorInsertInput input)
        {
            Validate(input);
        }

        protected override void Validate(DoctorInsertInput input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Doctor", "Parameters is null")
                .IsNotNullOrWhiteSpace(input.Name, "Name", "The Name field cannot be empty")
                .IsNotNullOrWhiteSpace(input.CPF, "CPF", "The CPF field cannot be empty")
                .IsNotNullOrWhiteSpace(input.CRM, "CRM", "The CRM field cannot be empty")
                .IsGreaterThan(input.Name, 3, "Name", "The Name field must be greater than 3"));
        }
    }
}
