using Core.Entity;
using Core.Interface.Repository;
using Core.Repository.Generic;
using Entidades;

namespace Core.Repository;

public class EconomiaRepository : GenericRepository<Economia>, IEconomiaRepository
{
    public EconomiaRepository(AppDbContext context)
        : base(context) { }
}