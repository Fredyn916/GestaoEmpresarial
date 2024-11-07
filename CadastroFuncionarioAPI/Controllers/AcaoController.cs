using AutoMapper;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.AcaoDTO;
using GestaoEmpresarial.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class AcaoController : ControllerBase
    {
        private readonly IAcaoService _Service;
        private readonly IMapper _Mapper;

        public AcaoController(IMapper mapper, IAcaoService acaoService)
        {
            _Service = acaoService;
            _Mapper = mapper;
        }
        /// <summary>
        /// Adiciona uma ação no Banco de Dados
        /// </summary>
        /// <param name="acaoDTO"></param>
        [HttpPost("AdicionarAcao")] // Rota (EndPoint)
        public void AdicionarAcao(CreateAcaoDTO acaoDTO)
        {
            Acao acao = _Mapper.Map<Acao>(acaoDTO);
            acao.Ticker = acao.Ticker + acao.Codigo.ToString();

            _Service.Adicionar(acao);
        }
        /// <summary>
        /// Visualiza as ações do Banco de Dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("VisualizarAcoes")] // Rota (EndPoint)
        public List<Acao> ListarAcoes()
        {
            return _Service.Listar();
        }
        /// <summary>
        /// Visualiza uma ação do Banco de Dados respectivo ao Id do parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarAcaoPorId")] // Rota (EndPoint)
        public Acao BuscarAcaoPorId(int id)
        {
            return _Service.BuscarAcaoPorId(id);
        }
        /// <summary>
        /// Edita uma ação do Banco de Dados respectivo ao valor da propriedade "Id" do objeto do parâmetro
        /// </summary>
        /// <param name="acaoDTO"></param>
        [HttpPut("EditarFuncionario")] // Rota (EndPoint)
        public void EditarAcao(UpdateAcaoDTO acaoDTO)
        {
            Acao acao = _Mapper.Map<Acao>(acaoDTO);
            acao.Ticker = acao.Ticker + acao.Codigo.ToString();

            _Service.Editar(acao);
        }
        /// <summary>
        /// Remove uma ação do Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("RemoverAcao")] // Rota (EndPoint)
        public void RemoverAcao(int id)
        {
            _Service.Remover(id);
        }
    }
}
