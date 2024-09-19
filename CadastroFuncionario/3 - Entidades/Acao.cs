namespace GestaoEmpresarial.Entidades
{
    public class Acao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ticker { get; set; }
        public double Valor { get; set; }
        public double DividendYield { get; set; }
    }
}