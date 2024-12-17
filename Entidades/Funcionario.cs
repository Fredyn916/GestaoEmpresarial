using System.Runtime.ConstrainedExecution;
using System.Text.Json.Serialization;

namespace Entidades;

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public int Idade { get; set; }
    public double Peso { get; set; }
    public double Salario { get; set; }
    public int CargoId { get; set; }
    public virtual Cargo Cargo { get; set; }
    public int EmpresaId { get; set; }
    public virtual Empresa Empresa { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }

    public string ExibirDetalhes(Cargo? cargo, Empresa? empresa)
    {
        string detalhes = $"<--------------- FUNCIONÁRIO {Id} --------------->" +
                          $"\nNome: {Nome}" +
                          $"\nCPF: {CPF}" +
                          $"\nIdade: {Idade}" +
                          $"\nPeso: {Peso}" +
                          $"\nSalário: R$ {Salario}" +
                          $"\nCargo: {cargo.Ocupacao}" +
                          $"\nStep: {cargo.Step}" +
                          $"\nEmpresa: {empresa.Nome}";
        return detalhes;
    }

    public string ExibirRemuneracao(Cargo? cargo)
    {
        string detalhes = $"<--------------- FUNCIONÁRIO {Id} --------------->" +
                          $"\nNome: {Nome}" +
                          $"\nSalário: R$ {Salario}" +
                          $"\nCargo: {cargo.Ocupacao}" +
                          $"\nStep: {cargo.Step}";
        return detalhes;
    }
}