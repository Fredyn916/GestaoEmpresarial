using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Data.Repository
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
                CREATE TABLE IF NOT EXISTS Cargos(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Ocupacao TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Funcionarios(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Idade INTEGER NOT NULL,
                    Peso REAL NOT NULL,
                    Salario REAL NOT NULL,
                    CargoId INTEGER NOT NULL,
                    FOREIGN KEY (CargoId) REFERENCES Cargos(Id)
                );"; // Criando aa tabelaa no banco se não existirem

                string commandINSERT = @"
                INSERT INTO Cargos(Ocupacao)
                VALUES ('Diretor Executivo'), 
                       ('Diretor de Operações'), 
                       ('Diretor Financeiro'), 
                       ('Diretor de Marketing'),
                       ('Analista'), 
                       ('Estagiário'), 
                       ('Supervisor'), 
                       ('Gerente'), 
                       ('Presidente'), 
                       ('Zelador');
                "; // Comando para adicionar os cargos se não existirem

                using (var command = new SQLiteCommand(commandCREATE, connection))
                {
                    command.ExecuteNonQuery();
                }

                string verificadorCargosCommand = "SELECT COUNT(*) FROM Cargos;"; // Comando para contar quantos itens existem na tabela {Cargos}

                using (var commandVerificador = new SQLiteCommand(verificadorCargosCommand, connection))
                {
                    long cargoCount = (long)commandVerificador.ExecuteScalar();

                    // Se a tabela Cargos estiver vazia, insere os cargos
                    if (cargoCount == 0)
                    {
                        using (var insertCommand = new SQLiteCommand(commandINSERT, connection))
                        {
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
