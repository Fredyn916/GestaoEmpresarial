using AutoMapper;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.AcaoDTO;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using GestaoEmpresarial.Service;
using GestaoEmpresarial.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class AcaoController : ControllerBase
    {
        private IAcaoService _Service;
        private readonly IMapper _Mapper;

        public AcaoController(IMapper mapper, IConfiguration connection)
        {
            _Service = new AcaoService(connection.GetConnectionString("DefaultConnection"));
            _Mapper = mapper;
        }

        [HttpPost("AdicionarAcao")] // Rota (EndPoint)
        public void AdicionarAcao(CreateAcaoDTO acaoDTO)
        {
            Acao acao = _Mapper.Map<Acao>(acaoDTO);
            acao.Ticker = acao.Ticker + acao.Codigo.ToString();

            _Service.Adicionar(acao);
        }

        [HttpGet("VisualizarAcoes")] // Rota (EndPoint)
        public List<Acao> ListarAcoes()
        {
            return _Service.Listar();
        }

        [HttpGet("BuscarAcaoPorId")] // Rota (EndPoint)
        public Acao BuscarAcaoPorId(int id)
        {
            return _Service.BuscarAcaoPorId(id);
        }

        [HttpPut("EditarFuncionario")] // Rota (EndPoint)
        public void EditarAcao(UpdateAcaoDTO acaoDTO)
        {
            Acao acao = _Mapper.Map<Acao>(acaoDTO);
            acao.Ticker = acao.Ticker + acao.Codigo.ToString();

            _Service.Editar(acao);
        }

        [HttpDelete("RemoverAcao")] // Rota (EndPoint)
        public void RemoverAcao(int id)
        {
            _Service.Remover(id);
        }
    }
}
