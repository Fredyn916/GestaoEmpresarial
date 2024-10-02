using AutoMapper;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.AcaoDTO;
using GestaoEmpresarial.Service;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class AcaoController : ControllerBase
    {
        private AcaoService _Service;
        private readonly IMapper _Mapper;

        public AcaoController(IMapper mapper, IConfiguration connection)
        {
            _Service = new AcaoService(connection.GetConnectionString("DefaultConnection"));
            _Mapper = mapper;
        }

        [HttpPost("AdicionarAcao")] // Rota (EndPoint)
        public void AdicionarAcao(int codigoAcao, CreateAcaoDTO acaoDTO)
        {
            CreateCodigoAcaoDTO CodigoAcao = new CreateCodigoAcaoDTO();
            CodigoAcao.Codigo = codigoAcao;

            Acao acao = _Mapper.Map<Acao>(acaoDTO);
            acao.Codigo = CodigoAcao.Codigo;
            acao.Ticker = acao.Ticker + CodigoAcao.Codigo.ToString();

            _Service.Adicionar(acao);
        }
    }
}
