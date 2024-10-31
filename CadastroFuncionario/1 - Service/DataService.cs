using GestaoEmpresarial.Repository.Interfaces;
using GestaoEmpresarial.Service.Interfaces;

namespace GestaoEmpresarial.Service
{
    public class DataService : IDataService
    {
        private readonly IDataRepository _Repository;

        public DataService(IDataRepository dataRepository)
        {
            _Repository = dataRepository;
        }

        public void Adicionar()
        {
            _Repository.Adicionar();
        }
    }
}
