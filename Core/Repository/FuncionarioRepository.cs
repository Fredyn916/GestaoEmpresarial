using Core.Entity;
using Core.Interface.Repository;
using Core.Repository.Generic;
using Entidades;

namespace Core.Repository;

public class FuncionarioRepository : GenericRepository<Funcionario>, IFuncionarioRepository
{
    public FuncionarioRepository(AppDbContext context) 
        : base(context) { }
}