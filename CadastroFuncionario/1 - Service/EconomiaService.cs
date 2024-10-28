using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;
using GestaoEmpresarial.Service.Interfaces;

namespace GestaoEmpresarial.Service
{
    public class EconomiaService : IEconomiaService
    {
        public EconomiaRepository _Repository { get; set; }

        public EconomiaService(string connectionString) 
        {
            _Repository = new EconomiaRepository(connectionString);
        }

        public void Adicionar(Economia folhaFinanceira)
        {
            _Repository.Adicionar(folhaFinanceira);
        }

        public List<Economia> Listar()
        {
            return _Repository.Listar();
        }

        public Economia BuscarRelatorioPorId(int id)
        {
            return _Repository.BuscarRelatorioPorId(id);
        }

        public void Editar(Economia relatorioFinanceiro)
        {
            _Repository.Editar(relatorioFinanceiro);
        }

        public void Remover(int id)
        {
            _Repository.Remover(id);
        }

    }
}
