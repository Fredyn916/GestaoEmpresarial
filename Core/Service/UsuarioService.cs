using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Service.Generic;
using Entidades;

namespace Core.Service;

public class UsuarioService : GenericService<Usuario>, IUsuarioService
{
    public UsuarioService(IGenericRepository<Usuario> repository) 
        : base(repository) { }
}