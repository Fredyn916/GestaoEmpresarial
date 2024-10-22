using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using GestaoEmpresarial.Repository;

namespace GestaoEmpresarial.Service
{
    public class FuncionarioService
    {
        public FuncionarioRepository _Repository { get; set; }

        public FuncionarioService(string connectionString)
        {
            _Repository = new FuncionarioRepository(connectionString);
        }

        public void Adicionar(Funcionario funcionario)
        {
            _Repository.Adicionar(funcionario);
        }

        public List<ReadFuncionarioDTO> Listar()
        {
            return _Repository.Listar();
        }

        public ReadFuncionarioDTO BuscarFuncionarioPorId(int id)
        {
            return _Repository.BuscarFuncionarioDTOPorId(id);
        }

        public void Editar(Funcionario funcionarioEdit)
        {
            _Repository.Editar(funcionarioEdit);
        }

        public void Remover(int id)
        {
            _Repository.Remover(id);
        }
    }
}
