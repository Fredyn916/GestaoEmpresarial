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
        public CargoRepository _repository { get; set; }

        public CargoService(string connectionString)
        {
            _repository = new CargoRepository(connectionString);
        }

        public List<Cargo> Listar()
        {
            return _repository.Listar();
        }

        public Cargo BuscarCargoPorId(int id)
        {
            return _repository.BuscarCargoPorId(id);
        }
    }
}
