using Entidades.DTO.EmpresaDTO;
using Entidades;
using System.Net.Http.Json;
using Entidades.DTO.FuncionarioDTO;

namespace FrontEnd.UseCases;

public class FuncionarioUC
{
    private readonly HttpClient _client;

    public FuncionarioUC(HttpClient cliente)
    {
        _client = cliente;
    }

    public void Create(CreateFuncionarioDTO funcionarioDTO)
    {
        HttpResponseMessage response = _client.PostAsJsonAsync("Funcionario/CreateFuncionario", funcionarioDTO).Result;
    }

    public List<Funcionario> GetAll()
    {
        return _client.GetFromJsonAsync<List<Funcionario>>("Funcionario/GetAllFuncionario").Result;
    }

    public Funcionario GetById(int id)
    {
        return _client.GetFromJsonAsync<Funcionario>($"Funcionario/GetByIdFuncionario?id={id}").Result;
    }

    public void Update(Funcionario funcionario)
    {
        HttpResponseMessage response = _client.PutAsJsonAsync("Funcionario/UpdateFuncionario", funcionario).Result;
    }

    public void Remove(int id)
    {
        HttpResponseMessage response = _client.DeleteAsync($"Funcionario/RemoveFuncionario?id={id}").Result;
    }
}