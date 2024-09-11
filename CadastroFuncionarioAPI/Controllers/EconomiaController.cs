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
            funcionario.Salario = FuncionarioScript.GetSalarioFromCargoId(funcionarioToMap.CargoId);

            _Service.Adicionar(funcionario);
        }
    }
}
