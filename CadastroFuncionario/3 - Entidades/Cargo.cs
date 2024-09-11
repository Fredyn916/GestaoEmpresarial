using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEmpresarial.Entidades
{
    [Table("Cargos")]
    public class Cargo
    {
        public int Id { get; set; }
        public string Ocupacao { get; set;}
    }
}
