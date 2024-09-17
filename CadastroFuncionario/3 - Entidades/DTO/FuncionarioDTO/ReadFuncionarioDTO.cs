using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Entidades.DTO.FuncionarioDTO
{
    public class ReadFuncionarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public double Salario { get; set; }
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
    }
}
