﻿using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.AcaoDTO;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using System.Data.SQLite;

namespace GestaoEmpresarial.Repository
{
    public class AcaoRepository
    {
        public readonly string _ConnectionString; // Variável da connection string a ser preenchida

        public AcaoRepository(string connectionString) // Bloco de código responsável por preencher a connectionString
        {
            _ConnectionString = connectionString;
        }

        public void Adicionar(Acao acao)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Insert<Acao>(acao);
        }

        public List<Acao> Listar()
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.GetAll<Acao>().ToList();
        }

        public Acao BuscarAcaoPorId(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            return connection.Get<Acao>(id);
        }

        public void Editar(Acao editAcao)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            connection.Update<Acao>(editAcao);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(_ConnectionString);

            Acao acaoToRemove = BuscarAcaoPorId(id);

            connection.Delete<Acao>(acaoToRemove);
        }
    }
}
