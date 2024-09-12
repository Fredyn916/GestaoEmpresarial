using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEmpresarial.Entidades
{
    [Table("DatasBalanco")]
    public class Data
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}