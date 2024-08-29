using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Entidades
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public double Salario { get; set; }
        public int CargoId { get; set; }
        [JsonIgnore] // Esconde a solicitação do JSON de {Cargo}
        public virtual Cargo? Cargo { get; set; } // Propriedade de navegação
    }
}
