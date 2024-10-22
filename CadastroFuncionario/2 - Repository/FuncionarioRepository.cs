using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using System.Data.SQLite;

namespace GestaoEmpresarial.Repository
{
    public class FuncionarioRepository
    {
        // ConnectionString (Parâmetros necessários para criar um banco de dados)
        // Caso não exista o banco de dados, a var connection cria um database automaticamente
        public readonly string _ConnectionString; // Variável da connection string a ser preenchida
        public CargoRepository _Repository { get; set; }

        public FuncionarioRepository(string connectionString) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connectionString;
            _Repository = new CargoRepository(connectionString);
        }

        public void Adicionar(Funcionario funcionario)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Insert<Funcionario>(funcionario);
        }

        public List<ReadFuncionarioDTO> Listar()
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            List<Funcionario> funcionarios = connection.GetAll<Funcionario>().ToList();
            List<ReadFuncionarioDTO> funcionariosDTO = new List<ReadFuncionarioDTO>();

            foreach (Funcionario f in funcionarios)
            {
                ReadFuncionarioDTO funcionarioDTO = new ReadFuncionarioDTO();
                funcionarioDTO.Id = f.Id;
                funcionarioDTO.Nome = f.Nome;
                funcionarioDTO.Idade = f.Idade;
                funcionarioDTO.Peso = f.Peso;
                funcionarioDTO.Salario = f.Salario;
                funcionarioDTO.Cargo = _Repository.BuscarCargoPorId(f.CargoId);

                funcionariosDTO.Add(funcionarioDTO);
            }
            return funcionariosDTO;
        }

        public ReadFuncionarioDTO BuscarFuncionarioDTOPorId(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            Funcionario funcionario = connection.Get<Funcionario>(id);
            ReadFuncionarioDTO funcionarioDTO = new ReadFuncionarioDTO();

            funcionarioDTO.Id = funcionario.Id;
            funcionarioDTO.Nome = funcionario.Nome;
            funcionarioDTO.Idade = funcionario.Idade;
            funcionarioDTO.Peso = funcionario.Peso;
            funcionarioDTO.Salario = funcionario.Salario;
            funcionarioDTO.Cargo = _Repository.BuscarCargoPorId(funcionario.CargoId);

            return funcionarioDTO;
        }

        public Funcionario BuscarFuncionarioPorId(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.Get<Funcionario>(id);
        }

        public void Editar(Funcionario editFuncionario)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Update<Funcionario>(editFuncionario);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            Funcionario funcionarioToRemove = BuscarFuncionarioPorId(id);

            connection.Delete<Funcionario>(funcionarioToRemove);
        }
    }
}