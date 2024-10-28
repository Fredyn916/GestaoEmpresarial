using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarial.Service.Interfaces
{
    public interface IEconomiaService
    {
        void Adicionar(Economia folhaFinanceira);
        List<Economia> Listar();
        Economia BuscarRelatorioPorId(int id);
        void Editar(Economia relatorioFinanceiro);
        void Remover(int id);
    }
}
