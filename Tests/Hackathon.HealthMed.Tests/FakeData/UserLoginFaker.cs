using Bogus;
using Hackathon.HealthMed.Services.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Tests.FakeData
{
    public class UserLoginFaker : Faker<UserLoginInput>
    {
        public UserLoginFaker()
        {
            RuleFor(c => c.Email, f => f.Random.Word());
            RuleFor(c => c.Password, f => "senhasenha");
        }
    }
}
