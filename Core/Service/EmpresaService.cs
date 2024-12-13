using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Service.Generic;
using Entidades;

namespace Core.Service;

public class EmpresaService : GenericService<Empresa>, IEmpresaService
{
    public EmpresaService(IGenericRepository<Empresa> repository) 
        : base(repository) { }
}