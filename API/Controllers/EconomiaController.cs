using AutoMapper;
using Core.Interface.Service;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Entidades.DTO.EconomiaDTO;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EconomiaController : ControllerBase
{
    private readonly IEconomiaService _service;
    private readonly IMapper _mapper;

    public EconomiaController(IEconomiaService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("CreateEconomia")]
    public async Task<IActionResult> Create(CreateEconomiaDTO economiaDTO)
    {
        try
        {
            Economia economia = _mapper.Map<Economia>(economiaDTO);

            await _service.Create(economia);
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

    [HttpGet("GetAllEconomia")]
    public async Task<List<Economia>> GetAll()
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

    [HttpGet("GetByIdEconomia")]
    public async Task<Economia> GetById(int id)
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

    [HttpPut("UpdateEconomia")]
    public async Task<IActionResult> Update(Economia economia)
    {
        try
        {
            await _service.Update(economia);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("RemoveEconomia")]
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
}