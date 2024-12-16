using Core.Interface.Service.Generic;
using Entidades;

namespace Core.Interface.Service;

public interface IUsuarioService : IGenericService<Usuario>
{
    Task<Usuario> Login(string username, string password);
    Task<int> ReturnTypeId(int usuarioId);
}