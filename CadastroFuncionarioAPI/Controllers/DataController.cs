﻿using AutoMapper;
using GestaoEmpresarial.Service;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // DataAnnotation
    public class DataController : ControllerBase
    {
        private DataService _Service;

        public DataController(IConfiguration connection)
        {
            _Service = new DataService(connection.GetConnectionString("DefaultConnection"));
        }

        [HttpPost("AdicionarDatas")] // Rota (EndPoint)
        public void AdicionarDatas()
        {
            _Service.Adicionar();
        }
    }
}
