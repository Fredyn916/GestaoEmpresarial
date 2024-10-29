using AutoMapper;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Service;
using GestaoEmpresarial.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class BalancoController : ControllerBase
    {
        private IBalancoService _Service;
        private readonly IMapper _Mapper;

        public BalancoController(IMapper mapper, IConfiguration connection)
        {
            _Service = new BalancoService(connection.GetConnectionString("DefaultConnection"));
            _Mapper = mapper;
        }

        [HttpPost("AdicionarBalanco")] // Rota (EndPoint)
        public void AdicionarBalanco()
        {
            _Service.Adicionar();
        }

        [HttpGet("VisualizarBalancos")] // Rota (EndPoint)
        public List<Balanco> ListarBalanco()
        {
            return _Service.Listar();
        }
    }
}
