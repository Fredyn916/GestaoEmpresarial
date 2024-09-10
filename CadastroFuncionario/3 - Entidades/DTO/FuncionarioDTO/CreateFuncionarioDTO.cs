using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Entidades.DTO.FuncionarioDTO
{
    public class CreateFuncionarioDTO
    {
        [Required(ErrorMessage = "Compo Obrigatório 'Nome' não preenchido")]
        [MinLength(2, ErrorMessage = "Quantidade de caracteres abaixo da mínima")]
        [MaxLength(100, ErrorMessage = "Quantidade de caracteres acima da máxima")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Idade' não preenchido")]
        [Range(18, 65, ErrorMessage = "Idade Inapripriada")]
        public int Idade { get; set; }
        [Required(ErrorMessage = "Compo Obrigatório 'Peso' não preenchido")]
        [Range(15, 500, ErrorMessage = "Peso Inapripriado")]
        public double Peso { get; set; }
        [Range(1, 10, ErrorMessage = "Cargo Inválido")]
        public int CargoId { get; set; }
        // [JsonIgnore] // Esconde a solicitação do JSON de {Cargo}
        // public virtual Cargo? Cargo { get; set; } // Propriedade de navegação
    }
}
