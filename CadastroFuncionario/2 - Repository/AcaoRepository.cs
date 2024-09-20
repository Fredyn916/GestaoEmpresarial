using Dapper.Contrib.Extensions;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.AcaoDTO;
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
    }
}
