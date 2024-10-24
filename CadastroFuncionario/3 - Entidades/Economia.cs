﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEmpresarial.Entidades
{
    [Table("RelatoriosFinanceiros")]
    public class Economia
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'DataCalculoFinanceiro' não preenchido")]
        public DateTime DataCalculoFinanceiro { get; set; } // Data da Folha Financeira da Empresa
        [Required(ErrorMessage = "Compo Obrigatório 'TotalBruto' não preenchido")]
        public double TotalBruto { get; set; } // Total valor arrecadado pela empresa
        [Required(ErrorMessage = "Compo Obrigatório 'TotalInvestimentos' não preenchido")]
        public double TotalInvestimentos { get; set; } // Total em aportes feitos por investidores 
        [Required(ErrorMessage = "Compo Obrigatório 'TotalCapital' não preenchido")]
        public double TotalCapital { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'DespesasImovel' não preenchido")]
        public double DespesasImovel { get; set; } // Total em contas do Imóvel
        [Required(ErrorMessage = "Compo Obrigatório 'DespesasFuncionarios' não preenchido")]
        public double DespesasFuncionarios { get; set; } // Total em gastos gerais com funcionários
        [Required(ErrorMessage = "Compo Obrigatório 'DespesasServicos' não preenchido")]
        public double DespesasServicos { get; set; } // Total em gastos com projetos, trabalhos, serviços, etc
        public double TotalDespesas { get; set; } // Total de gastos da empresa
        public double CapitalResultado { get; set; } // Diferença entre valor arrecadado menos as despesas
    }
}
