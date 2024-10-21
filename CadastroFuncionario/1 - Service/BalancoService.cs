using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;

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
