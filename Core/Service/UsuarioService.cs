using Core.Interface.Repository;
using Core.Interface.Repository.Generic;
using Core.Interface.Service;
using Core.Service.Generic;
using Entidades;

namespace Core.Service;

public class UsuarioService : GenericService<Usuario>, IUsuarioService
{
    private readonly IUsuarioRepository _repository;

    public UsuarioService(IGenericRepository<Usuario> repository, IUsuarioRepository usuarioRepository) 
        : base(repository)
    {
        _repository = usuarioRepository;
    }

    public async Task Create(Usuario usuario)
    {
        await _repository.Create(usuario);
    }

    public async Task<Usuario> Login(string username, string password)
    {
        return await _repository.Login(username, password);
    }

    public async Task<int> ReturnTypeId(int usuarioId)
    {
        return await _repository.ReturnTypeId(usuarioId);
    }
}