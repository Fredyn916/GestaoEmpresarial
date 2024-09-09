using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Repository.Data.Script
{
    public static class CargoScript
    {
        public static string InsertCargos()
        {
            string commandINSERTCargos = @"
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
                "; // Comando para adicionar os cargos

            return commandINSERTCargos;
        }

        public static string SelectCountAllCargos()
        {
            string commandSELECTCOUNTCargos = "SELECT COUNT(*) FROM Cargos;"; // Comando para contar quantos itens existem na tabela {Cargos}

            return commandSELECTCOUNTCargos;
        }

        public static string SelectCargos()
        {
            string commandSELECTCargos = "SELECT Id, Ocupacao FROM Cargos;";

            return commandSELECTCargos;
        }

        public static string SelectCargoPorId()
        {
            string commandSELECTCargo = "SELECT Id, Ocupacao FROM Cargos WHERE Id = @Id;";

            return commandSELECTCargo;
        }
    }
}
