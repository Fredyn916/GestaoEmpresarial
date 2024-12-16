using Core.Interface.Repository;
using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Service.Generic;
using Entidades;

namespace Core.Service;

public class CargoService : GenericService<Cargo>, ICargoService
{
    private readonly ICargoRepository _repository;

    public CargoService(IGenericRepository<Cargo> repository, ICargoRepository cargoRepository) 
        : base(repository)
    {
        _repository = cargoRepository;
    }

    public async Task Initialize()
    {
        await _repository.Initialize();
    }
}