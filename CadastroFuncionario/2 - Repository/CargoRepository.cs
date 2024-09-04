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
            List<Cargo> listAux = new List<Cargo>();

            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Ocupacao FROM Cargos;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cargo cargoAux = new Cargo();
                            cargoAux.Id = int.Parse(reader["Id"].ToString());
                            cargoAux.Ocupacao = reader["Ocupacao"].ToString();

                            listAux.Add(cargoAux);
                        }
                    }
                }
            }
            return listAux;
        }

        public Cargo BuscarCargoPorId(int id)
        {
            using (var connection = new SQLiteConnection(_ConnectionString)) // Criando a conexão
            {
                connection.Open();

                // Comando para selecionar e exibir os dados das tabelas
                string commandSelectId = "SELECT Id, Ocupacao FROM Cargos WHERE Id = @Id;";

                using (var command = new SQLiteCommand(commandSelectId, connection))
                {
                    command.Parameters.AddWithValue("@Id", id); // Substitui a chave no comando para a variável do parâmetro

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Cargo cargoAux = new Cargo();
                            cargoAux.Id = int.Parse(reader["Id"].ToString());
                            cargoAux.Ocupacao = reader["Ocupacao"].ToString();

                            return cargoAux;
                        }
                    }
                }
            }
            return null;
        }
    }
}
