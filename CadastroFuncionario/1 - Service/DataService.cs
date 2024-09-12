using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;

namespace GestaoEmpresarial.Service
{
    public class DataService
    {
        public DataRepository _Repository { get; set; }

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
