using Core.Entity;
using Core.Interface.Repository;
using Core.Repository.Generic;
using Entidades;
using Microsoft.Data.Sqlite;

namespace Core.Repository;

public class DateBalanceRepository : GenericRepository<DateBalance>, IDateBalanceRepository
{
    private readonly AppDbContext _context;

    public DateBalanceRepository(AppDbContext context)
       : base(context)
    {
        _context = context;
    }

    public async Task Initialize()
    {
        List<DateBalance> datas = GetAll().Result;
        int count = datas.Count;

        if (count == 0)
        {
            for (int i = 0; i < 1200; i++)
            {
                DateOnly dataDoMes = DateOnly.FromDateTime(DateTime.Now.AddMonths(i)).AddDays(14);

                DateBalance dataBalance = new DateBalance()
                {
                    Data = dataDoMes
                };

                _context.Datas.Add(dataBalance);
                _context.SaveChanges();
            }
        }
    }
}