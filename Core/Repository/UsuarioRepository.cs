using Core.Entity;
using Core.Interface.Repository;
using Core.Repository.Generic;
using Entidades;

namespace Core.Repository;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(AppDbContext context) 
        : base(context) { }

    public async Task<Usuario> Login(string username, string password)
    {
        List<Usuario> usuarios = GetAll().Result;

        foreach (var usuario in usuarios)
        {
            if(usuario.Username == username && usuario.Password == password)
            {
                return usuario;
            }
        }

        return null;
    }

    public async Task<int> ReturnTypeId(int usuarioId)
    {
        Usuario usuario = GetById(usuarioId).Result;

        return usuario.TipoUsuarioId;
    }
}