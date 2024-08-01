using AutoMapper;
using Hackathon.HealthMed.Domain.Entities;
using Hackathon.HealthMed.Domain.Interfaces.Repositories;
using Hackathon.HealthMed.Services.Contract.User;
using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Interfaces.Services;
using Hackathon.HealthMed.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        private readonly IBaseNotification _baseNotification;

        public UserService(IUserRepository userRepository, IMapper mapper,
            IBaseNotification baseNotification)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _baseNotification = baseNotification;
        }

        public async Task<UserResult> Login(UserLoginInput input)
        {
            var token = await _userRepository.Login(input.Email, input.Password);
            var result = new UserResult();
            if (token == null)
            {
                result.Message = "Usuário ou senha inválidos.";
                return result;
            }
            result.Token = token;
            result.Email = input.Email;
            result.Message = "Autenticação realizada com sucesso.";

            return result;
        }

        public async Task<UserResult> Register(UserRegisterInput input)
        {
            var contract = new AddUserContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var map = _mapper.Map<User>(input);

            var result = new UserResult();

            var registered = await _userRepository.Register(map, input.Password);

            if (registered > 0)
            {
                result = _mapper.Map<UserResult>(map);
            }
            result.Message = "Usuário registrado com sucesso.";

            return result;

            //return 
        }
    }
}
