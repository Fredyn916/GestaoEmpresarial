using Core.Interface.Repository.Generic;
using Entidades;

namespace Core.Interface.Repository;

public interface ICargoRepository : IGenericRepository<Cargo>
{
    Task Initialize();
}