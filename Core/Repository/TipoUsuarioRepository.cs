using Core.Entity;
using Core.Interface.Repository;
using Core.Repository.Generic;
using Entidades;

namespace Core.Repository;

public class TipoUsuarioRepository : GenericRepository<TipoUsuario>, ITipoUsuarioRepository
{
    private readonly AppDbContext _context;

    public TipoUsuarioRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task Initialize()
    {
        var quantidadeDeRegistros = _context.TiposUsuario.Count();

        if (quantidadeDeRegistros == 0)
        {
            List<TipoUsuario> registros = new List<TipoUsuario>
                {
                    new TipoUsuario
                    {
                        Tipo = "Administrador"
                    },
                    new TipoUsuario
                    {
                        Tipo = "Proprietário"
                    },
                    new TipoUsuario
                    {
                        Tipo = "Funcionário"
                    }
                };

            foreach (var registro in registros)
            {
                _context.TiposUsuario.Add(registro);
                _context.SaveChanges();
            }
        }
    }
}