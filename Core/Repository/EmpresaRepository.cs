using Core.Entity;
using Core.Interface.Repository;
using Core.Repository.Generic;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository;

public class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository
{
    private readonly AppDbContext _context;

    public EmpresaRepository(AppDbContext context) 
        : base(context)
    {
        _context = context;
    }

    public async Task<int?> GetEmpresaIdByUsuarioId(int usuarioId)
    {
        List<Empresa> empresas = GetAll().Result;

        foreach (var empresa in empresas)
        {
            if (empresa.UsuarioId == usuarioId) return empresa.Id;
        }

        return null;
    }
}