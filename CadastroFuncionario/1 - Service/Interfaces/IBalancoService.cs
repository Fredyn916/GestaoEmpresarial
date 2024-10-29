using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarial.Service.Interfaces
{
    public interface IBalancoService
    {
        void Adicionar();
        List<Balanco> Listar();
    }
}
