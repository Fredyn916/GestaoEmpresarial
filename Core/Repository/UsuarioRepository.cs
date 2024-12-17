using AutoMapper;
using Core.Entity;
using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Repository.Generic;
using Entidades;
using Entidades.DTO.UsuarioDTO;

namespace Core.Repository;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UsuarioRepository(AppDbContext context, IMapper mapper)
        : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Create(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task<Usuario> Login(string username, string password)
    {
        List<Usuario> usuarios = GetAll().Result;

        foreach (var usuario in usuarios)
        {
            if (usuario.Username == username && usuario.Password == password)
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

    public async Task Initialize()
    {
        List<Usuario> usuarios = GetAll().Result;
        int count = usuarios.Count;

        if (count == 0)
        {
            Usuario usuario = new Usuario
            {
                TipoUsuarioId = 1,
                Username = "Admin",
                Password = "Admin"
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}