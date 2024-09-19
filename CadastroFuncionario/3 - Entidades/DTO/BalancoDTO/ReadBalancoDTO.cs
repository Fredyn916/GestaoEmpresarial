namespace GestaoEmpresarial.Entidades.DTO.BalancoDTO
{
    public class ReadBalancoDTO
    {
        public int Id { get; set; }
        public int EconomiaId { get; set; }
        public Economia Economia { get; set; }
        public int AcaoId { get; set; }
        public Acao Acao { get; set; }
    }
}
