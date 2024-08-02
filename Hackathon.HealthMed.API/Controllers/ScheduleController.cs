using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Interfaces.Services;
using Hackathon.HealthMed.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.HealthMed.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ScheduleController : BaseController
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IBaseNotification baseNotification, IScheduleService scheduleService) : base(baseNotification)
        {
            _scheduleService = scheduleService;
        }

        /// <summary>
        /// Obtém lista de horarios do médico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id para requisição
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _scheduleService.FindByMedicIdAsync(id);

            return OKOrBadRequest(result);
        }

        /// <summary>
        /// Obtém horários agendados do paciente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id para requisição
        /// </remarks>
        [HttpGet("appointments")]
        public async Task<IActionResult> GetPatientAppointments(int id)
        {
            var result = await _scheduleService.FindByPatientIdAsync(id);

            return OKOrBadRequest(result);
        }

        /// <summary>
        /// Cadastrar novo horário para o médico
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Horário a ser cadastrado e Id do médico
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Post(ScheduleInsertInput input)
        {
            var result = await _scheduleService.AddAsync(input);

            return CreatedOrBadRequest(result);
        }

        /// <summary>
        /// Editar horário existente
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Inserir Horário novo e Id do registro existente
        /// </remarks>
        [HttpPut("schedule")]
        public async Task<IActionResult> Put(ScheduleUpdateInput input)
        {
            var result = await _scheduleService.UpdateAsync(input);

            return OKOrBadRequest(result);
        }

        /// <summary>
        /// Agendar horário para o paciente
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id do horário existente e id do paciente
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> ScheduleAppointment(ScheduleAppointmentInput input)
        {
            var result = await _scheduleService.ScheduleAppointment(input);

            return OKOrBadRequest(result);
        }

        /// <summary>
        /// Remover horário existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Id do horário a ser removido
        /// </remarks>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _scheduleService.DeleteAsync(id);

            return OKOrBadRequest(result);
        }
    }
}
