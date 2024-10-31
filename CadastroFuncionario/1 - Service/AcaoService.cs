using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository.Interfaces;
using GestaoEmpresarial.Service.Interfaces;

namespace GestaoEmpresarial.Service
{
    public class AcaoService : IAcaoService
    {
        private readonly IAcaoRepository _Repository;

        public AcaoService(IAcaoRepository acaoRepository)
        {
            _Repository = acaoRepository;
        }

        public void Adicionar(Acao acao)
        {
            _Repository.Adicionar(acao);
        }

        public List<Acao> Listar()
        {
            return _Repository.Listar();
        }

        public Acao BuscarAcaoPorId(int id)
        {
            return _Repository.BuscarAcaoPorId(id);
        }

        public void Editar(Acao acaoEdit)
        {
            _Repository.Editar(acaoEdit);
        }

        public void Remover(int id)
        {
            _Repository.Remover(id);
        }
    }
}
