using GestaoEmpresarial.Entidades;

namespace GestaoEmpresarial.Repository.Interfaces
{
    public interface IAcaoRepository
    {
        void Adicionar(Acao acao);
        List<Acao> Listar();
        Acao BuscarAcaoPorId(int id);
        void Editar(Acao editAcao);
        void Remover(int id);
    }
}
