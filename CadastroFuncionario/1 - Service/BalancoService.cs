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

        public void Adicionar(Balanco balanco)
        {
            // Lógica de coferência de existência
            _Repository.Adicionar(balanco);
        }

        public List<Balanco> Listar()
        {
            return _Repository.Listar();
        }

        public Balanco BuscarBalancoPorId(int id)
        {
            return _Repository.BuscarBalancoPorId(id);
        }

        public void Editar(Balanco balancoEdit)
        {
            _Repository.Editar(balancoEdit);
        }

        public void Remover(int id)
        {
            _Repository.Remover(id);
        }
    }
}
