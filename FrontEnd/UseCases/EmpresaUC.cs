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

    public async Task<int> GetEmpresaIdByUsuarioId(int usuarioId)
    {
        try
        {
            var response = await _client.GetAsync($"Empresa/GetEmpresaIdByUsuarioIdEmpresa?usuarioId={usuarioId}");

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            if (int.TryParse(content, out int empresaId))
            {
                return empresaId;
            }
            else
            {
                throw new FormatException("A resposta não está no formato esperado de um inteiro.");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Erro de requisição HTTP: {e.Message}");
            throw;
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Erro de formatação: {e.Message}");
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro inesperado: {e.Message}");
            throw;
        }
    }
}