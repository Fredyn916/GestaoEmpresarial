using Core.Interface.Repository;
using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Service.Generic;
using Entidades;

namespace Core.Service;

public class DateBalanceService : GenericService<DateBalance>, IDateBalanceService
{
    private readonly IDateBalanceRepository _dateBalanceRepository;

    public DateBalanceService(IGenericRepository<DateBalance> repository, IDateBalanceRepository dateBalanceRepository) 
        : base(repository)
    {
        _dateBalanceRepository = dateBalanceRepository;
    }

    public async Task Initialize()
    {
        await _dateBalanceRepository.Initialize();
    }
}