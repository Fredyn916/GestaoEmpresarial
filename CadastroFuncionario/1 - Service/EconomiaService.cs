using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Service
{
    public class EconomiaService
    {
        public EconomiaRepository _Repository { get; set; }

        public EconomiaService(string connectionString) 
        {
            _Repository = new EconomiaRepository(connectionString);
        }

        public void Adicionar(Economia folhaFinanceira)
        {
            _Repository.Adicionar(folhaFinanceira);
        }
    }
}
