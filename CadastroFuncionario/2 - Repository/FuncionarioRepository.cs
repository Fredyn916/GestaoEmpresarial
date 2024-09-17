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

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);
            ReadFuncionarioDTO funcionarioDTO = BuscarFuncionarioPorId(id);
            Funcionario funcionarioToRemove = new Funcionario();

            funcionarioToRemove.Id = funcionarioDTO.Id;
            funcionarioToRemove.Nome = funcionarioDTO.Nome;
            funcionarioToRemove.Idade = funcionarioDTO.Idade;
            funcionarioToRemove.Peso = funcionarioDTO.Peso;
            funcionarioToRemove.Salario = funcionarioDTO.Salario;
            funcionarioToRemove.CargoId = funcionarioDTO.Cargo.Id;

            connection.Delete<Funcionario>(funcionarioToRemove);
        }

        public void Editar(Funcionario editFuncionario)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Update<Funcionario>(editFuncionario);
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

        public ReadFuncionarioDTO BuscarFuncionarioPorId(int id)
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
    }
}