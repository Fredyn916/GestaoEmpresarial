namespace Entidades.DTO.FuncionarioDTO;

public class CreateFuncionarioDTO
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public int Idade { get; set; }
    public double Peso { get; set; }
    public double Salario { get; set; }
    public int CargoId { get; set; }
    public int EmpresaId { get; set; }
}