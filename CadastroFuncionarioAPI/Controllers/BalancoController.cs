using AutoMapper;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.BalancoDTO;
using GestaoEmpresarial.Service;
using GestaoEmpresarial.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class BalancoController : ControllerBase
    {
        private IBalancoService _Service;
        private readonly IMapper _Mapper;

        public BalancoController(IMapper mapper, IConfiguration connection)
        {
            _Service = new BalancoService(connection.GetConnectionString("DefaultConnection"));
            _Mapper = mapper;
        }

        [HttpPost("AdicionarBalanco")] // Rota (EndPoint)
        public void AdicionarBalanco(CreateBalancoDTO balancoToMap)
        {
            Balanco balanco = _Mapper.Map<Balanco>(balancoToMap);

            _Service.Adicionar(balanco);
        }

        [HttpGet("VisualizarBalancos")] // Rota (EndPoint)
        public List<Balanco> ListarBalanco()
        {
            return _Service.Listar();
        }

        [HttpGet("BuscarBalancoPorId")] // Rota (EndPoint)
        public Balanco BuscarBalancoPorId(int id)
        {
            return _Service.BuscarBalancoPorId(id);
        }

        [HttpPut("EditarBalanco")] // Rota (EndPoint)
        public void EditarBalanco(Balanco balanco)
        {
            _Service.Editar(balanco);
        }

        [HttpDelete("RemoverBalanco")] // Rota (EndPoint)
        public void RemoverBalanco(int id)
        {
            _Service.Remover(id);
        }
    }
}
