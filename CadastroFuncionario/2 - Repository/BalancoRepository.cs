using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace GestaoEmpresarial.Repository
{
    public class BalancoRepository : IBalancoRepository
    {
        private readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public BalancoRepository(IConfiguration connection) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connection.GetConnectionString("DefaultConnection");
        }

        public void Adicionar(Balanco balanco)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Insert<Balanco>(balanco);
        }

        public List<Balanco> Listar()
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.GetAll<Balanco>().ToList();
        }

        public Balanco BuscarBalancoPorId(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.Get<Balanco>(id);
        }

        public void Editar(Balanco editBalanco)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Update<Balanco>(editBalanco);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            Balanco balancoToRemove = BuscarBalancoPorId(id);

            connection.Delete<Balanco>(balancoToRemove);
        }
    }
}
