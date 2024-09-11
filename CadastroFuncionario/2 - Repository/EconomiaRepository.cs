using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
using System.Data.SQLite;

namespace GestaoEmpresarial.Repository
{
    public class EconomiaRepository
    {
        public readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public EconomiaRepository(string connectionString) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connectionString;
        }

        public void Adicionar(Economia folhaFinanceira)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Insert<Economia>(folhaFinanceira);
        }
    }
}
