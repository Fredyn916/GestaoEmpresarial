using Entidades.DTO.CargoDTO;
using Entidades;
using System.Net.Http.Json;
using Entidades.DTO.DateBalanceDTO;

namespace FrontEnd.UseCases;

public class DateBalanceUC
{
    private readonly HttpClient _client;

    public DateBalanceUC(HttpClient cliente)
    {
        _client = cliente;
    }

    public void Create(CreateDateBalanceDTO dateBalanceDTO)
    {
        HttpResponseMessage response = _client.PostAsJsonAsync("DateBalance/CreateDateBalance", dateBalanceDTO).Result;
    }

    public List<DateBalance> GetAll()
    {
        return _client.GetFromJsonAsync<List<DateBalance>>("DateBalance/GetAllDateBalance").Result;
    }

    public DateBalance GetById(int id)
    {
        return _client.GetFromJsonAsync<DateBalance>($"DateBalancergo/GetByIdDateBalance?id={id}").Result;
    }

    public void Update(DateBalance dateBalance)
    {
        HttpResponseMessage response = _client.PutAsJsonAsync("DateBalance/UpdateDateBalance", dateBalance).Result;
    }

    public void Remove(int id)
    {
        HttpResponseMessage response = _client.DeleteAsync($"DateBalance/RemoveDateBalance?id={id}").Result;
    }

    public void Initialize()
    {
        HttpResponseMessage response = _client.GetAsync($"DateBalance/InitializeDateBalance").Result;
    }
}