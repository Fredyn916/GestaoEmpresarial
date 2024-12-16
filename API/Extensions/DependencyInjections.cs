using Core.Interface.Repository.Generic;
using Core.Interface.Repository;
using Core.Interface.Service.Generic;
using Core.Interface.Service;
using Core.Repository.Generic;
using Core.Repository;
using Core.Service.Generic;
using Core.Service;

namespace API.Extensions;

public static class DependencyInjections
{
    public static void DIs(IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

        services.AddScoped(typeof(ICargoRepository), typeof(CargoRepository));
        services.AddScoped(typeof(IDateBalanceRepository), typeof(DateBalanceRepository));
        services.AddScoped(typeof(IEconomiaRepository), typeof(EconomiaRepository));
        services.AddScoped(typeof(IEmpresaRepository), typeof(EmpresaRepository));
        services.AddScoped(typeof(IFuncionarioRepository), typeof(FuncionarioRepository));
        services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
        services.AddScoped(typeof(ITipoUsuarioRepository), typeof(TipoUsuarioRepository));

        services.AddScoped(typeof(ICargoService), typeof(CargoService));
        services.AddScoped(typeof(IDateBalanceService), typeof(DateBalanceService));
        services.AddScoped(typeof(IEconomiaService), typeof(EconomiaService));
        services.AddScoped(typeof(IEmpresaService), typeof(EmpresaService));
        services.AddScoped(typeof(IFuncionarioService), typeof(FuncionarioService));
        services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
        services.AddScoped(typeof(ITipoUsuarioService), typeof(TipoUsuarioService));
    }
}