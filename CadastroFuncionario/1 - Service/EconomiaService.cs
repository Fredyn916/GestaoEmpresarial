using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;

namespace GestaoEmpresarial.Service
{
    public class EconomiaService
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
    }
}
