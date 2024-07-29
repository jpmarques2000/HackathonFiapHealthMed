using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Interfaces.Services;
using Hackathon.HealthMed.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.HealthMed.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IBaseNotification baseNotification,
            IUserService userService) : base(baseNotification)
        {
            _userService = userService;
        }

        /// <summary>
        /// Cadastrar novo usuário
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Name, email e password
        /// </remarks>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterInput input)
        {
            var result = await _userService.Register(input);
            return CreatedOrBadRequest(result);
        }

        /// <summary>
        /// Realizar login
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Data:
        /// 
        /// Email e password
        /// </remarks>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginInput input)
        {
            var result = await _userService.Login(input);
            return OKOrBadRequest(result);

        }
    }
}
