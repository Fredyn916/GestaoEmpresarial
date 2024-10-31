using Microsoft.AspNetCore.Mvc;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.CargoDTO;
using AutoMapper;
using GestaoEmpresarial.Service.Interfaces;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _Service;
        private readonly IMapper _Mapper;

        public CargoController(IMapper mapper, ICargoService cargoService)
        {
            _Service = cargoService;
            _Mapper = mapper;
        }

        [HttpPost("AdicionarCargo")] // Rota (EndPoint)
        public void AdicionarFuncionario(CreateCargoDTO cargoToMap)
        {
            Cargo cargo = _Mapper.Map<Cargo>(cargoToMap);

            _Service.Adicionar(cargo);
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

        [HttpPut("EditarCargo")] // Rota (EndPoint)
        public void EditarFuncionario(Cargo cargo)
        {
            _Service.Editar(cargo);
        }

        [HttpDelete("RemoverCargo")] // Rota (EndPoint)
        public void RemoverCargo(int id)
        {
            _Service.Remover(id);
        }
    }
}
