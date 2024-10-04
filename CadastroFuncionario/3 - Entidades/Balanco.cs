using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEmpresarial.Entidades
{
    [Table("Balancos")]
    public class Balanco
    {
        public int Id { get; set; }
        public int EconomiaId { get; set; }
        public int AcaoId { get; set; }
    }
}