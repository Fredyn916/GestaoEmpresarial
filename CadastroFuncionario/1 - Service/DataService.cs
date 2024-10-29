using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;
using GestaoEmpresarial.Repository.Interfaces;
using GestaoEmpresarial.Service.Interfaces;

namespace GestaoEmpresarial.Service
{
    public class DataService : IDataService
    {
        public IDataRepository _Repository { get; set; }

        public DataService(string connectionString)
        {
            _Repository = new DataRepository(connectionString);
        }

        public void Adicionar()
        {
            _Repository.Adicionar();
        }
    }
}
