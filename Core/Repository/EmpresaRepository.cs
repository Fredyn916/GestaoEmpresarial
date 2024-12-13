using Core.Entity;
using Core.Interface.Repository;
using Core.Repository.Generic;
using Entidades;

namespace Core.Repository;

public class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository
{
    public EmpresaRepository(AppDbContext context) 
        : base(context) { }
}