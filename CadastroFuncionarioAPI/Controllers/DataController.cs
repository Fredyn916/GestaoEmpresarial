using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class DataController : ControllerBase
    {
        private readonly IDataService _Service;

        public DataController(IDataService dataService)
        {
            _Service = dataService;
        }
        /// <summary>
        /// Adiciona datas no Banco de Dados
        /// </summary>
        [HttpPost("AdicionarDatas")] // Rota (EndPoint)
        public IActionResult AdicionarDatas()
        {
            try
            {
                _Service.Adicionar();
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao adicionar Data." +
                    $"O erro é: \n {erro.Message}");
            }
        }
    }
}