using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarial.Repository.Interfaces
{
    public interface IDataRepository
    {
        void Adicionar();
        List<DataBalanco> Listar();
        DataBalanco BuscarPorID(int id);
    }
}
