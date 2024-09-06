using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Entidades
{
    [Table("Cargos")]
    public class Cargo
    {
        public int Id { get; set; }
        public string Ocupacao { get; set;}
    }
}
