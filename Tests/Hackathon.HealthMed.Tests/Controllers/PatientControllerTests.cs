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
    public class PatientControllerTests
    {
        private readonly Mock<IPatientService> _patientServiceMock = new Mock<IPatientService>();
        private readonly Mock<IBaseNotification> _baseNotificationMock = new Mock<IBaseNotification>();
        private readonly Fixture _fixture = new Fixture();
        private PatientController _controller;

        [Fact]
        public async Task Get_Patient_ReturnOk()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);
            var patientList = _fixture.CreateMany<PatientResult>(5).ToList();

            _patientServiceMock.Setup(repo => repo.ListAsync()).ReturnsAsync(patientList);

            _controller = new PatientController(_baseNotificationMock.Object, _patientServiceMock.Object);

            var result = await _controller.Get();

            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }

        [Fact]
        public async Task GetById_Patient_ReturnOk()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);
            var patient = _fixture.Create<PatientResult>();

            _patientServiceMock.Setup(repo => repo.FindByIdAsync(patient.Id)).ReturnsAsync(patient);

            _controller = new PatientController(_baseNotificationMock.Object, _patientServiceMock.Object);

            var result = await _controller.Get(patient.Id);

            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }

        [Fact]
        public async Task Create_Patient_ReturnsCreated()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);

            var patient = _fixture.Create<PatientInsertInput>();
            var expectPatient = new PatientResult();

            _patientServiceMock.Setup(repo => repo.AddAsync(patient)).ReturnsAsync(expectPatient);

            _controller = new PatientController(_baseNotificationMock.Object, _patientServiceMock.Object);

            var result = await _controller.Post(patient);

            var obj = result as ObjectResult;

            Assert.Equal(201, obj.StatusCode);
        }

        [Fact]
        public async Task Update_Patient_ReturnsOk()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);

            var patient = _fixture.Create<PatientUpdateInput>();
            var expectPatient = new PatientResult();

            _patientServiceMock.Setup(repo => repo.UpdateAsync(patient)).ReturnsAsync(expectPatient);

            _controller = new PatientController(_baseNotificationMock.Object, _patientServiceMock.Object);

            var result = await _controller.Put(patient);

            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }

        [Fact]
        public async Task Delete_Patient_ReturnsOk()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);

            var patient = _fixture.Create<PatientResult>();

            _controller = new PatientController(_baseNotificationMock.Object, _patientServiceMock.Object);

            var result = await _controller.Delete(patient.Id);

            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }
    }
}
