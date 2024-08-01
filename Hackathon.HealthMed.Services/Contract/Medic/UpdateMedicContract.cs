using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Medic
{
    public class UpdateMedicContract : BaseContract<MedicUpdateInput>
    {
        public UpdateMedicContract(MedicUpdateInput input)
        {
            Validate(input);
        }
        protected override void Validate(MedicUpdateInput input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "Medic", "Parameters is null")
                .IsNotNullOrWhiteSpace(input.Name, "Name", "The Name field cannot be empty")
                .IsGreaterThan(input.Name, 3, "Name", "The Name field must be greater than 3")
                .IsGreaterThan(input.Id, 0, "Medic", "The Id field must be greater than 0"));
        }
    }
}
