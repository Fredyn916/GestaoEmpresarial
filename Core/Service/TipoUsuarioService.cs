using Core.Interface.Repository;
using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Service.Generic;
using Entidades;

namespace Core.Service;

public class TipoUsuarioService : GenericService<TipoUsuario>, ITipoUsuarioService
{
    private readonly ITipoUsuarioRepository _repository;

    public TipoUsuarioService(IGenericRepository<TipoUsuario> repository, ITipoUsuarioRepository tipoUsuarioRepository) 
        : base(repository)
    {
        _repository = tipoUsuarioRepository;
    }

    public async Task Initialize()
    {
        await _repository.Initialize();
    }
}