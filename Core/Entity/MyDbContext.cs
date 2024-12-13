using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Core.Entity;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    { }

    public DbSet<Usuario> Usuarios { get; set; }
}