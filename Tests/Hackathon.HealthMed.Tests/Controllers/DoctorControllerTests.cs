using AutoFixture;
using Hackathon.HealthMed.API.Controllers;
using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Interfaces.Services;
using Hackathon.HealthMed.Services.Result;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Tests.Controllers
{
    public class DoctorControllerTests
    {
        private readonly Mock<IDoctorService> _doctorServiceMock = new Mock<IDoctorService>();
        private readonly Mock<IBaseNotification> _baseNotificationMock = new Mock<IBaseNotification>();
        private readonly Fixture _fixture = new Fixture();
        private DoctorController _controller;

        [Fact]
        public async Task Get_Doctor_ReturnOk()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);
            var doctorList = _fixture.CreateMany<DoctorResult>(5).ToList();

            _doctorServiceMock.Setup(repo => repo.ListAsync()).ReturnsAsync(doctorList);

            _controller = new DoctorController(_baseNotificationMock.Object, _doctorServiceMock.Object);

            var result = await _controller.Get();

            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }

        [Fact]
        public async Task GetById_Doctor_ReturnOk()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);
            var doctor = _fixture.Create<DoctorResult>();

            _doctorServiceMock.Setup(repo => repo.FindByIdAsync(doctor.Id)).ReturnsAsync(doctor);

            _controller = new DoctorController(_baseNotificationMock.Object, _doctorServiceMock.Object);

            var result = await _controller.Get(doctor.Id);

            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }

        [Fact]
        public async Task Create_Doctor_ReturnsCreated()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);

            var doctor = _fixture.Create<DoctorInsertInput>();
            var expectDoctor = new DoctorResult();

            _doctorServiceMock.Setup(repo => repo.AddAsync(doctor)).ReturnsAsync(expectDoctor);

            _controller = new DoctorController(_baseNotificationMock.Object, _doctorServiceMock.Object);

            var result = await _controller.Post(doctor);

            var obj = result as ObjectResult;

            Assert.Equal(201, obj.StatusCode);
        }

        [Fact]
        public async Task Update_Doctor_ReturnsOk()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);

            var doctor = _fixture.Create<DoctorUpdateInput>();
            var expectDoctor = new DoctorResult();

            _doctorServiceMock.Setup(repo => repo.UpdateAsync(doctor)).ReturnsAsync(expectDoctor);

            _controller = new DoctorController(_baseNotificationMock.Object, _doctorServiceMock.Object);

            var result = await _controller.Put(doctor);

            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }

        [Fact]
        public async Task Delete_Doctor_ReturnsOk()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);

            var doctor = _fixture.Create<DoctorResult>();

            _controller = new DoctorController(_baseNotificationMock.Object, _doctorServiceMock.Object);

            var result = await _controller.Delete(doctor.Id);

            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }
    }
}
