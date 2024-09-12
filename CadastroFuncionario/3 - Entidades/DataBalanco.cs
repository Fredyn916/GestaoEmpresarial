using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEmpresarial.Entidades
{
    [Table("DatasBalanco")]
    public class DataBalanco
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}