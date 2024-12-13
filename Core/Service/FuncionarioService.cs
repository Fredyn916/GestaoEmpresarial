using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Service.Generic;
using Entidades;

namespace Core.Service;

public class FuncionarioService : GenericService<Funcionario>, IFuncionarioService
{
    public FuncionarioService(IGenericRepository<Funcionario> repository) 
        : base(repository) { }
}