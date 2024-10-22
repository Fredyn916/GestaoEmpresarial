using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresarial.Entidades.DTO.AcaoDTO
{
    public class UpdateAcaoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Nome' não preenchido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Ticker' não preenchido")]
        [MinLength(4, ErrorMessage = "Quantidade de caracteres abaixo da mínima (MIN 4 CARACTERES)")]
        [MaxLength(4, ErrorMessage = "Quantidade de caracteres acima da máxima (MAX 4 CARACTERES)")]
        public string Ticker { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Codigo' não preenchido")]
        [Range(3, 4, ErrorMessage = "Codigo Inválido")]
        public int Codigo { get; set; }
    }
}
