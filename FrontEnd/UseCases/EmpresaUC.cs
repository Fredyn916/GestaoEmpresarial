using Entidades;
using System.Net.Http.Json;
using Entidades.DTO.EmpresaDTO;

namespace FrontEnd.UseCases;

public class EmpresaUC
{
    private readonly HttpClient _client;

    public EmpresaUC(HttpClient cliente)
    {
        _client = cliente;
    }

    public void Create(CreateEmpresaDTO empresaDTO)
    {
        HttpResponseMessage response = _client.PostAsJsonAsync("Empresa/CreateEmpresa", empresaDTO).Result;
    }

    public List<Empresa> GetAll()
    {
        return _client.GetFromJsonAsync<List<Empresa>>("Empresa/GetAllEmpresa").Result;
    }

    public Empresa GetById(int id)
    {
        return _client.GetFromJsonAsync<Empresa>($"Empresa/GetByIdEmpresa?id={id}").Result;
    }

    public void Update(Empresa empresa)
    {
        HttpResponseMessage response = _client.PutAsJsonAsync("Empresa/UpdateEmpresa", empresa).Result;
    }

    public void Remove(int id)
    {
        HttpResponseMessage response = _client.DeleteAsync($"Empresa/RemoveEmpresa?id={id}").Result;
    }
}