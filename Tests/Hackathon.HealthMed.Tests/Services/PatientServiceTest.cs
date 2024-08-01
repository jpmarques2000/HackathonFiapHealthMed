using Hackathon.HealthMed.Domain.Entities;
using Hackathon.HealthMed.Domain.Interfaces.Repositories;
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
    public class PatientServiceTest : ConfigBase
    {
        private readonly Mock<IPatientRepository> _patientRepositoryMock = new Mock<IPatientRepository>();
        private readonly Mock<IBaseNotification> _baseNotificationMock = new Mock<IBaseNotification>();
        private readonly PatientAddInputFaker _patientAddInputFaker = new PatientAddInputFaker();
        private readonly PatientUpdateInputFaker _patientUpdateInputFaker = new PatientUpdateInputFaker();

        [Fact]
        public async Task AddAsync_ShouldNotReturnNull_WhenInputIsValid()
        {

            var service = new PatientService(_patientRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _patientAddInputFaker.Generate();

            _patientRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Patient>())).ReturnsAsync(1);

            var result = await service.AddAsync(input);
            Assert.True(result != null);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull_WhenPatientNotFound()
        {
            var service = new PatientService(_patientRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _patientUpdateInputFaker.Generate();

            _patientRepositoryMock.Setup(x => x.FindByIdAsync(input.Id)).ReturnsAsync((Patient)null);

            var result = await service.UpdateAsync(input);

            Assert.True(result == null);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnFalse_WhenPatientNotFound()
        {
            var service = new PatientService(_patientRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            int id = 1;

            _patientRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Patient)null);

            var result = await service.DeleteAsync(id);

            Assert.False(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnPatient_WhenPatientExists()
        {
            // Arrange
            var service = new PatientService(_patientRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            int id = 1;
            var expectedPatient = new Patient { Id = id };

            _patientRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(expectedPatient);

            // Act
            var result = await service.FindByIdAsync(id);

            Assert.Null(result);
        }

        [Fact]
        public async Task AddAsyncWithNoName_ShouldReturnNull()
        {

            var service = new PatientService(_patientRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _patientAddInputFaker.Generate();

            input.Name = null;

            _patientRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Patient>())).ReturnsAsync(0);

            var result = await service.AddAsync(input);
            Assert.True(result == null);
        }
    }
}
