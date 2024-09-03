using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Service
{
    public class CargoService
    {
        public CargoRepository repository { get; set; }

        public CargoService(IConfiguration connection)
        {
            repository = new CargoRepository(connection);
        }

        public List<Cargo> Listar()
        {
            return repository.Listar();
        }

        public Cargo BuscarCargoPorId(int id)
        {
            return repository.BuscarCargoPorId(id);
        }
    }
}
