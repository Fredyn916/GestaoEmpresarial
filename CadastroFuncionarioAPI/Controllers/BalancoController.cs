using AutoMapper;
using GestaoEmpresarial.Entidades;
using GestaoEmpresarial.Entidades.DTO.BalancoDTO;
using GestaoEmpresarial.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class BalancoController : ControllerBase
    {
        private readonly IBalancoService _Service;
        private readonly IMapper _Mapper;

        public BalancoController(IMapper mapper, IBalancoService balancoService)
        {
            _Service = balancoService;
            _Mapper = mapper;
        }
        /// <summary>
        /// Adiciona um balanço no Banco de Dados
        /// </summary>
        /// <param name="balancoToMap"></param>
        [HttpPost("AdicionarBalanco")] // Rota (EndPoint)
        public void AdicionarBalanco(CreateBalancoDTO balancoToMap)
        {
            Balanco balanco = _Mapper.Map<Balanco>(balancoToMap);

            _Service.Adicionar(balanco);
        }
        /// <summary>
        /// Visualiza os balanços do Banco de Dados
        /// </summary>
        /// <returns></returns>
        [HttpGet("VisualizarBalancos")] // Rota (EndPoint)
        public List<Balanco> ListarBalanco()
        {
            return _Service.Listar();
        }
        /// <summary>
        /// Visualiza um balanço do Banco de Dados respectivo ao Id do parâmetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("BuscarBalancoPorId")] // Rota (EndPoint)
        public Balanco BuscarBalancoPorId(int id)
        {
            return _Service.BuscarBalancoPorId(id);
        }
        /// <summary>
        /// Edita um balanço do Banco de Dados respectivo ao valor da propriedade "Id" do objeto do parâmetro
        /// </summary>
        /// <param name="balanco"></param>
        [HttpPut("EditarBalanco")] // Rota (EndPoint)
        public void EditarBalanco(Balanco balanco)
        {
            _Service.Editar(balanco);
        }
        /// <summary>
        /// Remove um balanço do Banco de Dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("RemoverBalanco")] // Rota (EndPoint)
        public void RemoverBalanco(int id)
        {
            _Service.Remover(id);
        }
    }
}
