using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Entidades.DTO.AcaoDTO
{
    public class CreateAcaoDTO
    {
        public string Nome { get; set; }
        public string Ticker { get; set; }
        public int Codigo { get; set; }
    }
}
