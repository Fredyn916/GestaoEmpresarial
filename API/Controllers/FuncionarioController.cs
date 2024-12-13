using AutoMapper;
using Core.Interface.Service;
using Entidades;
using Entidades.DTO.FuncionarioDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioService _service;
    private readonly IMapper _mapper;

    public FuncionarioController(IFuncionarioService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("CreateFuncionario")]
    public async Task<IActionResult> Create(CreateFuncionarioDTO funcionarioDTO)
    {
        try
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDTO);

            await _service.Create(funcionario);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAllFuncionario")]
    public async Task<List<Funcionario>> GetAll()
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

    [HttpGet("GetByIdFuncionario")]
    public async Task<Funcionario> GetById(int id)
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

    [HttpPut("UpdateFuncionario")]
    public async Task<IActionResult> Update(Funcionario funcionario)
    {
        try
        {
            await _service.Update(funcionario);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("RemoveFuncionario")]
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