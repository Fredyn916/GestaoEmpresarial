using Microsoft.AspNetCore.Mvc;
using GestaoEmpresarial.Service;
using GestaoEmpresarial.Entidades;
using System.Configuration;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class CargoController : ControllerBase
    {
        private CargoService _Service;

        public CargoController(IConfiguration connection)
        {
            _Service = new CargoService(connection.GetConnectionString("DefaultConnection"));
        }

        [HttpGet("VisualizarCargos")] // Rota (EndPoint)
        public List<Cargo> ListarCargo()
        {
            return _Service.Listar();
        }

        [HttpGet("BuscarCargoPorId")] // Rota (EndPoint)
        public Cargo BuscarCargoPorId(int id)
        {
            return _Service.BuscarCargoPorId(id);
        }
    }
}
