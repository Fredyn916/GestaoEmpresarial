using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;
using GestaoEmpresarial.Repository.Interfaces;
using GestaoEmpresarial.Service.Interfaces;

namespace GestaoEmpresarial.Service
{
    public class BalancoService : IBalancoService
    {
        public IBalancoRepository _Repository { get; set; }

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
