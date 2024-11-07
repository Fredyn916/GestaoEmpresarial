using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Data.Script;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GestaoEmpresarial.Entidades.DTO.EconomiaDTO;
using GestaoEmpresarial.Service.Interfaces;

namespace GestaoEmpresarialAPI.Controllers
{
    public class EconomiaController : ControllerBase
    {
        private readonly IEconomiaService _Service;
        private readonly IMapper _Mapper;

        public EconomiaController(IMapper mapper, IEconomiaService economiaService)
        {
            _Service = economiaService;
            _Mapper = mapper;
        }
        /// <summary>
        /// Adiciona um relatória de economia no Banco de Dados
        /// </summary>
        /// <param name="relatorioToMap"></param>
        [HttpPost("AdicionarRelatorioFinanceiro")] // Rota (EndPoint)
        public void AdicionarRelatorio([FromBody] CreateEconomiaDTO relatorioToMap)
        {
            Economia relatorioFinanceiro = _Mapper.Map<Economia>(relatorioToMap);
            relatorioFinanceiro.TotalCapital = EconomiaScript.GetTotalCapital(relatorioToMap.TotalBruto, relatorioToMap.TotalInvestimentos);
            relatorioFinanceiro.TotalDespesas = EconomiaScript.GetTotalDespesas(relatorioToMap.DespesasImovel, relatorioToMap.DespesasFuncionarios, relatorioToMap.DespesasServicos);
            relatorioFinanceiro.CapitalResultado = EconomiaScript.GetCapitalResultado(relatorioFinanceiro.TotalCapital, relatorioFinanceiro.TotalDespesas);

            _Service.Adicionar(relatorioFinanceiro);
        }
        /// <summary>
        /// Visualiza os relatórios de economia do Banco de Dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("VisualizarRelatoriosFinanceiros")] // Rota (EndPoint)
        public List<Economia> ListarRelatorios()
        {
            return _Service.Listar();
        }
        /// <summary>
        /// Visualiza um relatório de economia do Banco de Dados respectivo ao Id do parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarRelatorioPorId")] // Rota (EndPoint)
        public Economia BuscarRelatorioPorId(int id)
        {
            return _Service.BuscarRelatorioPorId(id);
        }
        /// <summary>
        /// Edita um relatório de economia do Banco de Dados respectivo ao valor da propriedade "Id" do objeto do parâmetro
        /// </summary>
        /// <param name="relatorioToMap"></param>
        [HttpPut("EditarRelatorio")] // Rota (EndPoint)
        public void EditarFuncionario([FromBody] UpdateEconomiaDTO relatorioToMap) // Data Annotation 'FromBody' solicita o parâmetro no corpo por JSON
        {
            Economia relatorioFinanceiro = _Mapper.Map<Economia>(relatorioToMap);
            relatorioFinanceiro.TotalCapital = EconomiaScript.GetTotalCapital(relatorioToMap.TotalBruto, relatorioToMap.TotalInvestimentos);
            relatorioFinanceiro.TotalDespesas = EconomiaScript.GetTotalDespesas(relatorioToMap.DespesasImovel, relatorioToMap.DespesasFuncionarios, relatorioToMap.DespesasServicos);
            relatorioFinanceiro.CapitalResultado = EconomiaScript.GetCapitalResultado(relatorioFinanceiro.TotalCapital, relatorioFinanceiro.TotalDespesas);

            _Service.Editar(relatorioFinanceiro);
        }
        /// <summary>
        /// Remove um relatório de economia do Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("RemoverRelatorio")] // Rota (EndPoint)
        public void RemoverRelatorio(int id)
        {
            _Service.Remover(id);
        }
    }
}