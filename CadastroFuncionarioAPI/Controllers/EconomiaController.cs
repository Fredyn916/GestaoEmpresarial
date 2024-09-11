using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Data.Script;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace GestaoEmpresarialAPI.Controllers
{
    public class EconomiaController : ControllerBase
    {
        private readonly IMapper _Mapper;

        [HttpPost("AdicionarFolhaFinanceira")] // Rota (EndPoint)
        public void AdicionarCidade(CreateEconomiaDTO folhaToMap)
        {
            Economia folhaFinanceira = _Mapper.Map<Economia>(folhaToMap);
            folhaFinanceira.TotalCapital = EconomiaScript.GetTotalCapital(folhaToMap.TotalBruto, folhaToMap.TotalInvestimentos);
            folhaFinanceira.TotalDespesas = EconomiaScript.GetTotalDespesas(folhaToMap.DespesasImovel, folhaToMap.DespesasFuncionarios, folhaToMap.DespesasServicos);
            folhaFinanceira.AlterCapitalResultado(EconomiaScript.GetCapitalResultado(folhaFinanceira.TotalCapital, folhaFinanceira.TotalDespesas));

            // _Service.Adicionar(funcionario); (Service Economia)
        }
    }
}