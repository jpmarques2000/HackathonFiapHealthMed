using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.Medic
{
    public class DeleteMedicContract : BaseContract<DeleteInput>
    {
        public DeleteMedicContract(DeleteInput input)
        {
            Validate(input);
        }
        protected override void Validate(DeleteInput input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input.Id, "Medic", "Parameters is null")
                .IsGreaterThan(input.Id, 0, "Medic", "The Id field must be greater than 0"));
        }
    }
}
