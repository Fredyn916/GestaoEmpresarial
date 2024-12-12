namespace Entidades;

public class Empresa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string CEP { get; set; }
    public string UsuarioId { get; set; } // Usuário proprietário da empresa
    public List<Funcionario> Funcionarios { get; set; }
}