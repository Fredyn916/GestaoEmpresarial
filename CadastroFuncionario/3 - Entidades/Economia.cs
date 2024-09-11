using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Entidades
{
    public class Economia
    {
        public double TotalBruto { get; set; } // Total valor arrecadado pela empresa
        public double TotalInvestimentos { get; set; } // Total em aportes feitos por investidores 
        public double DespesasImovel { get; set; } // Total em contas do Imóvel
        public double DespesasFuncionarios { get; set; } // Total em gastos gerais com funcionários
        public double DespesasServicos { get; set; } // Total em gastos com projetos, trabalhos, serviços, etc
        public double TotalDespesas { get; set; } // Total de gastos da empresa
        public double CapitalResultado { get; set; } // Diferença entre valor arrecadado menos as despesas
    }
}
