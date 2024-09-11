using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Data.Script;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GestaoEmpresarial.Service;

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

        [HttpPost("AdicionarFolhaFinanceira")] // Rota (EndPoint)
        public void AdicionarCidade([FromBody] CreateEconomiaDTO folhaToMap)
        {
            Economia folhaFinanceira = _Mapper.Map<Economia>(folhaToMap);
            folhaFinanceira.TotalCapital = EconomiaScript.GetTotalCapital(folhaToMap.TotalBruto, folhaToMap.TotalInvestimentos);
            folhaFinanceira.TotalDespesas = EconomiaScript.GetTotalDespesas(folhaToMap.DespesasImovel, folhaToMap.DespesasFuncionarios, folhaToMap.DespesasServicos);
            folhaFinanceira.CapitalResultado = EconomiaScript.GetCapitalResultado(folhaFinanceira.TotalCapital, folhaFinanceira.TotalDespesas);

            _Service.Adicionar(folhaFinanceira);
        }
    }
}