using AutoMapper;
using Core.Interface.Service;
using Entidades;
using Entidades.DTO.UsuarioDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _service;
    private readonly IMapper _mapper;

    public UsuarioController(IUsuarioService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("CreateUsuario")]
    public async Task<IActionResult> Create(CreateUsuarioDTO usuarioDTO)
    {
        try
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);

            await _service.Create(usuario);
            return Ok();
        }
        catch (DbUpdateException ex)
        {
            return BadRequest(ex.InnerException);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAllUsuario")]
    public async Task<List<Usuario>> GetAll()
    {
        try
        {
            return await _service.GetAll();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("GetByIdUsuario")]
    public async Task<Usuario> GetById(int id)
    {
        try
        {
            return await _service.GetById(id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPut("UpdateUsuario")]
    public async Task<IActionResult> Update(Usuario usuario)
    {
        try
        {
            await _service.Update(usuario);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("RemoveUsuario")]
    public async Task<IActionResult> Remove(int id)
    {
        try
        {
            await _service.Remove(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("LoginUsuario")]
    public async Task<Usuario> Login(string username, string password)
    {
        try
        {
            return await _service.Login(username, password);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("ReturnTypeIdUsuario")]
    public async Task<int> ReturnTypeId(int usuarioId)
    {
        try
        {
            return await _service.ReturnTypeId(usuarioId);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("InitializeUsuario")]
    public async Task<IActionResult> Initialize()
    {
        try
        {
            await _service.Initialize();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}