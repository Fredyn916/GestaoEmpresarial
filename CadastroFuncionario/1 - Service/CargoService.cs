using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Repository;
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

        public CargoService(string connectionString)
        {
            repository = new CargoRepository(connectionString);
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
