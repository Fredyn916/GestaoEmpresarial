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
        public void AdicionarFuncionario(CreateFuncionarioDTO funcionarioToMap)
        {
            Funcionario funcionario = _Mapper.Map<Funcionario>(funcionarioToMap);
            funcionario.Salario = FuncionarioScript.GetSalarioFromCargoId(funcionarioToMap.CargoId);

            _Service.Adicionar(funcionario);
        }
        /// <summary>
        /// Visualiza os funcionário do Banco de Dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("VisualizarFuncionarios")] // Rota (EndPoint)
        public List<ReadFuncionarioDTO> ListarFuncionarios()
        {
            return _Service.Listar();
        }
        /// <summary>
        /// Visualiza um funcionário do Banco de Dados respectivo ao Id do parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarFuncionarioPorId")] // Rota (EndPoint)
        public ReadFuncionarioDTO BuscarFuncionarioPorId(int id)
        {
            return _Service.BuscarFuncionarioPorId(id);
        }
        /// <summary>
        /// Edita um funcionário do Banco de Dados respectivo ao valor da propriedade "Id" do objeto do parâmetro
        /// </summary>
        /// <param name="funcionario"></param>
        [HttpPut("EditarFuncionario")] // Rota (EndPoint)
        public void EditarFuncionario(Funcionario funcionario)
        {
            _Service.Editar(funcionario);
        }
        /// <summary>
        /// Remove um funcionário do Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("RemoverFuncionario")] // Rota (EndPoint)
        public void RemoverFuncionario(int id)
        {
            _Service.Remover(id);
        }
    }
}
