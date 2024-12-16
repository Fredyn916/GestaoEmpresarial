using Core.Entity;
using Core.Interface.Repository;
using Core.Repository.Generic;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context) 
        : base(context)
    {
        _context = context;
    }

    public async Task<Usuario> CreateUsuario(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

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