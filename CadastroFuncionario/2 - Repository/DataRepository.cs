using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
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

            for(int i = 0; i < 1000; i++)
            {
                DataBalanco d = new DataBalanco()
                {
                    Date = DateTime.Now.AddDays(i),
                };
                connection.Insert<DataBalanco>(d);
            }
        }
    }
}
