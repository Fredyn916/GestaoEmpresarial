using AutoMapper;
using Entidades.DTO.CargoDTO;
using Entidades.DTO.DateBalanceDTO;
using Entidades.DTO.EconomiaDTO;
using Entidades.DTO.EmpresaDTO;
using Entidades.DTO.FuncionarioDTO;
using Entidades.DTO.UsuarioDTO;

namespace Entidades.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCargoDTO, Cargo>().ReverseMap();
        CreateMap<CreateDateBalanceDTO, DateBalance>().ReverseMap();
        CreateMap<CreateEconomiaDTO, Economia>().ReverseMap();
        CreateMap<CreateEmpresaDTO, Empresa>().ReverseMap();
        CreateMap<CreateFuncionarioDTO, Funcionario>().ReverseMap();
        CreateMap<CreateUsuarioDTO, Usuario>().ReverseMap();
    }
}