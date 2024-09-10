using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Repository.Data.Script
{
    public static class FuncionarioScript
    {
        public static string InsertFuncionario()
        {
            string commandINSERTFuncionario = @"
                INSERT INTO Funcionarios(Nome, Idade, Peso, Salario, CargoId)
                VALUES (@Nome, @Idade, @Peso, @Salario, @CargoId)";

            return commandINSERTFuncionario;
        }

        public static string SelectFuncionarioPorId()
        {
            string commandSELECTFuncionario = "SELECT Id, Nome, Idade, Peso, Salario, CargoId FROM Funcionarios WHERE Id = @Id;";

            return commandSELECTFuncionario;
        }

        public static string UpdateFuncionario()
        {
            string commandUPTADEFuncionario = @"
                UPDATE Funcionarios
                SET Nome = @Nome, Idade = @Idade, Peso = @Peso, Salario = @Salario, CargoId = @CargoId
                WHERE Id = @Id";

            return commandUPTADEFuncionario;
        }

        public static string DeleteFuncionario()
        {
            string commandDELETEFuncionario = "DELETE FROM Funcionarios WHERE Id = @Id";

            return commandDELETEFuncionario;
        }

        public static string SelectFuncionarios()
        {
            string commandSELECTFuncionarios = "SELECT Id, Nome, Idade, Peso, Salario, CargoId FROM Funcionarios;";

            return commandSELECTFuncionarios;
        }

        public static double GetSalarioFromCargoId(int id)
        {
            double salario = 0.0;

            switch (id)
            {
                case 1:
                    salario = 100.000;
                    break;
                case 2:
                    salario = 70.000;
                    break;
                case 3:
                    salario = 60.000;
                    break;
                case 4:
                    salario = 50.000;
                    break;
                case 5:
                    salario = 10.000;
                    break;
                case 6:
                    salario = 2.000;
                    break;
                case 7:
                    salario = 12.000;
                    break;
                case 8:
                    salario = 25.000;
                    break;
                case 9:
                    salario = 120.000;
                    break;
                case 10:
                    salario = 3.000;
                    break;
            }

            return salario;
        }
    }
}
