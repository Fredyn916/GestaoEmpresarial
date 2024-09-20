using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoEmpresarial.Entidades
{
    [Table("Acoes")]
    public class Acao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ticker { get; set; }
        public int Codigo { get; set; }
        public double Valor { get; set; }
        public double Dividendo { get; set; }
    }
}