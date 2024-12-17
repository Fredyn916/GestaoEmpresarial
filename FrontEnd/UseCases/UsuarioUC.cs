using Entidades;
using Entidades.DTO.UsuarioDTO;
using System.Net.Http.Json;

namespace FrontEnd.UseCases;

public class UsuarioUC
{
    private readonly HttpClient _client;

    public UsuarioUC(HttpClient cliente)
    {
        _client = cliente;
    }

    public void Create(CreateUsuarioDTO usuarioDTO)
    {
        HttpResponseMessage response = _client.PostAsJsonAsync("Usuario/CreateUsuario", usuarioDTO).Result;
    }

    public List<Usuario> GetAll()
    {
        return _client.GetFromJsonAsync<List<Usuario>>("Usuario/GetAllUsuario").Result;
    }

    public Usuario GetById(int id)
    {
        return _client.GetFromJsonAsync<Usuario>($"Usuario/GetByIdUsuario?id={id}").Result;
    }

    public void Update(Usuario usuario)
    {
        HttpResponseMessage response = _client.PutAsJsonAsync("Usuario/UpdateUsuario", usuario).Result;
    }

    public void Remove(int id)
    {
        HttpResponseMessage response = _client.DeleteAsync($"Usuario/RemoveUsuario?id={id}").Result;
    }

    public Usuario Login(string username, string password)
    {
        return _client.GetFromJsonAsync<Usuario>($"Usuario/LoginUsuario?username={username}&password={password}").Result;
    }

    public int ReturnTypeId(int usuarioId)
    {
        return int.Parse(_client.GetStringAsync($"Usuario/ReturnTypeIdUsuario?usuarioId={usuarioId}").Result);
    }

    public void Initialize()
    {
        HttpResponseMessage response = _client.GetAsync($"Usuario/InitializeUsuario").Result;
    }
}