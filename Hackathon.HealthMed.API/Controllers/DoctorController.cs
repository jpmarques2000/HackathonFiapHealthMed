using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Interfaces.Services;
using Hackathon.HealthMed.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.HealthMed.API.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DoctorController : BaseController
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IBaseNotification baseNotification, IDoctorService doctorService) : base(baseNotification)
        {
            _doctorService = doctorService;
        }

        /// <summary>
        /// Obtém médico por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Enviar Id para requisição
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorService.FindByIdAsync(id);

            return OKOrBadRequest(result);
        }

        /// <summary>
        /// Obtém lista de médicos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorService.ListAsync();
            return OKOrBadRequest(result);
        }

        /// <summary>
        /// Cadastrar novo médico
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Nome do modelo
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Post(DoctorInsertInput input)
        {
            var result = await _doctorService.AddAsync(input);

            return CreatedOrBadRequest(result);
        }

        /// <summary>
        /// Atualizar dados médicos
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <remarks>
        /// Dados:
        /// 
        /// Id do modelo, Id do fabricante, Novo nome de modelo
        /// </remarks>
        [HttpPut]
        public async Task<IActionResult> Put(DoctorUpdateInput input)
        {
            var result = await _doctorService.UpdateAsync(input);

            return OKOrBadRequest(result);
        }

        /// <summary>
        /// Remover médico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <remarks>
        /// Id do modelo a ser removido
        /// </remarks>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _doctorService.DeleteAsync(id);

            return OKOrBadRequest(result);
        }
    }
}
