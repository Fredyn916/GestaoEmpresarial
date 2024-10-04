using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Service
{
    public class BalancoService
    {
        public BalancoRepository _Repository { get; set; }

        public BalancoService(string connectionString)
        {
            _Repository = new BalancoRepository(connectionString);
        }

        public void Adicionar()
        {
            // Lógica de coferência de existência
            // _Repository.Adicionar();
        }

        public List<Balanco> Listar()
        {
            return _Repository.Listar();
        }
    }
}
