using Core.Interface.Repository.Generic;
using Entidades;

namespace Core.Interface.Repository;

public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    Task<Usuario> CreateUsuario(Usuario usuario);
    Task<Usuario> Login(string username, string password);
    Task<int> ReturnTypeId(int usuarioId);
}