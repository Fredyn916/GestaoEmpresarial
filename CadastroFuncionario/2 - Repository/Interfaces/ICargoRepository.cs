using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarial.Repository.Interfaces
{
    public interface ICargoRepository
    {
        void Adicionar(Cargo cargo);
        List<Cargo> Listar();
        Cargo BuscarCargoPorId(int id);
        void Editar(Cargo editCargo);
        void Remover(int id);
    }
}
