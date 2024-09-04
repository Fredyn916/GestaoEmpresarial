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
        public FuncionarioRepository _Repository { get; set; }

        public FuncionarioService(string connectionString)
        {
            _Repository = new FuncionarioRepository(connectionString);
        }

        public void Adicionar(Funcionario funcionario)
        {
            _Repository.Adicionar(funcionario);
        }

        public void Remover(int id)
        {
            _Repository.Remover(id);
        }

        public void Editar(int id, Funcionario funcionarioEdit)
        {
            _Repository.Editar(id, funcionarioEdit);
        }

        public List<Funcionario> Listar()
        {
            return _Repository.Listar();
        }

        public Funcionario BuscarFuncionarioPorId(int id)
        {
            return _Repository.BuscarFuncionarioPorId(id);
        }
    }
}
