using Core.Interface.Service;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IGenericService<Usuario> _service;

    public UsuarioController(IGenericService<Usuario> service)
    {
        _service = service;
    }
}