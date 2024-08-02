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
    public class ScheduleServiceTests : ConfigBase
    {
        private readonly Mock<IScheduleRepository> _scheduleRepositoryMock = new Mock<IScheduleRepository>();
        private readonly Mock<IBaseNotification> _baseNotificationMock = new Mock<IBaseNotification>();
        private readonly ScheduleAddInputFaker _scheduleAddInputFaker = new ScheduleAddInputFaker();
        private readonly ScheduleUpdateInputFaker _scheduleUpdateInputFaker = new ScheduleUpdateInputFaker();

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull_WhenScheduleNotFound()
        {
            var service = new ScheduleService(_scheduleRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            var input = _scheduleUpdateInputFaker.Generate();

            _scheduleRepositoryMock.Setup(x => x.FindByIdAsync(input.Id)).ReturnsAsync((Schedule)null);

            var result = await service.UpdateAsync(input);

            Assert.True(result == null);
        }

        [Fact]
        public async Task RemoveAsync_ShouldReturnFalse_WhenScheduleNotFound()
        {
            var service = new ScheduleService(_scheduleRepositoryMock.Object, _mapper,
                _baseNotificationMock.Object);
            int id = 1;

            _scheduleRepositoryMock.Setup(x => x.GetByIdAsync(id)).ReturnsAsync((Schedule)null);

            var result = await service.DeleteAsync(id);

            Assert.False(result);
        }
    }
}
