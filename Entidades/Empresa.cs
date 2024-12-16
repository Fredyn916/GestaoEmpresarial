﻿namespace Entidades;

public class Empresa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string CEP { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }
    public List<Funcionario> Funcionarios { get; set; }

    public override string ToString()
    {
        return $"<----------------- EMPRESA {Id} ----------------->" +
               $"Nome: {Nome}" +
               $"CNPJ: {CNPJ}" +
               $"CEP: {CEP}" +
               $"Proprietário: {Usuario.Username}";
    }
}