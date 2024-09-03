using Dapper;
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
        public static void Inicializar()
        {
            using var connection = new SQLiteConnection("Data Source=GestaoEmpresarial.db"); // Criando a conexão
            
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

            connection.Execute(commandCREATE);

            string verificadorCargosCommand = "SELECT COUNT(*) FROM Cargos;"; // Comando para contar quantos itens existem na tabela {Cargos}

            using (var commandVerificador = new SQLiteCommand(verificadorCargosCommand, connection))
            {
                connection.Open(); // Atendendo a requisição do "ExecuteScalar"

                long cargoCount = (long)commandVerificador.ExecuteScalar();

                // Se a tabela 'Cargos' estiver vazia, insere os cargos
                if (cargoCount == 0)
                {
                    connection.Execute(commandINSERT);
                }
            }
        }
    }
}