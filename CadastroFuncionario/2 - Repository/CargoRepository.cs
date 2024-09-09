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
    public class CargoRepository
    {
        // ConnectionString (Parâmetros necessários para criar um banco de dados)
        // Caso não exista o banco de dados, a var connection cria um database automaticamente
        public readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public CargoRepository(string connectionString) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connectionString;
        }

        public List<Cargo> Listar()
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.GetAll<Cargo>().ToList();
        }

        public Cargo BuscarCargoPorId(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.Get<Cargo>(id);
        }
    }
}
