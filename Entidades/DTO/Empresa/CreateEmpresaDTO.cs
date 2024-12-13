namespace Entidades.DTO.EmpresaDTO;

public class CreateEmpresaDTO
{
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string CEP { get; set; }
    public int UsuarioId { get; set; }
    public List<Funcionario> Funcionarios { get; set; }
    public int EconomiaId { get; set; }
}