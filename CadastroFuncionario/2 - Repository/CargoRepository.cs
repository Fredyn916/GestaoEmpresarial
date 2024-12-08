﻿using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;

namespace GestaoEmpresarial.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public CargoRepository(IConfiguration connection) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connection.GetConnectionString("DefaultConnection");
        }

        public void Adicionar(Cargo cargo)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Insert<Cargo>(cargo);
        }

        public List<Cargo> Listar()
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.GetAll<Cargo>().ToList();
        }

        public Cargo BuscarCargoPorId(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.Get<Cargo>(id);
        }

        public void Editar(Cargo editCargo)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Update<Cargo>(editCargo);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            Cargo cargoToRemove = BuscarCargoPorId(id);

            connection.Delete<Cargo>(cargoToRemove);
        }
    }
}
