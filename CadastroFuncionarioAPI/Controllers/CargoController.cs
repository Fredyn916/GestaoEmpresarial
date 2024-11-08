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
        public IActionResult AdicionarFuncionario(CreateCargoDTO cargoToMap)
        {
            try
            {
                Cargo cargo = _Mapper.Map<Cargo>(cargoToMap);

                _Service.Adicionar(cargo);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao adicionar Cargo." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Visualiza os cargos do Banco de Dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("VisualizarCargos")] // Rota (EndPoint)
        public List<Cargo> ListarCargo()
        {
            try
            {
                return _Service.Listar();
            }
            catch (Exception erro)
            {
                throw new Exception("Ocorreu um erro ao listar Cargo." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Visualiza um cargo do Banco de Dados respectivo ao Id do parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarCargoPorId")] // Rota (EndPoint)
        public Cargo BuscarCargoPorId(int id)
        {
            try
            {
                return _Service.BuscarCargoPorId(id);
            }
            catch (Exception erro)
            {
                throw new Exception("Ocorreu um erro ao listar Cargo por Id." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Edita um cargo do Banco de Dados respectivo ao valor da propriedade "Id" do objeto do parâmetro
        /// </summary>
        /// <param name="cargo"></param>
        [HttpPut("EditarCargo")] // Rota (EndPoint)
        public IActionResult EditarFuncionario(Cargo cargo)
        {
            try
            {
                _Service.Editar(cargo);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao editar Cargo." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Remove um cargo do Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("RemoverCargo")] // Rota (EndPoint)
        public IActionResult RemoverCargo(int id)
        {
            try
            {
                _Service.Remover(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao remover Cargo." +
                    $"O erro é: \n {erro.Message}");
            }
        }
    }
}
