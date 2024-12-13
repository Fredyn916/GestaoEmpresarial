using Core.Entity;
using Core.Interface.Repository;
using Core.Repository.Generic;
using Entidades;

namespace Core.Repository;

public class CargoRepository : GenericRepository<Cargo>, ICargoRepository
{
    public CargoRepository(AppDbContext context) 
        : base(context) { }
}