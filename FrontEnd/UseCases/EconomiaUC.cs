using Entidades.DTO.DateBalanceDTO;
using Entidades;
using System.Net.Http.Json;
using Entidades.DTO.EconomiaDTO;

namespace FrontEnd.UseCases;

public class EconomiaUC
{
    private readonly HttpClient _client;

    public EconomiaUC(HttpClient cliente)
    {
        _client = cliente;
    }

    public void Create(CreateEconomiaDTO economiaDTO)
    {
        HttpResponseMessage response = _client.PostAsJsonAsync("Economia/CreateEconomia", economiaDTO).Result;
    }

    public List<Economia> GetAll()
    {
        return _client.GetFromJsonAsync<List<Economia>>("Economia/GetAllEconomia").Result;
    }

    public Economia GetById(int id)
    {
        return _client.GetFromJsonAsync<Economia>($"Economia/GetByIdEconomia?id={id}").Result;
    }

    public void Update(Economia economia)
    {
        HttpResponseMessage response = _client.PutAsJsonAsync("Economia/UpdateEconomia", economia).Result;
    }

    public void Remove(int id)
    {
        HttpResponseMessage response = _client.DeleteAsync($"Economia/RemoveEconomia?id={id}").Result;
    }
}