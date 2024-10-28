using AutoMapper;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using GestaoEmpresarial.Repository.Data.Script;
using GestaoEmpresarial.Service;
using GestaoEmpresarial.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class FuncionarioController : ControllerBase
    {
        private IFuncionarioService _Service;
        private readonly IMapper _Mapper;

        public FuncionarioController(IMapper mapper, IConfiguration connection)
        {
            _Service = new FuncionarioService(connection.GetConnectionString("DefaultConnection"));
            _Mapper = mapper;
        }

        [HttpPost("AdicionarFuncionario")] // Rota (EndPoint)
        public void AdicionarFuncionario(CreateFuncionarioDTO funcionarioToMap)
        {
            Funcionario funcionario = _Mapper.Map<Funcionario>(funcionarioToMap);
            funcionario.Salario = FuncionarioScript.GetSalarioFromCargoId(funcionarioToMap.CargoId);

            _Service.Adicionar(funcionario);
        }

        [HttpGet("VisualizarFuncionarios")] // Rota (EndPoint)
        public List<ReadFuncionarioDTO> ListarFuncionarios()
        {
            return _Service.Listar();
        }

        [HttpGet("BuscarFuncionarioPorId")] // Rota (EndPoint)
        public ReadFuncionarioDTO BuscarFuncionarioPorId(int id)
        {
            return _Service.BuscarFuncionarioPorId(id);
        }

        [HttpPut("EditarFuncionario")] // Rota (EndPoint)
        public void EditarFuncionario(Funcionario funcionario)
        {
            _Service.Editar(funcionario);
        }

        [HttpDelete("RemoverFuncionario")] // Rota (EndPoint)
        public void RemoverFuncionario(int id)
        {
            _Service.Remover(id);
        }
    }
}
