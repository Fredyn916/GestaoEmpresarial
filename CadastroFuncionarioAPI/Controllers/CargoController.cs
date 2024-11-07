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
        /// <summary>
        /// Adiciona um cargo no Banco de Dados
        /// </summary>
        /// <param name="cargoToMap"></param>
        [HttpPost("AdicionarCargo")] // Rota (EndPoint)
        public void AdicionarFuncionario(CreateCargoDTO cargoToMap)
        {
            Cargo cargo = _Mapper.Map<Cargo>(cargoToMap);

            _Service.Adicionar(cargo);
        }
        /// <summary>
        /// Visualiza os cargos do Banco de Dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("VisualizarCargos")] // Rota (EndPoint)
        public List<Cargo> ListarCargo()
        {
            return _Service.Listar();
        }
        /// <summary>
        /// Visualiza um cargo do Banco de Dados respectivo ao Id do parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarCargoPorId")] // Rota (EndPoint)
        public Cargo BuscarCargoPorId(int id)
        {
            return _Service.BuscarCargoPorId(id);
        }
        /// <summary>
        /// Edita um cargo do Banco de Dados respectivo ao valor da propriedade "Id" do objeto do parâmetro
        /// </summary>
        /// <param name="cargo"></param>
        [HttpPut("EditarCargo")] // Rota (EndPoint)
        public void EditarFuncionario(Cargo cargo)
        {
            _Service.Editar(cargo);
        }
        /// <summary>
        /// Remove um cargo do Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("RemoverCargo")] // Rota (EndPoint)
        public void RemoverCargo(int id)
        {
            _Service.Remover(id);
        }
    }
}
