using Core.Interface.Repository;
using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Service.Generic;
using Entidades;

namespace Core.Service;

public class EmpresaService : GenericService<Empresa>, IEmpresaService
{
    private readonly IEmpresaRepository _empresaRepository;

    public EmpresaService(IGenericRepository<Empresa> repository, IEmpresaRepository empresaRepository) 
        : base(repository)
    {
        _empresaRepository = empresaRepository;
    }

    public async Task<int?> GetEmpresaIdByUsuarioId(int usuarioId)
    {
        return await _empresaRepository.GetEmpresaIdByUsuarioId(usuarioId);
    }
}