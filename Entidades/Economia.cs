using System.ComponentModel.DataAnnotations;

namespace Entidades;

public class Economia
{
    public int Id { get; set; }
    public int DateBalanceId { get; set; }
    public virtual DateBalance DateBalance { get; set; }
    public double TotalBruto { get; set; }
    public double DespesasImovel { get; set; }
    public double DespesasFuncionarios { get; set; }
    public double DespesasServicos { get; set; }
    public double TotalDespesas { get; set; }
    public double TotalLucro { get; set; }
    public int EmpresaId { get; set; }
}