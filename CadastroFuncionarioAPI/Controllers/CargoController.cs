using Microsoft.AspNetCore.Mvc;
using GestaoEmpresarial.Service;
using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataNotation
    public class CargoController : ControllerBase
    {
        private CargoService _service;

        public CargoController()
        {
            _service = new CargoService();
        }

        [HttpGet("VisualizarCargos")] // Rota (EndPoint)
        public List<Cargo> ListarCargo()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarCargoPorId")] // Rota (EndPoint)
        public Cargo BuscarCargoPorId(int id)
        {
            return _service.BuscarCargoPorId(id);
        }
    }
}
