using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Interfaces;
using GestaoEmpresarial.Service.Interfaces;

namespace GestaoEmpresarial.Service
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _Repository;

        public CargoService(ICargoRepository cargoRepository)
        {
            _Repository = cargoRepository;
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
