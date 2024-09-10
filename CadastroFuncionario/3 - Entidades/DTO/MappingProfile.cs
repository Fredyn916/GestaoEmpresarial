using AutoMapper;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEmpresarial.Entidades.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateFuncionarioDTO, Funcionario>().ReverseMap();
        }
    }
}
