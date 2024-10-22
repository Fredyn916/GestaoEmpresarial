using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.AcaoDTO;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using GestaoEmpresarial.Repository;

namespace GestaoEmpresarial.Service
{
    public class AcaoService
    {
        public AcaoRepository _Repository { get; set; }

        public AcaoService(string connectionString)
        {
            _Repository = new AcaoRepository(connectionString);
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
