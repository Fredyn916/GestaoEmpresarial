using AutoMapper;
using Core.Interface.Service;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Entidades.DTO.DateBalanceDTO;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class DateBalanceController : ControllerBase
{
    private readonly IDateBalanceService _service;
    private readonly IMapper _mapper;

    public DateBalanceController(IDateBalanceService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("CreateDateBalance")]
    public async Task<IActionResult> Create(CreateDateBalanceDTO dateBalanceDTO)
    {
        try
        {
            DateBalance dateBalance = _mapper.Map<DateBalance>(dateBalanceDTO);

            await _service.Create(dateBalance);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAllDateBalance")]
    public async Task<List<DateBalance>> GetAll()
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

    [HttpGet("GetByIdDateBalance")]
    public async Task<DateBalance> GetById(int id)
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

    [HttpPut("UpdateDateBalance")]
    public async Task<IActionResult> Update(DateBalance dateBalance)
    {
        try
        {
            await _service.Update(dateBalance);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("RemoveDateBalance")]
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