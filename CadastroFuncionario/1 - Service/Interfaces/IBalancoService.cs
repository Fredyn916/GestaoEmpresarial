using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarial.Service.Interfaces
{
    public interface IBalancoService
    {
        void Adicionar(Balanco balanco);
        List<Balanco> Listar();
        Balanco BuscarBalancoPorId(int id);
        void Editar(Balanco balancoEdit);
        void Remover(int id);
    }
}
