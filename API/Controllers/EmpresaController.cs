using AutoMapper;
using Core.Interface.Service;
using Entidades;
using Entidades.DTO.EmpresaDTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaService _service;
    private readonly IMapper _mapper;

    public EmpresaController(IEmpresaService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost("CreateEmpresa")]
    public async Task<IActionResult> Create(CreateEmpresaDTO empresaDTO)
    {
        try
        {
            Empresa empresa = _mapper.Map<Empresa>(empresaDTO);

            await _service.Create(empresa);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAllEmpresa")]
    public async Task<List<Empresa>> GetAll()
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

    [HttpGet("GetByIdEmpresa")]
    public async Task<Empresa> GetById(int id)
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

    [HttpPut("UpdateEmpresa")]
    public async Task<IActionResult> Update(Empresa empresa)
    {
        try
        {
            await _service.Update(empresa);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("RemoveEmpresa")]
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