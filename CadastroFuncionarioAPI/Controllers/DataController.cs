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
        public void AdicionarDatas()
        {
            _Service.Adicionar();
        }
    }
}