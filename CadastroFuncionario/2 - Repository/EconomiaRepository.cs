﻿using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
using System.Data.SQLite;

namespace GestaoEmpresarial.Repository
{
    public class EconomiaRepository
    {
        public readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public EconomiaRepository(string connectionString) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connectionString;
        }

        public void Adicionar(Economia folhaFinanceira)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Insert<Economia>(folhaFinanceira);
        }

        public List<Economia> Listar()
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.GetAll<Economia>().ToList();
        }

        public Economia BuscarRelatorioPorId(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.Get<Economia>(id);
        }

        public void Editar(Economia relatorioFinanceiro)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Update<Economia>(relatorioFinanceiro);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);
            Economia relatorioToRemove = BuscarRelatorioPorId(id);

            connection.Delete<Economia>(relatorioToRemove);
        }
    }
}
