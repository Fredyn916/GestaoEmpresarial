using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Service.Generic;
using Entidades;

namespace Core.Service;

public class CargoService : GenericService<Cargo>, ICargoService
{
    public CargoService(IGenericRepository<Cargo> repository) 
        : base(repository) { }
}