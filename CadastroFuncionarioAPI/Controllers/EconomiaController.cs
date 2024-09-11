using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Data.Script;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    public class EconomiaController : ControllerBase
    {
        [HttpPost("AdicionarFolhaFinanceira")] // Rota (EndPoint)
        public void AdicionarCidade(CreateFuncionarioDTO funcionarioToMap)
        {
            Funcionario funcionario = _Mapper.Map<Funcionario>(funcionarioToMap);
            funcionario.Salario = FuncionarioScript.GetSalarioFromCargoId(funcionarioToMap.CargoId);

            _Service.Adicionar(funcionario);
        }
    }
}
