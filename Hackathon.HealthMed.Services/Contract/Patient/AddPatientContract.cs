using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Patient
{
    public class AddPatientContract : BaseContract<PatientInsertInput>
    {
        public AddPatientContract(PatientInsertInput input)
        {
            Validate(input);
        }

        protected override void Validate(PatientInsertInput input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Patient", "Parameters is null")
                .IsNotNullOrWhiteSpace(input.Name, "Name", "The name field cannot be empty")
                .IsGreaterThan(input.CPF, 10, "CPF", "The CPF field must be greater than 10"));
        }
    }
}
