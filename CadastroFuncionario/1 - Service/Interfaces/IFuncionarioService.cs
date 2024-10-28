using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;

namespace GestaoEmpresarial.Service.Interfaces
{
    public interface IFuncionarioService
    {
        void Adicionar(Funcionario funcionario);
        List<ReadFuncionarioDTO> Listar();
        ReadFuncionarioDTO BuscarFuncionarioPorId(int id);
        void Editar(Funcionario funcionarioEdit);
        void Remover(int id);
    }
}
