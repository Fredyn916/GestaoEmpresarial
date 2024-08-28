using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Repository
{
    public class InicializadorDB
    {
        private const string ConnectionString = "Data Source=GestaoEmpresarial.db"; // ConnectionString (Parâmetros necessários para criar um banco de dados)
        // Caso não exista o banco de dados, a var connection cria um database automaticamente

        public static void Inicializar()
        {
            using (var connection = new SQLiteConnection(ConnectionString)) // Criando a conexão
            {
                connection.Open();

                string commandCREATE = @"
                CREATE TABLE IF NOT EXISTS Funcionarios(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Salario REAL NOT NULL,
                    CargoId INTEGER FOREIGN KEY NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Cargos(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Ocupacao TEXT NOT NULL
                );";

                // Criando a tabela no banco se não existir

                using (var command = new SQLiteCommand(commandCREATE, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
