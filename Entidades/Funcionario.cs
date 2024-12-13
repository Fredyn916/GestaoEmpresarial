﻿namespace Entidades;

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
}