using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Repository.Data.Script
{
    public static class DataBaseScript
    {
        public static string CreateTables()
        {
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
                );"; // Comando para criar as tabelas no banco

            return commandCREATE;
        }
    }
}
