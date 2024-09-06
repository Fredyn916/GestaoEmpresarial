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
                "; // Comando para adicionar os cargos

            return commandINSERT;
        }

        public static string SelectCountAllCargos()
        {
            string verificadorCargosCommand = "SELECT COUNT(*) FROM Cargos;"; // Comando para contar quantos itens existem na tabela {Cargos}

            return verificadorCargosCommand;
        }
    }
}
