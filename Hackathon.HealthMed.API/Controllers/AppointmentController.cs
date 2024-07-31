using Hackathon.HealthMed.Services.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.HealthMed.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IBaseNotification baseNotification, IAppointmentService appointmentService) : base(baseNotification)
        {
            _appointmentService = appointmentService;
        }
    }
}
