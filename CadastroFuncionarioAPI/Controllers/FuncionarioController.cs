using AutoMapper;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using GestaoEmpresarial.Repository.Data.Script;
using GestaoEmpresarial.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _Service;
        private readonly IMapper _Mapper;

        public FuncionarioController(IMapper mapper, IFuncionarioService funcionarioService)
        {
            _Service = funcionarioService;
            _Mapper = mapper;
        }
        /// <summary>
        /// Adiciona um funcionário no Banco de Dados
        /// </summary>
        /// <param name="funcionarioToMap"></param>
        [HttpPost("AdicionarFuncionario")] // Rota (EndPoint)
        public IActionResult AdicionarFuncionario(CreateFuncionarioDTO funcionarioToMap)
        {
            try
            {
                Funcionario funcionario = _Mapper.Map<Funcionario>(funcionarioToMap);
                funcionario.Salario = FuncionarioScript.GetSalarioFromCargoId(funcionarioToMap.CargoId);

                _Service.Adicionar(funcionario);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao adicionar Funcionário." +
                    $"O erro é: \n {erro.Message}");
            }
            
        }
        /// <summary>
        /// Visualiza os funcionário do Banco de Dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("VisualizarFuncionarios")] // Rota (EndPoint)
        public List<ReadFuncionarioDTO> ListarFuncionarios()
        {
            try
            {
                return _Service.Listar();
            }
            catch (Exception erro)
            {
                throw new Exception("Ocorreu um erro ao listar Funcionário." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Visualiza um funcionário do Banco de Dados respectivo ao Id do parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarFuncionarioPorId")] // Rota (EndPoint)
        public ReadFuncionarioDTO BuscarFuncionarioPorId(int id)
        {
            try
            {
                return _Service.BuscarFuncionarioPorId(id);
            }
            catch (Exception erro)
            {
                throw new Exception("Ocorreu um erro ao listar Funcionário por Id." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Edita um funcionário do Banco de Dados respectivo ao valor da propriedade "Id" do objeto do parâmetro
        /// </summary>
        /// <param name="funcionario"></param>
        [HttpPut("EditarFuncionario")] // Rota (EndPoint)
        public IActionResult EditarFuncionario(Funcionario funcionario)
        {
            try
            {
                _Service.Editar(funcionario);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao editar Funcionário." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Remove um funcionário do Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("RemoverFuncionario")] // Rota (EndPoint)
        public IActionResult RemoverFuncionario(int id)
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
