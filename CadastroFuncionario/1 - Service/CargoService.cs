using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;
using GestaoEmpresarial.Repository.Interfaces;
using GestaoEmpresarial.Service.Interfaces;

namespace GestaoEmpresarial.Service
{
    public class CargoService : ICargoService
    {
        public ICargoRepository _Repository { get; set; }

        public CargoService(string connectionString)
        {
            _Repository = new CargoRepository(connectionString);
        }

        public void Adicionar(Cargo cargo)
        {
            _Repository.Adicionar(cargo);
        }

        public List<Cargo> Listar()
        {
            return _Repository.Listar();
        }

        public Cargo BuscarCargoPorId(int id)
        {
            return _Repository.BuscarCargoPorId(id);
        }

        public void Editar(Cargo cargoEdit)
        {
            _Repository.Editar(cargoEdit);
        }

        public void Remover(int id)
        {
            _Repository.Remover(id);
        }
    }
}
