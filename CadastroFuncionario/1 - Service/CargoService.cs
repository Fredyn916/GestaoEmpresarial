using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;

namespace GestaoEmpresarial.Service
{
    public class CargoService
    {
        public CargoRepository _Repository { get; set; }

        public CargoService(string connectionString)
        {
            _Repository = new CargoRepository(connectionString);
        }

        public List<Cargo> Listar()
        {
            return _Repository.Listar();
        }

        public Cargo BuscarCargoPorId(int id)
        {
            return _Repository.BuscarCargoPorId(id);
        }
    }
}
