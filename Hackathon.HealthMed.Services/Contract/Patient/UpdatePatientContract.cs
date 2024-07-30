using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Patient
{
    public class UpdatePatientContract : BaseContract<PatientUpdateInput>
    {
        public UpdatePatientContract(PatientUpdateInput input)
        {
            Validate(input);
        }
        protected override void Validate(PatientUpdateInput input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Patient", "Parameters is null")
                .IsGreaterThan(input.Id, 0, "Car", "The Id field must be greater than 0")
                .IsNotNullOrWhiteSpace(input.Name, "Name", "The name field cannot be empty")
                .IsGreaterThan(input.CPF, 10, "CPF", "The CPF field must be greater than 10"));
        }
    }
}
