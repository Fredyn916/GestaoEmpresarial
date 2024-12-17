using Core.Entity;
using Core.Interface.Repository;
using Core.Repository.Generic;
using Entidades;

namespace Core.Repository;

public class CargoRepository : GenericRepository<Cargo>, ICargoRepository
{
    private readonly AppDbContext _context;

    public CargoRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task Initialize()
    {
        List<Cargo> cargos = GetAll().Result;
        int count = cargos.Count;

        if (count == 0)
        {
            List<Cargo> registros = new List<Cargo>
            {
                new Cargo
                {
                    Ocupacao = "Diretor Executivo",
                    Remuneracao = 15000.0,
                    Step = 1
                },
                new Cargo
                {
                    Ocupacao = "Diretor Executivo",
                    Remuneracao = 50000.0,
                    Step = 2
                },
                new Cargo
                {
                    Ocupacao = "Diretor Executivo",
                    Remuneracao = 150000.0,
                    Step = 3
                },
                new Cargo
                {
                    Ocupacao = "Diretor de Operações",
                    Remuneracao = 12000.0,
                    Step = 1
                },
                new Cargo
                {
                    Ocupacao = "Diretor de Operações",
                    Remuneracao = 40000.0,
                    Step = 2
                },
                new Cargo
                {
                    Ocupacao = "Diretor de Operações",
                    Remuneracao = 120000.0,
                    Step = 3
                },
                new Cargo
                {
                    Ocupacao = "Diretor Financeiro",
                    Remuneracao = 15000.0,
                    Step = 1
                },
                new Cargo
                {
                    Ocupacao = "Diretor Financeiro",
                    Remuneracao = 40000.0,
                    Step = 2
                },
                new Cargo
                {
                    Ocupacao = "Diretor Financeiro",
                    Remuneracao = 120000.0,
                    Step = 3
                },
                new Cargo
                {
                    Ocupacao = "Diretor de Marketing",
                    Remuneracao = 12000.0,
                    Step = 1
                },
                new Cargo
                {
                    Ocupacao = "Diretor de Marketing",
                    Remuneracao = 35000.0,
                    Step = 2
                },
                new Cargo
                {
                    Ocupacao = "Diretor de Marketing",
                    Remuneracao = 100000.0,
                    Step = 3
                },
                new Cargo
                {
                    Ocupacao = "Analista",
                    Remuneracao = 2500.0,
                    Step = 1
                },
                new Cargo
                {
                    Ocupacao = "Analista",
                    Remuneracao = 5000.0,
                    Step = 2
                },
                new Cargo
                {
                    Ocupacao = "Analista",
                    Remuneracao = 9000.0,
                    Step = 3
                },
                new Cargo
                {
                    Ocupacao = "Estagiário",
                    Remuneracao = 1000.0,
                    Step = 1
                },
                new Cargo
                {
                    Ocupacao = "Estagiário",
                    Remuneracao = 1500.0,
                    Step = 2
                },
                new Cargo
                {
                    Ocupacao = "Estagiário",
                    Remuneracao = 2500.0,
                    Step = 3
                },
                new Cargo
                {
                    Ocupacao = "Supervisor",
                    Remuneracao = 3000.0,
                    Step = 1
                },
                new Cargo
                {
                    Ocupacao = "Supervisor",
                    Remuneracao = 6000.0,
                    Step = 2
                },
                new Cargo
                {
                    Ocupacao = "Supervisor",
                    Remuneracao = 10000.0,
                    Step = 3
                },
                new Cargo
                {
                    Ocupacao = "Gerente",
                    Remuneracao = 5000.0,
                    Step = 1
                },
                new Cargo
                {
                    Ocupacao = "Gerente",
                    Remuneracao = 10000.0,
                    Step = 2
                },
                new Cargo
                {
                    Ocupacao = "Gerente",
                    Remuneracao = 18000.0,
                    Step = 3
                },
                new Cargo
                {
                    Ocupacao = "Presidente",
                    Remuneracao = 30000.0,
                    Step = 1
                },
                new Cargo
                {
                    Ocupacao = "Presidente",
                    Remuneracao = 80000.0,
                    Step = 2
                },
                new Cargo
                {
                    Ocupacao = "Presidente",
                    Remuneracao = 170000.0,
                    Step = 3
                },
                new Cargo
                {
                    Ocupacao = "Zelador",
                    Remuneracao = 1200.0,
                    Step = 1
                },
                new Cargo
                {
                    Ocupacao = "Zelador",
                    Remuneracao = 1800.0,
                    Step = 2
                },
                new Cargo
                {
                    Ocupacao = "Zelador",
                    Remuneracao = 2500.0,
                    Step = 3
                },
            };

            foreach (var registro in registros)
            {
                _context.Cargos.Add(registro);
                _context.SaveChanges();
            }
        }  
    }

}