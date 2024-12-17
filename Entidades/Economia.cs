using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

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

    public string ExibirDetalhes(DateBalance? dateBalance, Empresa? empresa)
    {
        string detalhes = $"<----------------- BALANÇO {Id} ----------------->" +
                          $"\nData: {dateBalance.Data.ToString("dd/MM/yyyy")}" +
                          $"\nTotal Bruto: R$ {TotalBruto}" +
                          $"\nDespesas Imóvel: R$ {DespesasImovel}" +
                          $"\nDespesas Funcionários: R$ {DespesasFuncionarios}" +
                          $"\nDespesas Serviços: R$ {DespesasServicos}" +
                          $"\nTotal Despesas:  R$ {TotalDespesas}" +
                          $"\nTotal Lucro:  R$ {TotalLucro}" +
                          $"\nEmpresa: {empresa.Nome}";
        return detalhes;
    }
}