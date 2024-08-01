using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResult> Login(UserLoginInput input);
        Task<UserResult> Register(UserRegisterInput input);
    }
}
