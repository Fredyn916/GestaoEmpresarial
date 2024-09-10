using AutoMapper;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using GestaoEmpresarial.Service;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class FuncionarioController : ControllerBase
    {
        private FuncionarioService _Service;
        private readonly IMapper _Mapper;

        public FuncionarioController(IMapper mapper, IConfiguration connection)
        {
            _Service = new FuncionarioService(connection.GetConnectionString("DefaultConnection"));
            _Mapper = mapper;
        }

        [HttpPost("AdicionarFuncionario")] // Rota (EndPoint)
        public void AdicionarCidade(CreateFuncionarioDTO funcionarioToMap)
        {
            Funcionario funcionario = _Mapper.Map<Funcionario>(funcionarioToMap);
            _Service.Adicionar(funcionario);
        }

        [HttpGet("VisualizarFuncionario")] // Rota (EndPoint)
        public List<Funcionario> ListarFuncionarios()
        {
            return _Service.Listar();
        }

        [HttpGet("BuscarFuncionarioPorId")] // Rota (EndPoint)
        public Funcionario BuscarFuncionarioPorId(int id)
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
