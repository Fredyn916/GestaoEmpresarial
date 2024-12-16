using Core.Interface.Service.Generic;
using Entidades;
using Entidades.DTO.UsuarioDTO;

namespace Core.Interface.Service;

public interface IUsuarioService : IGenericService<Usuario>
{
    Task<Usuario> CreateUsuario(Usuario usuario);
    Task<Usuario> Login(string username, string password);
    Task<int> ReturnTypeId(int usuarioId);
}