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
        private const string ConnectionString = "Data Source=GestaoEmpresarial.db"; // ConnectionString (Parâmetros necessários para criar um banco de dados)
        // Caso não exista o banco de dados, a var connection cria um database automaticamente

        public List<Cargo> Listar()
        {
            List<Cargo> listAux = new List<Cargo>();

            using (var connection = new SQLiteConnection(ConnectionString)) // Criando a conexão
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
                            Cargo CargoAux = new Cargo();
                            CargoAux.Id = int.Parse(reader["Id"].ToString());
                            CargoAux.Ocupacao = reader["Ocupacao"].ToString();

                            listAux.Add(CargoAux);
                        }
                    }
                }
            }
            return listAux;
        }

        public Cargo BuscarCargoPorId(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString)) // Criando a conexão
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
                            Cargo CargoAux = new Cargo();
                            CargoAux.Id = int.Parse(reader["Id"].ToString());
                            CargoAux.Ocupacao = reader["Ocupacao"].ToString();

                            return CargoAux;
                        }
                    }
                }
            }
            return null;
        }
    }
}
