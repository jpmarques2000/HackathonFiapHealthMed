using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.HealthMed.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientController : BaseController
    {
        private readonly IPatientService _patientService;
        public PatientController(IBaseNotification baseNotification, IPatientService patientService) : base(baseNotification)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Obtém lista de pacientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _patientService.ListAsync();
            return OKOrBadRequest(result);
        }

        /// <summary>
        /// Obtém paciente por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id para requisição
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _patientService.FindByIdAsync(id);

            return OKOrBadRequest(result);
        }

        /// <summary>
        /// Adicionar um novo paciente
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Nome e cpf 
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Post(PatientInsertInput input)
        {
            var result = await _patientService.AddAsync(input);

            return CreatedOrBadRequest(result);
        }

        /// <summary>
        /// Atualizar dados do paciente
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id do paciente, nome e cpf
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Put(PatientUpdateInput input)
        {
            var result = await _patientService.UpdateAsync(input);

            return OKOrBadRequest(result);
        }

        /// <summary>
        /// Excluir Paciente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id do paciente a ser removido
        /// </remarks>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _patientService.DeleteAsync(id);

            return OKOrBadRequest(result);
        }
    }
}
