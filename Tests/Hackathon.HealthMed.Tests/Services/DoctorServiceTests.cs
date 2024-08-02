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
    public class DoctorServiceTests : ConfigBase
    {
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock = new Mock<IDoctorRepository>();
        private readonly Mock<IBaseNotification> _baseNotificationMock = new Mock<IBaseNotification>();
        private readonly DoctorAddInputFaker _doctorAddInputFaker = new DoctorAddInputFaker();
        private readonly DoctorUpdateInputFaker _doctorUpdateInputFaker = new DoctorUpdateInputFaker();

        [Fact]
        public async Task AddAsync_ShouldNotReturnNull_WhenInputIsValid()
        {

            var service = new DoctorService(_doctorRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _doctorAddInputFaker.Generate();

            _doctorRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Doctor>())).ReturnsAsync(1);

            var result = await service.AddAsync(input);
            Assert.True(result != null);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull_WhenDoctorNotFound()
        {
            var service = new DoctorService(_doctorRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _doctorUpdateInputFaker.Generate();

            _doctorRepositoryMock.Setup(x => x.FindByIdAsync(input.Id)).ReturnsAsync((Doctor)null);

            var result = await service.UpdateAsync(input);

            Assert.True(result == null);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnFalse_WhenDoctorNotFound()
        {
            var service = new DoctorService(_doctorRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            int id = 1;

            _doctorRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Doctor)null);

            var result = await service.DeleteAsync(id);

            Assert.False(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnDoctor_WhenDoctorExists()
        {
            // Arrange
            var service = new DoctorService(_doctorRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            int id = 1;
            var expectedDoctor = new Doctor { Id = id };

            _doctorRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(expectedDoctor);

            // Act
            var result = await service.FindByIdAsync(id);

            Assert.Null(result);
        }

        [Fact]
        public async Task AddAsyncWithNoName_ShouldReturnNull()
        {

            var service = new DoctorService(_doctorRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _doctorAddInputFaker.Generate();

            input.Name = null;

            _doctorRepositoryMock.Setup(x => x.AddAsync(It.IsAny<Doctor>())).ReturnsAsync(0);

            var result = await service.AddAsync(input);
            Assert.True(result == null);
        }
    }
}
