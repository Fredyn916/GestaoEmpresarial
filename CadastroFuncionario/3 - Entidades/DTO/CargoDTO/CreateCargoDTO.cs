using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresarial.Entidades.DTO.CargoDTO
{
    public class CreateCargoDTO
    {
        [Required(ErrorMessage = "Compo Obrigatório 'Ocupacao' não preenchido")]
        [MinLength(3, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(100, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string Ocupacao { get; set; }
    }
}
