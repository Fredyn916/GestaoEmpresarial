using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Service.Generic;
using Entidades;

namespace Core.Service;

public class EconomiaService : GenericService<Economia>, IEconomiaService
{
    public EconomiaService(IGenericRepository<Economia> repository)
        : base(repository) { }
}