using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;

namespace GestaoEmpresarial.Repository.Interfaces
{
    public interface IFuncionarioRepository
    {
        void Adicionar(Funcionario funcionario);
        List<ReadFuncionarioDTO> Listar();
        ReadFuncionarioDTO BuscarFuncionarioDTOPorId(int id);
        Funcionario BuscarFuncionarioPorId(int id);
        void Editar(Funcionario editFuncionario);
        void Remover(int id);
    }
}
