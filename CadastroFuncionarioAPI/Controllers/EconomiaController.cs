using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Data.Script;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GestaoEmpresarial.Service;
using GestaoEmpresarial.Entidades.DTO.EconomiaDTO;

namespace GestaoEmpresarialAPI.Controllers
{
    public class EconomiaController : ControllerBase
    {
        private EconomiaService _Service;
        private readonly IMapper _Mapper;

        public EconomiaController(IMapper mapper, IConfiguration connection)
        {
            _Service = new EconomiaService(connection.GetConnectionString("DefaultConnection"));
            _Mapper = mapper;
        }

        [HttpPost("AdicionarRelatorioFinanceiro")] // Rota (EndPoint)
        public void AdicionarRelatorio([FromBody] CreateEconomiaDTO relatorioToMap)
        {
            Economia relatorioFinanceiro = _Mapper.Map<Economia>(relatorioToMap);
            relatorioFinanceiro.TotalCapital = EconomiaScript.GetTotalCapital(relatorioToMap.TotalBruto, relatorioToMap.TotalInvestimentos);
            relatorioFinanceiro.TotalDespesas = EconomiaScript.GetTotalDespesas(relatorioToMap.DespesasImovel, relatorioToMap.DespesasFuncionarios, relatorioToMap.DespesasServicos);
            relatorioFinanceiro.CapitalResultado = EconomiaScript.GetCapitalResultado(relatorioFinanceiro.TotalCapital, relatorioFinanceiro.TotalDespesas);

            _Service.Adicionar(relatorioFinanceiro);
        }

        [HttpGet("VisualizarRelatoriosFinanceiros")] // Rota (EndPoint)
        public List<Economia> ListarRelatorios()
        {
            return _Service.Listar();
        }

        [HttpGet("BuscarRelatorioPorId")] // Rota (EndPoint)
        public Economia BuscarRelatorioPorId(int id)
        {
            return _Service.BuscarRelatorioPorId(id);
        }

        [HttpPut("EditarRelatorio")] // Rota (EndPoint)
        public void EditarFuncionario([FromBody] UpdateEconomiaDTO relatorioToMap) // Data Annotation 'FromBody' solicita o parâmetro no corpo por JSON
        {
            Economia relatorioFinanceiro = _Mapper.Map<Economia>(relatorioToMap);
            relatorioFinanceiro.TotalCapital = EconomiaScript.GetTotalCapital(relatorioToMap.TotalBruto, relatorioToMap.TotalInvestimentos);
            relatorioFinanceiro.TotalDespesas = EconomiaScript.GetTotalDespesas(relatorioToMap.DespesasImovel, relatorioToMap.DespesasFuncionarios, relatorioToMap.DespesasServicos);
            relatorioFinanceiro.CapitalResultado = EconomiaScript.GetCapitalResultado(relatorioFinanceiro.TotalCapital, relatorioFinanceiro.TotalDespesas);

            _Service.Editar(relatorioFinanceiro);
        }

        [HttpDelete("RemoverRelatorio")] // Rota (EndPoint)
        public void RemoverRelatorio(int id)
        {
            _Service.Remover(id);
        }
    }
}