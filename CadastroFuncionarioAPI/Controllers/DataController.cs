using AutoMapper;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Data.Script;
using GestaoEmpresarial.Service;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class DataController : ControllerBase
    {
        private DataService _Service;
        private readonly IMapper _Mapper;

        public DataController(IMapper mapper, IConfiguration connection)
        {
            _Service = new DataService(connection.GetConnectionString("DefaultConnection"));
            _Mapper = mapper;
        }

        [HttpPost("AdicionarDatas")] // Rota (EndPoint)
        public void AdicionarDatas()
        {
            _Service.Adicionar();
        }
    }
}
