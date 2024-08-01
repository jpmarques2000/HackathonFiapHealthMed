using Bogus;
using Hackathon.HealthMed.Services.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Tests.FakeData
{
    public class ScheduleAddInputFaker : Faker<ScheduleInsertInput>
    {
        public ScheduleAddInputFaker()
        {
            RuleFor(c => c.DoctorId, f => f.Random.Int(1, 99999999));
            RuleFor(c => c.Time, f => f.Random.Word());
        }
    }
}
