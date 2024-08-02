﻿using Hackathon.HealthMed.Domain.Interfaces.Repositories;
using Hackathon.HealthMed.Services.Interfaces.Services;
using Hackathon.HealthMed.Services.Services;
using Hackathon.HealthMed.Tests.FakeData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Tests.Services
{
    public class UserServiceTests : ConfigBase
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly Mock<IBaseNotification> _baseNotificationMock = new Mock<IBaseNotification>();
        private readonly UserAddInputFaker _userAddInputFaker = new UserAddInputFaker();
        private readonly UserLoginFaker _userLoginFaker = new UserLoginFaker();

        [Fact]
        public async Task UserRegister_ShouldNotReturnNull_WhenInputIsValid()
        {

            var service = new UserService(_userRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _userAddInputFaker.Generate();

            var result = await service.Register(input);

            Assert.True(result != null);
        }

        [Fact]
        public async Task UserRegister_ShouldReturnNull_WhenEmailIsNotValid()
        {

            var service = new UserService(_userRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _userAddInputFaker.Generate();
            input.Email = "";

            var result = await service.Register(input);

            Assert.True(result == null);
        }

        [Fact]
        public async Task UserRegister_ShouldReturnNull_WhenNameIsNotValid()
        {

            var service = new UserService(_userRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _userAddInputFaker.Generate();
            input.Name = "";

            var result = await service.Register(input);

            Assert.True(result == null);
        }

        [Fact]
        public async Task UserRegister_ShouldReturnNull_WhenPasswordIsNotValid()
        {

            var service = new UserService(_userRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _userAddInputFaker.Generate();
            input.Password = "";

            var result = await service.Register(input);

            Assert.True(result == null);
        }

        [Fact]
        public async Task UserLogin_ResultMessageShouldNotReturnNull_WhenUserNotExists()
        {

            var service = new UserService(_userRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _userLoginFaker.Generate();

            var result = await service.Login(input);

            Assert.True(result.Message != null);
        }
    }
}
