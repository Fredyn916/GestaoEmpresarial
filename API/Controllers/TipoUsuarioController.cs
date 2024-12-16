using AutoMapper;
using Core.Interface.Service;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Entidades.DTO.TipoUsuarioDTO;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class TipoUsuarioController : ControllerBase
{
    private readonly ITipoUsuarioService _service;
    private readonly IMapper _mapper;

    public TipoUsuarioController(ITipoUsuarioService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("CreateTipoUsuario")]
    public async Task<IActionResult> Create(CreateTipoUsuarioDTO tipoUsuarioDTO)
    {
        try
        {
            TipoUsuario tipoUsuario = _mapper.Map<TipoUsuario>(tipoUsuarioDTO);

            await _service.Create(tipoUsuario);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAllTipoUsuario")]
    public async Task<List<TipoUsuario>> GetAll()
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

    [HttpGet("GetByIdTipoUsuario")]
    public async Task<TipoUsuario> GetById(int id)
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

    [HttpPut("UpdateTipoUsuario")]
    public async Task<IActionResult> Update(TipoUsuario tipoUsuario)
    {
        try
        {
            await _service.Update(tipoUsuario);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("RemoveTipoUsuario")]
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

    [HttpGet("InitializeTipoUsuario")]
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