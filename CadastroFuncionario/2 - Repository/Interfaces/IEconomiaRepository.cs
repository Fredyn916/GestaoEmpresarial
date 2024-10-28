using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarial.Repository.Interfaces
{
    public interface IEconomiaRepository
    {
        void Adicionar(Economia folhaFinanceira);
        List<Economia> Listar();
        Economia BuscarRelatorioPorId(int id);
        void Editar(Economia relatorioFinanceiro);
        void Remover(int id);
    }
}
