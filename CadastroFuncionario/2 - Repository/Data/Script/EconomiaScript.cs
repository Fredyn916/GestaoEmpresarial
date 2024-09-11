using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Repository.Data.Script
{
    public static class EconomiaScript
    {
        public static double GetTotalCapital(double TotalBruto, double TotalInvestimentos)
        {
            return TotalBruto + TotalInvestimentos;
        }

        public static double GetTotalDespesas(double DespesasImovel, double DespesasFuncionarios, double DespesasServicos)
        {
            return DespesasImovel + (DespesasFuncionarios + DespesasServicos);
        }

        public static double GetCapitalResultado(double TotalCapital, double TotalDespesas)
        {
            return TotalCapital - TotalDespesas;
        }
    }
}
