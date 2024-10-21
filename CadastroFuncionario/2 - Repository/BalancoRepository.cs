using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
using System.Data.SQLite;

namespace GestaoEmpresarial.Repository
{
    public class BalancoRepository
    {
        public readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public BalancoRepository(string connectionString) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connectionString;
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
    }
}
