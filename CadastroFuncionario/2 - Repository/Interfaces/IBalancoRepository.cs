using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarial.Repository.Interfaces
{
    public interface IBalancoRepository
    {
        void Adicionar(Balanco balanco);
        List<Balanco> Listar();
        Balanco BuscarBalancoPorId(int id);
        void Editar(Balanco editBalanco);
        void Remover(int id);
    }
}
