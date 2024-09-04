using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Service
{
    public class FuncionarioService
    {
        public FuncionarioRepository repository { get; set; }

        public FuncionarioService(IConfiguration connection)
        {
            repository = new FuncionarioRepository(connection);
        }

        public void Adicionar(Funcionario funcionario)
        {
            repository.Adicionar(funcionario);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public void Editar(int id, Funcionario funcionarioEdit)
        {
            repository.Editar(id, funcionarioEdit);
        }

        public List<Funcionario> Listar()
        {
            return repository.Listar();
        }

        public Funcionario BuscarFuncionarioPorId(int id)
        {
            return repository.BuscarFuncionarioPorId(id);
        }
    }
}
