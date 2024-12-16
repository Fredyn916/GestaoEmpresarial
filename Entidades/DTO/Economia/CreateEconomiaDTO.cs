namespace Entidades.DTO.EconomiaDTO;

public class CreateEconomiaDTO
{
    public int DateBalanceId { get; set; }
    public double TotalBruto { get; set; }
    public double DespesasImovel { get; set; }
    public double DespesasFuncionarios { get; set; }
    public double DespesasServicos { get; set; }
    public double TotalDespesas { get; set; }
    public double TotalLucro { get; set; }
    public int EmpresaId { get; set; }
}