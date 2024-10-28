using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarial.Service.Interfaces
{
    public interface ICargoService
    {
        void Adicionar(Cargo cargo);
        List<Cargo> Listar();
        Cargo BuscarCargoPorId(int id);
        void Editar(Cargo cargoEdit);
        void Remover(int id);
    }
}
