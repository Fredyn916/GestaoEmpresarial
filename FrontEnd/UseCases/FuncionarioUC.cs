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
        try
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Funcionario/CreateFuncionario", funcionarioDTO).Result;

            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Erro de requisição HTTP: {e.Message}");
        }
        catch (TaskCanceledException e)
        {
            Console.WriteLine($"Requisição cancelada: {e.Message}");
        }
        catch (AggregateException e)
        {
            foreach (var innerException in e.InnerExceptions)
            {
                Console.WriteLine($"Erro agregado: {innerException.Message}");
            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"Operação inválida: {e.Message}");
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Erro de formatação: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro inesperado: {e.Message}");
            throw;
        }
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
        try
        {
            HttpResponseMessage response = _client.PutAsJsonAsync("Funcionario/UpdateFuncionario", funcionario).Result;
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Erro de requisição HTTP: {e.Message}");
        }
        catch (TaskCanceledException e)
        {
            Console.WriteLine($"Requisição cancelada: {e.Message}");
        }
        catch (AggregateException e)
        {
            foreach (var innerException in e.InnerExceptions)
            {
                Console.WriteLine($"Erro agregado: {innerException.Message}");
            }
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"Operação inválida: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro inesperado: {e.Message}");
            throw;
        }

    }

    public void Remove(int id)
    {
        HttpResponseMessage response = _client.DeleteAsync($"Funcionario/RemoveFuncionario?id={id}").Result;
    }
}