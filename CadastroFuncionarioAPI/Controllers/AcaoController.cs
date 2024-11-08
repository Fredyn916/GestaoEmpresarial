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
        public IActionResult AdicionarAcao(CreateAcaoDTO acaoDTO)
        {
            try
            {
                Acao acao = _Mapper.Map<Acao>(acaoDTO);
                acao.Ticker = acao.Ticker + acao.Codigo.ToString();

                _Service.Adicionar(acao);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao adicionar Ação." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Visualiza as ações do Banco de Dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("VisualizarAcoes")] // Rota (EndPoint)
        public List<Acao> ListarAcoes()
        {
            try
            {
                return _Service.Listar();
            }
            catch (Exception erro)
            {
                throw new Exception("Ocorreu um erro ao listar Ação." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Visualiza uma ação do Banco de Dados respectivo ao Id do parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarAcaoPorId")] // Rota (EndPoint)
        public Acao BuscarAcaoPorId(int id)
        {
            try
            {
                return _Service.BuscarAcaoPorId(id);
            }
            catch (Exception erro)
            {
                throw new Exception("Ocorreu um erro ao listar Ação por Id." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Edita uma ação do Banco de Dados respectivo ao valor da propriedade "Id" do objeto do parâmetro
        /// </summary>
        /// <param name="acaoDTO"></param>
        [HttpPut("EditarFuncionario")] // Rota (EndPoint)
        public IActionResult EditarAcao(UpdateAcaoDTO acaoDTO)
        {
            try
            {
                Acao acao = _Mapper.Map<Acao>(acaoDTO);
                acao.Ticker = acao.Ticker + acao.Codigo.ToString();

                _Service.Editar(acao);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao editar Ação." +
                    $"O erro é: \n {erro.Message}");
            }
        }
        /// <summary>
        /// Remove uma ação do Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("RemoverAcao")] // Rota (EndPoint)
        public IActionResult RemoverAcao(int id)
        {
            try
            {
                _Service.Remover(id);
                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest("Ocorreu um erro ao remover Ação." +
                    $"O erro é: \n {erro.Message}");
            }
        }
    }
}
