using Dapper.Contrib.Extensions;
using System.Data.SQLite;

namespace GestaoEmpresarial.Repository
{
    public class DataRepository
    {
        public readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public DataRepository(string connectionString) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connectionString;
        }

        public void Adicionar()
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            DateTime date = new DateTime(2024, 9, 1, 0, 0, 0);
            for (int i = 0; i < 1000; i++)
            {
                Data data = new Data();
                data.Date = date;

                connection.Insert<Data>(data);
                date = DateTime.Now.AddDays(1);
            }
        }
    }
}
