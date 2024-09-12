using AutoMapper;
using GestaoEmpresarial.Entidades.DTO.FuncionarioDTO;

namespace GestaoEmpresarial.Entidades.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateFuncionarioDTO, Funcionario>().ReverseMap();
            CreateMap<CreateEconomiaDTO, Economia>().ReverseMap();
            CreateMap<CreateDataDTO, Data>().ReverseMap();
        }
    }
}
