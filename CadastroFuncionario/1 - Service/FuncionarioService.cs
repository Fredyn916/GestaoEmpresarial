using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Service
{
    public class FuncionarioService
    {
        public FuncionarioRepository _repository { get; set; }

        public FuncionarioService(string connectionString)
        {
            _repository = new FuncionarioRepository(connectionString);
        }

        public void Adicionar(Funcionario funcionario)
        {
            _repository.Adicionar(funcionario);
        }

        public void Remover(int id)
        {
            _repository.Remover(id);
        }

        public void Editar(int id, Funcionario funcionarioEdit)
        {
            _repository.Editar(id, funcionarioEdit);
        }

        public List<Funcionario> Listar()
        {
            return _repository.Listar();
        }

        public Funcionario BuscarFuncionarioPorId(int id)
        {
            return _repository.BuscarFuncionarioPorId(id);
        }
    }
}
