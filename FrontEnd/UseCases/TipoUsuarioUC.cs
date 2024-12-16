using Entidades.DTO.FuncionarioDTO;
using Entidades;
using System.Net.Http.Json;
using Entidades.DTO.TipoUsuarioDTO;

namespace FrontEnd.UseCases;

public class TipoUsuarioUC
{
    private readonly HttpClient _client;

    public TipoUsuarioUC(HttpClient cliente)
    {
        _client = cliente;
    }

    public void Create(CreateTipoUsuarioDTO tipoUsuarioDTO)
    {
        HttpResponseMessage response = _client.PostAsJsonAsync("TipoUsuario/CreateTipoUsuario", tipoUsuarioDTO).Result;
    }

    public List<TipoUsuario> GetAll()
    {
        return _client.GetFromJsonAsync<List<TipoUsuario>>("TipoUsuario/GetAllTipoUsuario").Result;
    }

    public TipoUsuario GetById(int id)
    {
        return _client.GetFromJsonAsync<TipoUsuario>($"TipoUsuario/GetByIdTipoUsuario?id={id}").Result;
    }

    public void Update(TipoUsuario tipoUsuario)
    {
        HttpResponseMessage response = _client.PutAsJsonAsync("TipoUsuario/UpdateTipoUsuario", tipoUsuario).Result;
    }

    public void Remove(int id)
    {
        HttpResponseMessage response = _client.DeleteAsync($"TipoUsuario/RemoveTipoUsuario?id={id}").Result;
    }

    public void Initialize()
    {
        HttpResponseMessage response = _client.GetAsync($"TipoUsuario/InitializeTipoUsuario").Result;
    }
}