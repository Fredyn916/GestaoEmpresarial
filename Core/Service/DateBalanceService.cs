using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Service.Generic;
using Entidades;

namespace Core.Service;

public class DateBalanceService : GenericService<DateBalance>, IDateBalanceService
{
    public DateBalanceService(IGenericRepository<DateBalance> repository) 
        : base(repository) { }
}