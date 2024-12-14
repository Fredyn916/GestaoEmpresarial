using Core.Interface.Repository.Generic;
using Entidades;

namespace Core.Interface.Repository;

public interface ITipoUsuarioRepository : IGenericRepository<TipoUsuario>
{
    Task Initialize();
}