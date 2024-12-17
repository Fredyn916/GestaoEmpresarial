using Core.Interface.Service.Generic;
using Entidades;

namespace Core.Interface.Service;

public interface IEmpresaService : IGenericService<Empresa>
{
    Task<int?> GetEmpresaIdByUsuarioId(int usuarioId);
}