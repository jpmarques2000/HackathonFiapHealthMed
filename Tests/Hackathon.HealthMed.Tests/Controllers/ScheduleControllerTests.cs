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
    public class ScheduleControllerTests
    {
        private readonly Mock<IScheduleService> _scheduleServiceMock = new Mock<IScheduleService>();
        private readonly Mock<IBaseNotification> _baseNotificationMock = new Mock<IBaseNotification>();
        private readonly Fixture _fixture = new Fixture();
        private ScheduleController _controller;

        [Fact]
        public async Task Create_Schedule_ReturnsCreated()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);

            var schedule = _fixture.Create<ScheduleInsertInput>();
            var expectSchedule = new ScheduleResult();

            _scheduleServiceMock.Setup(repo => repo.AddAsync(schedule)).ReturnsAsync(expectSchedule);

            _controller = new ScheduleController(_baseNotificationMock.Object, _scheduleServiceMock.Object);

            var result = await _controller.Post(schedule);

            var obj = result as ObjectResult;

            Assert.Equal(201, obj.StatusCode);
        }

        [Fact]
        public async Task Update_Schedule_ReturnsOk()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);

            var schedule = _fixture.Create<ScheduleUpdateInput>();
            var expectSchedule = new ScheduleResult();

            _scheduleServiceMock.Setup(repo => repo.UpdateAsync(schedule)).ReturnsAsync(expectSchedule);

            _controller = new ScheduleController(_baseNotificationMock.Object, _scheduleServiceMock.Object);

            var result = await _controller.Put(schedule);

            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }

        [Fact]
        public async Task Delete_Schedule_ReturnsOk()
        {
            _baseNotificationMock.Setup(x => x.IsValid).Returns(true);

            var schedule = _fixture.Create<ScheduleResult>();

            _controller = new ScheduleController(_baseNotificationMock.Object, _scheduleServiceMock.Object);

            var result = await _controller.Delete(schedule.Id);

            var obj = result as ObjectResult;

            Assert.Equal(200, obj.StatusCode);
        }
    }
}
