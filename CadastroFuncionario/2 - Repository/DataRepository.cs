using Dapper;
using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Data.Script;
using GestaoEmpresarial.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace GestaoEmpresarial.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public DataRepository(IConfiguration connection) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connection.GetConnectionString("DefaultConnection");
        }

        public void Adicionar()
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            int datasCount = connection.QueryFirst<int>(DataBalancoScript.SelectCountAllDatasBalanco()); // Query Select na tabela para retornar o Count

            if(datasCount == 0)
            {
                for (int i = 0; i < 1200; i++)
                {
                    DataBalanco dataDoMes = new DataBalanco()
                    {
                        Date = DateTime.Now.AddMonths(i)
                    };
                    connection.Insert<DataBalanco>(dataDoMes);
                }
            }
        }

        public List<DataBalanco> Listar()
        {
            using var connection = new SQLiteConnection(_ConnectionString);
            return connection.GetAll<DataBalanco>().ToList();
        }

        public DataBalanco BuscarPorID(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);
            return connection.Get<DataBalanco>(id);
        }
    }
}
