using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using GestaoEmpresarial.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace GestaoEmpresarial.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly string _ConnectionString; // Variável da connection string a ser preenchida
        private readonly ICargoRepository _Repository;

        public FuncionarioRepository(IConfiguration connection, ICargoRepository cargoRepository) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connection.GetConnectionString("DefaultConnection");
            _Repository = cargoRepository;
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