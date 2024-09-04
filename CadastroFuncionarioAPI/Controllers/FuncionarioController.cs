using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Service;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class FuncionarioController : ControllerBase
    {
        private FuncionarioService _service;

        public FuncionarioController(IConfiguration connection)
        {
            _service = new FuncionarioService(connection.GetConnectionString("DefaultConnection"));
        }

        [HttpPost("AdicionarFuncionario")] // Rota (EndPoint)
        public void AdicionarCidade(Funcionario funcionario)
        {
            _service.Adicionar(funcionario);
        }

        [HttpGet("VisualizarFuncionario")] // Rota (EndPoint)
        public List<Funcionario> ListarFuncionarios()
        {
            return _service.Listar();
        }

        [HttpGet("BuscarFuncionarioPorId")] // Rota (EndPoint)
        public Funcionario BuscarFuncionarioPorId(int id)
        {
            return _service.BuscarFuncionarioPorId(id);
        }

        [HttpPut("EditarFuncionario")] // Rota (EndPoint)
        public void EditarFuncionario(int id, Funcionario funcionario)
        {
            _service.Editar(id, funcionario);
        }

        [HttpDelete("RemoverFuncionario")] // Rota (EndPoint)
        public void RemoverFuncionario(int id)
        {
            _service.Remover(id);
        }
    }
}
