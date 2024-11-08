using AutoMapper;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.BalancoDTO;
using GestaoEmpresarial.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class BalancoController : ControllerBase
    {
        private readonly IBalancoService _Service;
        private readonly IMapper _Mapper;

        public BalancoController(IMapper mapper, IBalancoService balancoService)
        {
            _Service = balancoService;
            _Mapper = mapper;
        }
        /// <summary>
        /// Adiciona um balanço no Banco de Dados
        /// </summary>
        /// <param name="balancoToMap"></param>
        [HttpPost("AdicionarBalanco")] // Rota (EndPoint)
        public IActionResult AdicionarBalanco(CreateBalancoDTO balancoToMap)
        {
            try
            {
                Balanco balanco = _Mapper.Map<Balanco>(balancoToMap);

                _Service.Adicionar(balanco);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao adicionar Balanço." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Visualiza os balanços do Banco de Dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("VisualizarBalancos")] // Rota (EndPoint)
        public List<Balanco> ListarBalanco()
        {
            try
            {
                return _Service.Listar();
            }
            catch (Exception erro)
            {
                throw new Exception("Ocorreu um erro ao listar Balanço." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Visualiza um balanço do Banco de Dados respectivo ao Id do parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarBalancoPorId")] // Rota (EndPoint)
        public Balanco BuscarBalancoPorId(int id)
        {
            try
            {
                return _Service.BuscarBalancoPorId(id);
            }
            catch (Exception erro)
            {
                throw new Exception("Ocorreu um erro ao listar Balanço por Id." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Edita um balanço do Banco de Dados respectivo ao valor da propriedade "Id" do objeto do parâmetro
        /// </summary>
        /// <param name="balanco"></param>
        [HttpPut("EditarBalanco")] // Rota (EndPoint)
        public IActionResult EditarBalanco(Balanco balanco)
        {
            try
            {
                _Service.Editar(balanco);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao editar Balanço." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Remove um balanço do Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("RemoverBalanco")] // Rota (EndPoint)
        public IActionResult RemoverBalanco(int id)
        {
            try
            {
                _Service.Remover(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao remover Balanço." +
                    $"O erro é: \n {erro.Message}");
            }
        }
    }
}
