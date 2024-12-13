using Core.Entity;
using Core.Interface.Repository;
using Core.Repository.Generic;
using Entidades;

namespace Core.Repository;

public class DateBalanceRepository : GenericRepository<DateBalance>, IDateBalanceRepository
{
    public DateBalanceRepository(AppDbContext context)
       : base(context) { }
}