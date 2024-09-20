using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.AcaoDTO;
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
    }
}
