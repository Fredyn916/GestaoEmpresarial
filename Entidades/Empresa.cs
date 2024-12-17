using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades;

public class Empresa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string CEP { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }
    [NotMapped]
    public List<Funcionario> Funcionarios { get; set; }

    public string ExibirDetalhes(Usuario? usuario)
    {
        string detalhes = $"<----------------- EMPRESA {Id} ----------------->" +
                          $"\nNome: {Nome}" +
                          $"\nCNPJ: {CNPJ}" +
                          $"\nCEP: {CEP}";
                          if(usuario != null)
                          {
              detalhes += $"\nProprietário: {usuario.Username}";
                          }
        return detalhes;
    }
}