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
    }
}
