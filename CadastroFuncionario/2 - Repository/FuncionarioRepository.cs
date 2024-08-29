using GestaoEmpresarial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Repository
{
    public class FuncionarioRepository
    {
        private const string ConnectionString = "Data Source=GestaoEmpresarial.db"; // ConnectionString (Parâmetros necessários para criar um banco de dados)
        // Caso não exista o banco de dados, a var connection cria um database automaticamente

        public void Adicionar(Funcionario funcionario)
        {
            using (var connection = new SQLiteConnection(ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para inserir dados nas tabelas
                string commandInsert = @"
                INSERT INTO Funcionarios(Nome, Idade, Peso, Salario, CargoId)
                VALUES (@Nome, @Idade, @Peso, @Salario, @CargoId)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@Nome", funcionario.Nome); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Idade", funcionario.Idade);
                    command.Parameters.AddWithValue("@Peso", funcionario.Peso);
                    command.Parameters.AddWithValue("@Salario", funcionario.Salario);
                    command.Parameters.AddWithValue("@CargoId", funcionario.CargoId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remover(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para deletar os dados das tabelas
                string commandDelete = "DELETE FROM Funcionarios WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandDelete, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.ExecuteNonQuery();
                }

            }
        }

        public void Editar(int id, Funcionario editFuncionario)
        {
            using (var connection = new SQLiteConnection(ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para editar os dados das tabelas
                string commandUptade = @"
                UPDATE Funcionarios
                SET Nome = @Nome, Idade = @Idade, Peso = @Peso, Salario = @Salario, CargoId = @CargoId
                WHERE Id = @Id";

                using (var command = new SQLiteCommand(commandUptade, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro
                    command.Parameters.AddWithValue("@Nome", editFuncionario.Nome);
                    command.Parameters.AddWithValue("@Idade", editFuncionario.Idade);
                    command.Parameters.AddWithValue("@Peso", editFuncionario.Peso);
                    command.Parameters.AddWithValue("@Salario", editFuncionario.Salario);
                    command.Parameters.AddWithValue("@CargoId", editFuncionario.CargoId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Funcionario> Listar()
        {
            List<Funcionario> listAux = new List<Funcionario>();

            using (var connection = new SQLiteConnection(ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, Idade, Peso, Salario, CargoId FROM Funcionarios;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Funcionario FuncionarioAux = new Funcionario();
                            FuncionarioAux.Id = int.Parse(reader["Id"].ToString());
                            FuncionarioAux.Nome = reader["Nome"].ToString();
                            FuncionarioAux.Idade = int.Parse(reader["Idade"].ToString());
                            FuncionarioAux.Peso = double.Parse(reader["Peso"].ToString());
                            FuncionarioAux.Salario = double.Parse(reader["Salario"].ToString());
                            FuncionarioAux.CargoId = int.Parse(reader["CargoId"].ToString());

                            listAux.Add(FuncionarioAux);
                        }
                    }
                }
            }
            return listAux;
        }

        public Funcionario BuscarFuncionarioPorId(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Nome, Idade, Peso, Salario, CargoId FROM Funcionarios WHERE Id = @Id;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Funcionario FuncionarioAux = new Funcionario();
                            FuncionarioAux.Id = int.Parse(reader["Id"].ToString());
                            FuncionarioAux.Nome = reader["Nome"].ToString();
                            FuncionarioAux.Idade = int.Parse(reader["Idade"].ToString());
                            FuncionarioAux.Peso = double.Parse(reader["Peso"].ToString());
                            FuncionarioAux.Salario = double.Parse(reader["Salario"].ToString());
                            FuncionarioAux.CargoId = int.Parse(reader["CargoId"].ToString());

                            return FuncionarioAux;
                        }
                    }
                }
            }
            return null;
        }
    }
}