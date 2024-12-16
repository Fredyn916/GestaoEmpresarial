using Entidades.DTO.UsuarioDTO;
using Entidades;
using System.Net.Http.Json;
using Entidades.DTO.CargoDTO;

namespace FrontEnd.UseCases;

public class CargoUC
{
    private readonly HttpClient _client;

    public CargoUC(HttpClient cliente)
    {
        _client = cliente;
    }

    public void Create(CreateCargoDTO cargoDTO)
    {
        HttpResponseMessage response = _client.PostAsJsonAsync("Cargo/CreateCargo", cargoDTO).Result;
    }

    public List<Cargo> GetAll()
    {
        return _client.GetFromJsonAsync<List<Cargo>>("Cargo/GetAllCargo").Result;
    }

    public Cargo GetById(int id)
    {
        return _client.GetFromJsonAsync<Cargo>($"Cargo/GetByIdCargo?id={id}").Result;
    }

    public void Update(Cargo cargo)
    {
        HttpResponseMessage response = _client.PutAsJsonAsync("Cargo/UpdateCargo", cargo).Result;
    }

    public void Remove(int id)
    {
        HttpResponseMessage response = _client.DeleteAsync($"Cargo/RemoveCargo?id={id}").Result;
    }
}