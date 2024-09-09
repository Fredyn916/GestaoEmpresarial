using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Repository
{
    public class FuncionarioRepository
    {
        // ConnectionString (Parâmetros necessários para criar um banco de dados)
        // Caso não exista o banco de dados, a var connection cria um database automaticamente
        public readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public FuncionarioRepository(string connectionString) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connectionString;
        }

        public void Adicionar(Funcionario funcionario)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Insert<Funcionario>(funcionario);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);
            Funcionario funcionarioToRemove = BuscarFuncionarioPorId(id);

            connection.Delete<Funcionario>(funcionarioToRemove);
        }

        public void Editar(int id, Funcionario editFuncionario)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Update<Funcionario>(editFuncionario);
        }

        public List<Funcionario> Listar()
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.GetAll<Funcionario>().ToList();
        }

        public Funcionario BuscarFuncionarioPorId(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.Get<Funcionario>(id);
        }
    }
}