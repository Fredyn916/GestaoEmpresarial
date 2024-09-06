using Dapper;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Data.Script;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Data.Repository
{
    public class InicializadorDB
    {
        public static void Inicializar()
        {
            using var connection = new SQLiteConnection("Data Source=GestaoEmpresarial.db"); // Criando a conexão

            connection.Execute(DataBaseScript.CreateTables());

            int cargoCount = connection.QueryFirst<int>(CargoScript.SelectCountAllCargos()); // Query Select na tabela para retornar o Count

            if (cargoCount == 0) // Se a tabela 'Cargos' estiver vazia, insere os cargos
            {
                connection.Execute(CargoScript.InsertCargos());
            }
        }
    }
}