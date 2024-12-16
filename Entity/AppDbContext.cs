using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Core.Entity;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<DateBalance> Datas { get; set; }
    public DbSet<Economia> Economias { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<TipoUsuario> TiposUsuario { get; set; }
}