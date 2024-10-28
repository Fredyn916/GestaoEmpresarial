using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarial.Service.Interfaces
{
    public interface IAcaoService
    {
        void Adicionar(Acao acao);
        List<Acao> Listar();
        Acao BuscarAcaoPorId(int id);
        void Editar(Acao acaoEdit);
        void Remover(int id);
    }
}
