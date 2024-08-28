using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial._3___Entidades
{
    public class Funcionario
    {
        int Id { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }
        public Cargo Cargo { get; set; }
    }
}
