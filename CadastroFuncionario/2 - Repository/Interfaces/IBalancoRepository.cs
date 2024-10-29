using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarial.Repository.Interfaces
{
    public interface IBalancoRepository
    {
        void Adicionar(Balanco balanco);
        List<Balanco> Listar();
    }
}
