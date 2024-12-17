using Core.Interface.Repository.Generic;
using Entidades;

namespace Core.Interface.Repository;

public interface IDateBalanceRepository : IGenericRepository<DateBalance>
{
    Task Initialize();
}