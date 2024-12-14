using Core.Interface.Service.Generic;
using Entidades;

namespace Core.Interface.Service;

public interface ITipoUsuarioService : IGenericService<TipoUsuario>
{
    Task Initialize();
}