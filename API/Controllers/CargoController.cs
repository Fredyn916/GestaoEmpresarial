using AutoMapper;
using Core.Interface.Service;
using Entidades;
using Entidades.DTO.CargoDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CargoController : ControllerBase
{
    private readonly ICargoService _service;
    private readonly IMapper _mapper;

    public CargoController(ICargoService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("CreateCargo")]
    public async Task<IActionResult> Create(CreateCargoDTO cargoDTO)
    {
        try
        {
            Cargo cargo = _mapper.Map<Cargo>(cargoDTO);

            await _service.Create(cargo);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAllCargo")]
    public async Task<List<Cargo>> GetAll()
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

    [HttpGet("GetByIdCargo")]
    public async Task<Cargo> GetById(int id)
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

    [HttpPut("UpdateCargo")]
    public async Task<IActionResult> Update(Cargo cargo)
    {
        try
        {
            await _service.Update(cargo);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("RemoveCargo")]
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

    [HttpPost("InitializeCargo")]
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